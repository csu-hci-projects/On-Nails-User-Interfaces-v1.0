| Date   |      Progress      | Problem     |
|----------|:-------------:|
| 04/10/2019 | Wiring. The tag reader is able to read a tag when the tag is getting close to the reader. | The reader cannot identify different tags.|

Wiring Diagram:
|        Arduino       |              RFID Reader ID-12             |
|:--------------------:|:------------------------------------------:|
|          5V          |                VCC (PIN 11)                |
|          GND         | GND (PIN 1), FORM (Format Selector, PIN 7) |
|          RX          |             D0 (Data 0, PIN 9)             |
| D10 (OUTPUT -> HIGH) |             RES (Reset, PIN 2)             |
