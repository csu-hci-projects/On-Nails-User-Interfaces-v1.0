# Progress Log
Date | Progress | Problem 
----------- | --------- | ---------
04/10/2019 | Wiring. The tag reader is able to read a tag when the tag is getting close to the reader. | The reader cannot identify different tags.
04/11/2019 | Be able to identify different tags by unpluging RX before uploading the sketch and use different tags to implement different functions. | To do: figure out how to use Arduino to control external device.
04/13/2019 | Be able to turn up/turn down/mute PC volume thru different RFID tags (via USB). Trouble shooting: If the serial monitor is open then VB cannot use the COM port. | To do: wireless (soldering needed).
04/14/2019 | Enable Wireless Control. (Remember to unplug RX before uploading sketch.) | To do: encapsulation and beautification. figure out how to increment and decrement the volume by certain amount.
04/15/2019 | Enable specified amount of increase and decrease. | To do: 2mm pin is too short for a female jumper, it easily gets disconnected. 
05/02/2019 | Enable play and stop audio. | To do: allow songs switching. 
05/04/2019 | Enable switch songs. | To do: Paint fake nails.

# Wiring (USB)
Arduino | RFID Reader ID-12 
----------- | --------- 
5V | VCC (PIN 11)
GND |  GND (PIN 1), FORM (Format Selector, PIN 7) 
RX | D0 (Data 0, PIN 9)
D10 (OUTPUT -> HIGH) | RES (Reset, PIN 2)            


# Wiring (Wireless via Bluetooth)
Arduino | RFID Reader ID-12 
----------- | --------- 
5V | VCC (PIN 11)
GND |  GND (PIN 1), FORM (Format Selector, PIN 7) 
RX | D0 (Data 0, PIN 9)
D10 (OUTPUT -> HIGH) | RES (Reset, PIN 2)    

Arduino | Bluetooth HC-06
----------- | --------- 
5V | VCC 
GND |  GND
-- | TX
TX | RX
