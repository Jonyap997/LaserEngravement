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
