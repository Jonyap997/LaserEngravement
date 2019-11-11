#include <Stepper.h>

const int LASER_PIN = 13;
const int MOTOR_A_PIN = 3;
const int MOTOR_B_PIN = 4;
const int INTERRUPT_PIN = 8;
const int OFF = 0;
const int ON = 1;
const int ROW = 100;
const int COL = 200;
const int BW_PIXEL_PER_BYTE = 8;
const int GS_PIXEL_PER_BYTE = 2;
const int BW_NUM_OF_ELEMENTS = (ROW * COL) / BW_PIXEL_PER_BYTE;
const int GS_NUM_OF_ELEMENTS = (ROW * COL) / GS_PIXEL_PER_BYTE;
const int STEPS_PER_REVOLUTION = 200;

bool initialMode = false;
long laserInitialPosition = 0;
int arrayIndex=0;
bool dataValid = false, engraveDone = false;
//int picArrayGS[GS_NUM_OF_ELEMENTS];
//int picArrayBW[BW_NUM_OF_ELEMENTS];
String colourMode,data, dataValidStr, engraveDoneStr;
int checkSum, sum = 0, pixelCount=1, rowCount=1;
Stepper stepperA(STEPS_PER_REVOLUTION, 8, 9, 10, 11);

void setup() {
  // put your setup code here, to run once:
  pinMode(LASER_PIN, OUTPUT);
  pinMode(MOTOR_A_PIN, OUTPUT);
  pinMode(MOTOR_B_PIN, OUTPUT);
  attachInterrupt(digitalPinToInterrupt(INTERRUPT_PIN),emergencyStop,HIGH);
  Serial.begin(9600);
  initialSettings();
  
}

void loop() {
  // put your main code here, to run repeatedly:
    /*
    if(!dataComplete)
    {
        receiveData();  
    }
    else if (!dataValid)
    {
        checkData();
    }
    else if (!engraveDone)
    {
        unpackDataAndEngrave();
        pixelIndex++;
        engraveDone = checkEngraveDone();
    }
    else
        Serial.println("DONE");
    */

    if(!engraveDone)
    {
        receiveData();

        if(dataValid)
            unpackDataAndEngrave();

        engraveDone = checkEngraveDone();
    }
    
}

/*
 * Initial settings
 */

void initialSettings()
{
  if (!initialMode)
  {
    digitalWrite(LASER_PIN, OFF);
    digitalWrite(MOTOR_A_PIN, OFF);
    digitalWrite(MOTOR_B_PIN, OFF);
    colourMode = Serial.read();
    stepperA.setSpeed(60);
  }
  initialMode = true;
}

void receiveData()
{
    data = Serial.read();
    Serial.println("BYTE RECEIVED");
    Serial.println("SENDING CHECK");
    Serial.println(data);
    dataValidStr = Serial.read();
    if(dataValidStr == "DATA VALID")
        dataValid = true;
    else
        dataValid = false;
}

void unpackDataAndEngrave()
{
    if(colourMode == "BW MODE")
    {
        byte bit=0;

        //extract bits to form pixels and engrave bit by bit
        for(int i=0;i<8;i++)
        {
            bit = bitRead(data.toInt(), 7-i);
            engrave(bit);
        }
        Serial.println("PIXELS DONE");
    }
    else if(colourMode == "GS MODE")
    {
        byte bit=0;
        String pixelString = "";

        //extract the 4 most significant bits to form the first pixel
        for(int i=0;i<4;i++)
        {
            bit = bitRead(data.toInt(), 7-i);
            pixelString += bit;
        }

        bit = binaryToInt(pixelString);
        pixelString = "";
        engrave(bit);
        //Serial.println("Bit:");
        //Serial.println(bit);

        //extract the 4 least significant bits to form the second pixel
        for(int i=4;i<8;i++)
        {
            bit = bitRead(data.toInt(), 7-i);
            pixelString += bit;
        }

        bit = binaryToInt(pixelString);
        pixelString = "";
        //Serial.println("Bit:");
        //Serial.println(bit);
        engrave(bit);

        Serial.println("PIXELS DONE");
    }
}

/*
void receiveData()
{
  data = Serial.read();
  if(data != "DONE")
  {
      if(colourMode == "BW MODE")
      {
        //picArrayBW[arrayIndex] = data.toInt();
        arrayIndex++;
        sum++;
      }
      else if(colourMode == "GS MODE") 
      {
        //picArrayGS[arrayIndex] = data.toInt();
        arrayIndex++;
        sum++;
      }
      Serial.println("BYTE RECEIVED");
  }
  else if(data == "DONE")
  {
      dataComplete = true;
  }
  
}

bool checkData()
{
    checkSum = Serial.read();

    if (sum == checkSum)
    {
        dataValid = true;
        Serial.println("DATA VALID");
    }
    else 
    {
        Serial.println("DATA INVALID");
        dataComplete = false;
        while(Serial.read() != "RESEND DATA");
    }
    
}

void unpackDataAndEngrave()
{
    if(colourMode == "BW MODE")
    {
        byte bit=0;

        //extract bits to form pixels and engrave bit by bit
        for(int i=0;i<8;i++)
        {
            //bit = bitRead(picArrayBW[pixelIndex], 7-i);
            engrave(bit);
        }
    }
    else if(colourMode == "GS MODE")
    {
        byte bit=0;
        String pixelString = "";

        //extract the 4 most significant bits to form the first pixel
        for(int i=0;i<4;i++)
        {
            //bit = bitRead(picArrayGS[pixelIndex], 7-i);
            pixelString += bit;
        }

        bit = binaryToInt(pixelString);
        pixelString = "";
        engrave(bit);
        //Serial.println("Bit:");
        //Serial.println(bit);

        //extract the 4 least significant bits to form the second pixel
        for(int i=4;i<8;i++)
        {
            //bit = bitRead(picArrayGS[pixelIndex], 7-i);
            pixelString += bit;
        }

        bit = binaryToInt(pixelString);
        pixelString = "";
        //Serial.println("Bit:");
        //Serial.println(bit);
        engrave(bit);
    }
}
*/
void engrave(byte bit)
{
    if(bit > 0)
       turnOnLaser(bit);
    
    if(pixelCount%199 == 0)
    {
        down();
        rowCount++;
    }
    else if(rowCount%2 == 0)
    {
        left();
        pixelCount++;
    }
    else
    {
        right();
        pixelCount++;
    }

}

void turnOnLaser(byte bit)
{
    Serial.println("laser!!");
}

int binaryToInt(String data)
{
    if (data == "0000")
        return 0;
    else if (data == "0001")
        return 1;
    else if (data == "0010")
        return 2;
    else if (data == "0011")
        return 3;
    else if (data == "0100")
        return 4;
    else if (data == "0101")
        return 5;
    else if (data == "0110")
        return 6;
    else if (data == "0111")
        return 7;
    else
        return 0;
}

bool checkEngraveDone()
{
    engraveDoneStr = Serial.read();
    if(engraveDoneStr == "DONE")
        return true;
    else 
    {
        Serial.println("SEND NEXT BYTE");
        return false;
    } 
}

/*
 * Motor functions
 */
void right()
{
    Serial.println("right");
    //stepperA(1);
}

void left()
{
    Serial.println("left");
    //stepperA(-1);
}

void up()
{
    Serial.println("up");
    //stepperB(1);
}

void down()
{
    Serial.println("down");
    //stepperB(-1);
}

/*
 * Emergency Stop 
 */
void emergencyStop()
{
    digitalWrite(LASER_PIN, OFF);
    digitalWrite(MOTOR_A_PIN, OFF);
    digitalWrite(MOTOR_B_PIN, OFF);
}
