
const int LASER_PIN = 13;
const int MOTOR_A_PIN = 3;
const int MOTOR_B_PIN = 4;
const int OFF = 0;
const int ON = 1;
const int ROW = 100;
const int COL = 200;
const int BW_PIXEL_PER_BYTE = 8;
const int GS_PIXEL_PER_BYTE = 2;
const int BW_NUM_OF_ELEMENTS = (ROW * COL) / BW_PIXEL_PER_BYTE;
const int GS_NUM_OF_ELEMENTS = (ROW * COL) / GS_PIXEL_PER_BYTE;

bool initialMode = false;
long laserInitialPosition = 0;
int arrayIndex=0;
bool dataComplete = false, dataValid = false;
int picArrayGS[GS_NUM_OF_ELEMENTS];
int picArrayBW[BW_NUM_OF_ELEMENTS];
String colourMode,data;
int checkSum, sum = 0, pixelIndex=0, pixelCount=1, rowCount=1;

void setup() {
  // put your setup code here, to run once:
  pinMode(LASER_PIN, OUTPUT);
  pinMode(MOTOR_A_PIN, OUTPUT);
  pinMode(MOTOR_B_PIN, OUTPUT);
  Serial.begin(9600);
  initialSettings();
  
}

void loop() {
  // put your main code here, to run repeatedly:

    //Serial.println(i);
    //i++;
    //delay(1000);
    
    if(!dataComplete)
    {
        receiveData();  
    }
    else if (!dataValid)
    {
        checkData();
    }
    else
    {
        unpackDataAndEngrave();
        pixelIndex++;
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
  }
  initialMode = true;
}

void receiveData()
{
  data = Serial.read();
  if(data != "DONE")
  {
      if(colourMode == "BW MODE")
      {
        picArrayBW[arrayIndex] = data.toInt();
        arrayIndex++;
        sum++;
      }
      else if(colourMode == "GS MODE") 
      {
        picArrayGS[arrayIndex] = data.toInt();
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
        for(int i=0;i<8;i++)
        {
            bit = bitRead(picArrayBW[pixelIndex], i);
            engrave(bit);
        }
    }
    else if(colourMode == "GS MODE")
    {
        byte bit=0;
        String pixelString = "";
        for(int i=0;i<4;i++)
        {
            bit = bitRead(picArrayGS[pixelIndex], i);
            pixelString += bit;
        }

        bit = binarytoInt(pixelString);
        engrave(bit);

        for(int i=4;i<8;i++)
        {
            bit = bitRead(picArrayGS[pixelIndex], i);
            pixelString += bit;
        }

        bit = binarytoInt(pixelString);
        engrave(bit);
    }
}

void engrave(byte bit)
{

    if(bit > 0)
    {
       turnOnLaser(bit);
    }
    
    if(pixelCount%200 == 0)
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
    
}

int binaryToInt(string data)
{
    switch(data)
    {
        case "0000":
          return 0;
        case "0001":
          return 1;
        case "0010":
          return 2;
        case "0011":
          return 3;
        case "0100":
          return 4;
        case "0101":
          return 5;
        case "0110":
          return 6;
        case "0111":
          return 7;
        default:
          return 0;
    }
}

/*
 * Motor functions
 */
void right(int greyScale)
{
  
}

void left(int greyScale)
{
  
}

void up(int greyScale)
{
    
}

void down(int greyScale)
{
  
}
