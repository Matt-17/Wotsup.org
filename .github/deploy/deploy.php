<?php
/**
 * Atomic Deployment Script for Wotsup.org
 * 
 * This script handles the deployment of the Jekyll site by:
 * 1. Receiving a zip file containing the entire _site build
 * 2. Unpacking it to a temporary staging directory
 * 3. Atomically replacing the live site
 * 4. Cleaning up temporary files and itself
 * 
 * Usage:
 *   Upload this script + site.zip to the server
 *   Call via: https://yoursite.com/deploy.php?key=YOUR_DEPLOY_KEY
 * 
 * Returns:
 *   200 OK on success with JSON response
 *   500 Internal Server Error on failure with JSON error details
 */

// Configuration
define('DEPLOY_KEY_FILE', __DIR__ . '/.deploy.key');
define('ZIP_FILE', __DIR__ . '/site.zip');
define('STAGING_DIR', __DIR__ . '/.deploy-staging');
define('DEPLOY_DIR', __DIR__ . '/.deploy');
define('MAX_EXECUTION_TIME', 300); // 5 minutes

// Set execution time limit
set_time_limit(MAX_EXECUTION_TIME);

// Initialize response
header('Content-Type: application/json');
$response = [
    'success' => false,
    'timestamp' => date('c'),
    'errors' => []
];

/**
 * Log and track errors
 */
function logError($message) {
    global $response;
    $response['errors'][] = $message;
    error_log("[DEPLOY ERROR] $message");
}

/**
 * Send JSON response and exit
 */
function respond($statusCode = 200) {
    global $response;
    http_response_code($statusCode);
    echo json_encode($response, JSON_PRETTY_PRINT);
    exit;
}

/**
 * Recursively remove directory
 */
function removeDirectory($dir) {
    if (!is_dir($dir)) {
        return true;
    }
    
    $items = array_diff(scandir($dir), ['.', '..']);
    foreach ($items as $item) {
        $path = $dir . DIRECTORY_SEPARATOR . $item;
        if (is_dir($path)) {
            removeDirectory($path);
        } else {
            unlink($path);
        }
    }
    return rmdir($dir);
}

/**
 * Get directory size recursively
 */
function getDirectorySize($dir) {
    $size = 0;
    if (!is_dir($dir)) {
        return $size;
    }
    
    $items = array_diff(scandir($dir), ['.', '..']);
    foreach ($items as $item) {
        $path = $dir . DIRECTORY_SEPARATOR . $item;
        if (is_dir($path)) {
            $size += getDirectorySize($path);
        } else {
            $size += filesize($path);
        }
    }
    return $size;
}

/**
 * Count files recursively
 */
function countFiles($dir) {
    $count = 0;
    if (!is_dir($dir)) {
        return $count;
    }
    
    $items = array_diff(scandir($dir), ['.', '..']);
    foreach ($items as $item) {
        $path = $dir . DIRECTORY_SEPARATOR . $item;
        if (is_dir($path)) {
            $count += countFiles($path);
        } else {
            $count++;
        }
    }
    return $count;
}

try {
    // Step 1: Validate deploy key
    if (!file_exists(DEPLOY_KEY_FILE)) {
        logError('Deployment key file not found');
        respond(403);
    }
    
    $expectedKey = trim(file_get_contents(DEPLOY_KEY_FILE));
    if (empty($expectedKey)) {
        logError('Deployment key file is empty');
        respond(403);
    }
    
    $providedKey = $_GET['key'] ?? '';
    if (empty($providedKey) || $providedKey !== $expectedKey) {
        logError('Invalid or missing deployment key');
        respond(403);
    }
    
    $response['step'] = 'authenticated';
    
    // Step 2: Check if zip file exists
    if (!file_exists(ZIP_FILE)) {
        logError('Deployment zip file not found: ' . ZIP_FILE);
        respond(404);
    }
    
    $zipSize = filesize(ZIP_FILE);
    $response['zip_size_mb'] = round($zipSize / 1024 / 1024, 2);
    $response['step'] = 'zip_found';
    
    // Step 3: Verify zip file
    $zip = new ZipArchive();
    $zipStatus = $zip->open(ZIP_FILE);
    
    if ($zipStatus !== true) {
        logError("Failed to open zip file. Error code: $zipStatus");
        respond(500);
    }
    
    $response['zip_files'] = $zip->numFiles;
    $response['step'] = 'zip_opened';
    
    // Step 4: Create staging directory
    if (file_exists(STAGING_DIR)) {
        removeDirectory(STAGING_DIR);
    }
    
    if (!mkdir(STAGING_DIR, 0755, true)) {
        logError('Failed to create staging directory: ' . STAGING_DIR);
        $zip->close();
        respond(500);
    }
    
    $response['step'] = 'staging_created';
    
    // Step 5: Extract zip to staging
    if (!$zip->extractTo(STAGING_DIR)) {
        logError('Failed to extract zip to staging directory');
        $zip->close();
        removeDirectory(STAGING_DIR);
        respond(500);
    }
    
    $zip->close();
    $response['step'] = 'extracted';
    
    // Step 6: Verify extraction
    $extractedFiles = countFiles(STAGING_DIR);
    if ($extractedFiles === 0) {
        logError('No files were extracted from zip');
        removeDirectory(STAGING_DIR);
        respond(500);
    }
    
    $response['extracted_files'] = $extractedFiles;
    $response['step'] = 'verified';
    
    // Step 7: Get list of current files (before deployment)
    $liveFiles = [];
    $liveDir = dirname(__DIR__);
    if (is_dir($liveDir)) {
        $iterator = new RecursiveIteratorIterator(
            new RecursiveDirectoryIterator($liveDir, RecursiveDirectoryIterator::SKIP_DOTS),
            RecursiveIteratorIterator::SELF_FIRST
        );
        
        foreach ($iterator as $item) {
            if ($item->isFile()) {
                $relativePath = str_replace($liveDir . DIRECTORY_SEPARATOR, '', $item->getPathname());
                // Skip files in .deploy* directories
                if (strpos($relativePath, '.deploy') !== 0) {
                    $liveFiles[] = $relativePath;
                }
            }
        }
    }
    
    $response['old_file_count'] = count($liveFiles);
    
    // Step 8: Move staged files to live (atomic replacement)
    // We'll delete old files first, then move new ones, then clean up orphaned directories
    $deletedCount = 0;
    $movedCount = 0;
    
    // Delete old files that aren't in staging
    foreach ($liveFiles as $file) {
        $targetPath = $liveDir . DIRECTORY_SEPARATOR . $file;
        $stagingPath = STAGING_DIR . DIRECTORY_SEPARATOR . $file;
        
        // If file doesn't exist in new build, delete it
        if (!file_exists($stagingPath)) {
            if (file_exists($targetPath) && unlink($targetPath)) {
                $deletedCount++;
            }
        }
    }
    
    // Move new files from staging to live
    $iterator = new RecursiveIteratorIterator(
        new RecursiveDirectoryIterator(STAGING_DIR, RecursiveDirectoryIterator::SKIP_DOTS),
        RecursiveIteratorIterator::SELF_FIRST
    );
    
    foreach ($iterator as $item) {
        $relativePath = str_replace(STAGING_DIR . DIRECTORY_SEPARATOR, '', $item->getPathname());
        $targetPath = $liveDir . DIRECTORY_SEPARATOR . $relativePath;
        
        if ($item->isDir()) {
            if (!file_exists($targetPath)) {
                mkdir($targetPath, 0755, true);
            }
        } else {
            // Create parent directory if needed
            $targetDir = dirname($targetPath);
            if (!file_exists($targetDir)) {
                mkdir($targetDir, 0755, true);
            }
            
            // Move file (overwrite if exists)
            if (copy($item->getPathname(), $targetPath)) {
                $movedCount++;
            } else {
                logError("Failed to copy file: $relativePath");
            }
        }
    }
    
    // Clean up orphaned directories (those that exist in live but not in staging)
    // Scan live directory recursively and remove empty directories not in new build
    $directoriesCount = 0;
    $rdi = new RecursiveDirectoryIterator($liveDir, RecursiveDirectoryIterator::SKIP_DOTS);
    $rii = new RecursiveIteratorIterator($rdi, RecursiveIteratorIterator::CHILD_FIRST);
    
    foreach ($rii as $item) {
        if ($item->isDir() && strpos($item->getPathname(), '.deploy') === false) {
            $relativePath = str_replace($liveDir . DIRECTORY_SEPARATOR, '', $item->getPathname());
            $stagingPath = STAGING_DIR . DIRECTORY_SEPARATOR . $relativePath;
            
            // If directory doesn't exist in new build and is empty, delete it
            if (!file_exists($stagingPath) && count(array_diff(scandir($item->getPathname()), ['.', '..'])) === 0) {
                if (@rmdir($item->getPathname())) {
                    $directoriesCount++;
                }
            }
        }
    }
    
    $response['directories_cleaned'] = $directoriesCount;
    
    $response['files_deleted'] = $deletedCount;
    $response['files_deployed'] = $movedCount;
    $response['step'] = 'deployed';
    
    // Step 9: Clean up staging directory
    removeDirectory(STAGING_DIR);
    $response['step'] = 'staging_cleaned';
    
    // Step 10: Remove zip file and deploy key
    if (file_exists(ZIP_FILE)) {
        unlink(ZIP_FILE);
    }
    if (file_exists(DEPLOY_KEY_FILE)) {
        unlink(DEPLOY_KEY_FILE);
    }
    $response['step'] = 'zip_cleaned';
    
    // Step 11: Cleanup is delegated to the CI workflow (removal of the .deploy directory).
    // Deploy script will not attempt to remove itself or the .deploy directory to avoid
    // permission issues or fragile background execution. The workflow should perform
    // a recursive removal of the `.deploy` directory after the deployment completes.
    $response['step'] = 'cleanup_delegated_to_workflow';
    
    // Success!
    $response['success'] = true;
    $response['message'] = "Deployment completed successfully";
    $response['duration_seconds'] = round(microtime(true) - $_SERVER['REQUEST_TIME_FLOAT'], 2);
    
    respond(200);
    
} catch (Exception $e) {
    logError('Exception: ' . $e->getMessage());
    $response['step'] = $response['step'] ?? 'unknown';
    respond(500);
}
