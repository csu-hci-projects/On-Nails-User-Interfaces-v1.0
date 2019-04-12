//Example sketch for RFID ID-20LA reader
//More info available at http://tutorial.cytron.com.my/

byte tagID[12];
boolean tagread = false;
int reset = 14;

void setup()
{
  Serial.begin(9600);
  pinMode(reset, OUTPUT);
}

void loop()
{
  digitalWrite(reset, HIGH);
  int incomingByte = 0;

  if(Serial.available() >= 13)      //Make sure all the frame is received
  {
    if(Serial.read() == 0x02)       //Check for the start byte = 0x02
    {
      tagread = true;                //New tag is read
      for(int index = 0; index < sizeof(tagID); index++)
      {
        byte val = Serial.read();
        //convert from ASCII value to value range from 0 to 9 and A to F
        if( val >= '0' && val <= '9')
          val = val - '0';
        else if( val >= 'A' && val <= 'F')
          val = 10 + val - 'A';
        tagID[index] = val;
      }
    }
    else
    {
      tagread = false;                //Discard and skip
    }
  }
  
  if(tagread == true)                 //New tag is read
  {
    print_tag();                    //Display the tag ID
    // implement functions
    byte target_tag_one[10] = {0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x2, 0x9, 0xB};
    if (memcmp(tagID, target_tag_one, 10) == 0){
      Serial.println("Target Tag");  
    } else {
      Serial.println("Not Target Tag"); 
    }
    //
    clear_tag();                    //Clear the tag ID and ready for next tag
    tagread = false;
  }
  delay(10);
  
}

void print_tag()                    //Subroutine to display the tagID content
{
  Serial.print("Tag ID: ");        
  for(int index = 0; index < 10; index++)
  {
    Serial.print(tagID[index], HEX);  //Display tagID
  }
  Serial.print("\r\nChecksum: ");
  Serial.print(tagID[10], HEX);       //Display checksum
  Serial.println(tagID[11], HEX);
}

void clear_tag()                    //Subroutine to clear the tagID content
{  
  for(int index = 0; index < sizeof(tagID); index++)
  {
    tagID[index] = 0;
  }
}
