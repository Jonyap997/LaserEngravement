const int LASER_PIN = 13;
const int MOTOR_A_PIN = 3;
const int MOTOR_B_PIN = 4;
const int OFF = 0;
const int ON = 1;
bool initialMode = false;
long laserInitialPosition = 0;

void setup() {
  // put your setup code here, to run once:
  pinMode(LASER_PIN, OUTPUT);
  pinMode(MOTOR_A_PIN, OUTPUT);
  pinMode(MOTOR_B_PIN, OUTPUT);
  initialSettings();

  Serial begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  string data, checksum;
  bool dataValidity = false,dataValid = false;

  do while //verify data
  {
    data =  waitForData();
    Serial.println("READY FOR CHECKSUM");
    checksum = waitForData();
    dataValidity = checkData(data,checksum);
    if (!dataValidity)
      Serial.println("RESEND");
    else
    {
      Serial.println("DATA VALID");
      dataValid = true;
    }
  }(!dataValid);

  //Engraving starts here
  for(int i=0; i < strlen(data); i++)
  {
    dataChar = data.charAt(i);
    engrave(dataChar);
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
  }
  initialMode = true;
}

bool checkData(string data, int checksum)
{
  char dataChar = '0';
  int dataNum = 0;
  for(int i=0; i < strlen(data); i++)
  {
    dataChar = data.charAt(i);
    dataNum += (int)dataChar;
  }

  if (dataNum == checksum)
    return true;
  else
    return false;
}

string waitForData()
{
    string data;
    while(!Serial.available());
    data = Serial.readstring();
    return data;
}

void engrave(char pixel)
{
  switch(pixel)
  {
    case '0':
      //pass by
      break;
    case '1':
      //turn laser on
      break;   
    case '2':
      //turn laser on
      break; 
    case '3':
      //turn laser on
      break; 
    case '4':
      //turn laser on
      break; 
    case '5':
      //turn laser on
      break; 
    case '6':
      //turn laser on
      break; 
    case '7':
      //turn laser on
      break; 
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
