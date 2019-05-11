byte tagID[12];
boolean tagRead = false;
int RFIDResetPin = 14;

void setup()
{
  Serial.begin(9600);
  pinMode(RFIDResetPin, OUTPUT);
}

void loop()
{
  digitalWrite(RFIDResetPin, HIGH);
  int incomingByte = 0;

  if (Serial.available() >= 13)
  {
    if (Serial.read() == 0x02)
    {
      tagRead = true;
      for (int index = 0; index < sizeof(tagID); index++)
      {
        byte val = Serial.read();
        if ( val >= '0' && val <= '9')
          val = val - '0';
        else if ( val >= 'A' && val <= 'F')
          val = 10 + val - 'A';
        tagID[index] = val;
      }
    }
    else
    {
      tagRead = false;
    }
  }

  if (tagRead == true)
  {
    //print_tag();
    byte tag_up[10] = {0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x2, 0x9, 0xB};
    byte tag_down[10] = {0x0, 0x0, 0x7, 0x8, 0x4, 0xA, 0x1, 0x6, 0x0, 0x6};
    byte tag_mute[10] = {0x0, 0x0, 0x7, 0x8, 0x4, 0xA, 0x1, 0x5, 0xF, 0xA};
    byte tag_play[10] = {0x0, 0x0, 0x7, 0x8, 0x4, 0xA, 0x1, 0x6, 0x4, 0x9};
    byte tag_switch[10] = {0x0, 0x0, 0x7, 0x8, 0x4, 0xA, 0x1, 0x6, 0x8, 0x0};

    if (memcmp(tagID, tag_up, 10) == 0) {
      Serial.println("U"); // turn up
    } else if (memcmp(tagID, tag_down, 10) == 0) {
      Serial.println("D"); // turn down
    } else if (memcmp(tagID, tag_mute, 10) == 0) {
      Serial.println("M"); // mute
    } else if (memcmp(tagID, tag_play, 10) == 0) {
      Serial.println("P"); // play + stop
    } else if (memcmp(tagID, tag_switch, 10) == 0) {
      Serial.println("S"); // next song
    }
    
    clear_tag();
    tagRead = false;
  }
  
  delay(10);

}

void print_tag()
{
  Serial.print("Tag ID: ");
  for (int index = 0; index < 10; index++)
  {
    Serial.print(tagID[index], HEX);
  }
  Serial.print("\r\nChecksum: ");
  Serial.print(tagID[10], HEX);
  Serial.println(tagID[11], HEX);
}

void clear_tag()
{
  for (int index = 0; index < sizeof(tagID); index++)
  {
    tagID[index] = 0;
  }
}
