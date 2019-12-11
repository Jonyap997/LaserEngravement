#include <Stepper.h>
 
const int LASER_PIN = 3;
const int LIMIT_SWITCH = 2;
//const int STOP_PIN = 3;
const int OFF = 0;
const int ON = 1;
const int ROW = 8;
const int COL = 8;
const int BW_PIXEL_PER_BYTE = 8;
const int GS_PIXEL_PER_BYTE = 2;
const int BW_NUM_OF_ELEMENTS = (ROW * COL) / BW_PIXEL_PER_BYTE;
const int GS_NUM_OF_ELEMENTS = (ROW * COL) / GS_PIXEL_PER_BYTE;
const int STEPS_PER_REVOLUTION = 200;

bool initialDone = false, dataValid = false, engraveDone = false, dataReceived = false, dataValidated = false, dataCheck = false, engraveCheck = false;
bool receiveDataFlag = true, engraveDataFlag = false, pixelDoneFlag = false, checkEngraveFlag = false, atInitial = false;
String colourMode,data, dataValidStr, engraveDoneStr, checkSerialConnection, checkReady, checkData, pixelCheckDone, sendNextByte;
int pixelCount=1, rowCount=1, pixelInPacket=0;

Stepper stepperA(STEPS_PER_REVOLUTION, 4, 5, 6, 7);
Stepper stepperB(STEPS_PER_REVOLUTION, 8, 9, 10, 11);

void setup() {
  // put your setup code here, to run once:
  pinMode(LASER_PIN, OUTPUT);
  digitalWrite(LASER_PIN, OFF);
  
  attachInterrupt(digitalPinToInterrupt(LIMIT_SWITCH), limitSwitchHit, LOW);
  //attachInterrupt(digitalPinToInterrupt(STOP_PIN), emergencyStop, RISING);
  stepperA.setSpeed(60);
  stepperB.setSpeed(60);
  pixelCount = 1;
  rowCount = 1;
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
   
    if (!atInitial)
    {
        goToInitial();
    }
    else if (!initialDone)
    {
        initialSettings();
    }
    else if(!engraveDone)
    {
        if (receiveDataFlag)
            receiveData();
        
        if(engraveDataFlag)
        {
            if (!pixelDoneFlag)
                unpackDataAndEngrave();
            else
                pixelDoneChecker();
        }
        if (checkEngraveFlag)
            checkEngraveDone();
    }
    else
    {
        restoreOriginalState();
    }
    
}

/*
 * Initial settings
 */

void initialSettings()
{
    if (!compareString(checkSerialConnection, "READY") && !compareString(checkSerialConnection, "1") && !compareString(checkSerialConnection, "2"))
    {
        checkSerialConnection = Serial.readString();
    }
        
    if (compareString(checkSerialConnection, "READY"))
        checkSerialConnection = "1";

    if (compareString(checkSerialConnection, "1"))
    {
        Serial.println("READY");
        checkReady = Serial.readString();
    }

    if (compareString(checkReady, "READY FOR COLOUR MODE"))
    {
        checkSerialConnection = "2";
        Serial.println("READY FOR COLOUR MODE");
        colourMode = Serial.readString();
        if (compareString(colourMode, "BW MODE")|| compareString(colourMode, "GS MODE"))
        {
            stepperA.setSpeed(60); 
            initialDone = true;

            checkSerialConnection = "";
            checkReady = "";
            
        }
    }
}

void receiveData()
{
    if (dataReceived)
    {
        if (!dataCheck)
            Serial.println("BYTE RECEIVED");

        checkData = Serial.readString();
        if (compareString(checkData, "CHECK RECEIVED"))
        {       
            dataValidated = true;
            dataReceived = false;
            dataCheck = false;
        }
        else if (compareString(checkData, "READY FOR CHECK") || dataCheck)
        {
            Serial.println(data);
            dataCheck = true;
        }
        
    }
    else if (!dataReceived && !dataValidated)
    {
        Serial.println("READY TO RECEIVE DATA");
        
        data = Serial.readString();
        if (isNumeric(data))
        {
            if (data.toInt() >= 0 && data.toInt() <= 255)
                dataReceived = true;
        }
            
    }

    if (dataValidated)
    {
        Serial.println("READY TO RECEIVE VALIDITY");
        dataValidStr = Serial.readString();
        if (compareString(dataValidStr, "DATA VALID"))
        {
            receiveDataFlag = false;
            engraveDataFlag = true;
            dataReceived = false;
            dataValidated = false;
            dataValidStr = "";
        }
        else if (compareString(dataValidStr, "DATA INVALID"))
        {
            dataReceived = false;
            dataValidated = false;
            dataValidStr = "";
        }
    }
}

void unpackDataAndEngrave()
{
    //Serial.println("STARTED ENGRAVING");
    if(compareString(colourMode, "BW MODE"))
    {
        byte bit=0;

        //extract bits to form pixels and engrave bit by bit
        if (pixelInPacket < 8)
        {
            bit = bitRead(data.toInt(), (7 - pixelInPacket));
            engrave(bit);
            pixelInPacket++;
            
        }
        else
        {
            pixelInPacket = 0;
            pixelDoneFlag = true;
        }
        
        
    }/*
    else if(compareString(colourMode, "GS MODE"))
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

        //extract the 4 least significant bits to form the second pixel
        for(int i=4;i<8;i++)
        {
            bit = bitRead(data.toInt(), 7-i);
            pixelString += bit;
        }

        bit = binaryToInt(pixelString);
        pixelString = "";
        engrave(bit);

        pixelDoneFlag = true;
    }*/
}

bool compareString(String compare, String keyword)
{
    if (compare.indexOf(keyword) > -1)
        return true;
    else
        return false;
}

bool isNumeric(String str)
{
    bool bPoint=false;
    str.trim();
    if(str.length()<1)
    {
        return false;
    }
    
    for(unsigned char i = 0; i < str.length(); i++)
    {
        
        if ( !(isDigit(str.charAt(i)) || str.charAt(i) == '.' )|| bPoint) 
        {
            return false;
        }
        if(str.charAt(i) == '.')
        {
            bPoint=true;
        }
    }
    return true;
}

void restoreOriginalState()
{
    atInitial = false;
    initialDone = false;
    engraveDone = false;
    dataValid = false;
    dataReceived = false;
    dataValidated = false;
    dataCheck = false;
    engraveCheck = false;
    receiveDataFlag = true;
    engraveDataFlag = false;
    pixelDoneFlag = false;
    checkEngraveFlag = false;
    pixelCount = 1;
    rowCount = 1;
    pixelInPacket = 0;
    colourMode = "";
    data = "";
    dataValidStr = "";
    engraveDoneStr = "";
    checkSerialConnection = "";
    checkReady = "";
    checkData = "";
    pixelCheckDone = "";
    sendNextByte = "";
    attachInterrupt(digitalPinToInterrupt(LIMIT_SWITCH), limitSwitchHit, LOW);

}

void pixelDoneChecker()
{
    Serial.println("PIXELS DONE");

    pixelCheckDone = Serial.readString();

    if (compareString(pixelCheckDone, "PIXELS DONE"))
    {
        pixelCheckDone = "";
        engraveDataFlag = false;
        checkEngraveFlag = true;
        pixelDoneFlag = false;   
    }
}

void engrave(byte bit)
{
    if(bit > 0)
       turnOnLaser(bit);
    
    if(pixelCount%COL == 0)
    {
        down();
        rowCount++;
    }
    else if(rowCount%2 == 0)
    {
        left();
    }
    else
    {
        right();
    }
    pixelCount++;

}

void turnOnLaser(byte bit)
{
    if(compareString(colourMode, "BW MODE"))
    {
        analogWrite(LASER_PIN,255);
    }
    else
    {
        analogWrite(LASER_PIN,map(bit,0,7,0,255));
    }

    delay(750);
    analogWrite(LASER_PIN,0);
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
    if (!engraveCheck)
    {
        Serial.println("DONE?");
        engraveDoneStr = Serial.readString();
    }
        
    if(compareString(engraveDoneStr,"DONE"))
    {
        engraveDone = true;
    }        
    else if(compareString(engraveDoneStr,"NOPE") || engraveCheck)
    {
        engraveCheck = true;
        Serial.println("SEND NEXT BYTE");
        sendNextByte = Serial.readString();
        
        if (compareString(sendNextByte,"SEND NEXT BYTE"))
        {
            engraveCheck = false;
            checkEngraveFlag = false;
            receiveDataFlag = true;
            engraveDoneStr = "";
            sendNextByte = "";
            engraveDone = false;
        }
    } 
}

/*
 * Motor functions
 */
void right()
{
    stepperA.step(3);
    delay(500);
}

void left()
{
    stepperA.step(-3);
    delay(500);
}

void up()
{
    stepperB.step(-3);
    delay(500);
}

void down()
{
    stepperB.step(3);
    delay(500);
}

void goToInitial()
{
    stepperB.step(-STEPS_PER_REVOLUTION);
}

void limitSwitchHit()
{
    detachInterrupt(digitalPinToInterrupt(LIMIT_SWITCH)); 
    atInitial = true;
}

/*
 * Emergency Stop 
 */
void emergencyStop()
{
    digitalWrite(LASER_PIN, OFF);
    restoreOriginalState();
}
