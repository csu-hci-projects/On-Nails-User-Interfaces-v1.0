# Progress Log
Date | Progress | Problem 
----------- | --------- | ---------
04/10/2019 | Wiring. The tag reader is able to read a tag when the tag is getting close to the reader. | The reader cannot identify different tags.
04/11/2019 | Be able to identify different tags by unpluging RX before uploading the sketch and use different tags to implement different functions. | To do: figure out how to use Arduino to control external device.

# Wiring
Arduino | RFID Reader ID-12 
----------- | --------- 
5V | VCC (PIN 11)
GND |  GND (PIN 1), FORM (Format Selector, PIN 7) 
RX | D0 (Data 0, PIN 9)
D10 (OUTPUT -> HIGH) | RES (Reset, PIN 2)            
