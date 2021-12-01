#define dirPin 2
#define stepPin 3
int i = 1;
int steps = 0;
bool readSerial = true;
String inParameters = "";
String direct = "";
int rev;
int angle = 0;
int maxRev = 5;
int stepsPerRev = 800;
int maxTime = 2000;
int minTime = 500;

void setup() {
  pinMode(stepPin, OUTPUT);
  pinMode(dirPin, OUTPUT);
  pinMode(LED_BUILTIN, OUTPUT);
  digitalWrite(dirPin, HIGH);
  Serial.begin(9600);
}

void trapezoidal() {}

void loop() {
  digitalWrite(LED_BUILTIN, LOW);
  if (Serial.available() > 0 && readSerial == true) {
    inParameters = Serial.readStringUntil('\n');
    while (inParameters.length() == 10){
      direct = inParameters.substring(0, 3);
      rev = inParameters.substring(4, 5).toInt();
      angle = inParameters.substring(6).toInt();

      if ((direct == "CWS" || direct == "CCW") && (rev >= 0 && rev <= maxRev)){
        digitalWrite(LED_BUILTIN, HIGH);
        delay(1000);
        digitalWrite(LED_BUILTIN, LOW);
        delay(1000);
        readSerial = false;
        steps = (rev * stepsPerRev) + (int)(((double)stepsPerRev / 360.0) * angle);
        i = 1;
        break;
      }      
    }
  }
}
