---
extensions: 
  - name: "CAN DBC File Explained"
    description: "CAN DBC File Explained - A Simple Intro [+Editor Playground]"
    categories:
    - databases
    link: "https://www.csselectronics.com/pages/can-dbc-file-database-intro"
---
## CAN DBC file (CAN database)

A CAN DBC is a plain-text “database” that defines how to decode raw CAN frames (CAN ID + data bytes) into human-readable signals with units (e.g., EngineSpeed in rpm). In other words: it’s the mapping layer that turns hex payloads into physical values.

A DBC describes **messages** (`BO_`: ID, name, DLC, sender) and the **signals** inside them (`SG_`: start bit, bit length, endianness Intel/Motorola, signed/unsigned, scale/offset, unit, receiver). Decoding typically follows: match the frame to a message definition → extract the right bits/bytes → compute `physical = offset + scale * raw`.

## Practical notes (J1939/OBD2 & availability)

For 29-bit protocols like J1939, matching is often done on the **PGN level** using masks, so one DBC message can apply to multiple CAN IDs. DBC files are frequently proprietary to OEMs, but you can use standardized databases (J1939, OBD2, NMEA2000, ISOBUS) or reverse-engineered community DBCs. Advanced DBC features include comments/attributes, value tables (enums), multiplexing, and (tool-dependent) transport-protocol support.
