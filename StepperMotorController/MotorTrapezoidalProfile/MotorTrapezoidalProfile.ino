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

void trapezoidal() {
  int lim = (int)((float) (steps) / 3.0);
  float temp = 0;
  int delayTime = 0;
  float m1 = (float) ((minTime - maxTime) / (lim - 1));
  float b1 = (float) (minTime - m1 * lim);
  float m2 = (float) ((-minTime + maxTime) / (steps - 2*lim));
  float b2 = (float) (maxTime - m2 * steps);

  for (; i < steps; ++i) {
    if (i < lim) {
      temp = m1 * i + b1;
      delayTime = (int) temp;
      digitalWrite(stepPin, HIGH);
      delayMicroseconds(delayTime);
      digitalWrite(stepPin, LOW);
      delayMicroseconds(delayTime);
    }
    if (i > lim && i > lim * 2) {
      digitalWrite(stepPin, HIGH);
      delayMicroseconds(minTime);
      digitalWrite(stepPin, LOW);
      delayMicroseconds(minTime);
    }
    if (i > lim * 2) {
      temp = m2 * i + b2;
      delayTime = (int)(temp);  
      digitalWrite(stepPin, HIGH);
      delayMicroseconds(delayTime);
      digitalWrite(stepPin, LOW);
      delayMicroseconds(delayTime);s
    }
  }
}

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

  if (readSerial == false && direct == "CWS") {
      digitalWrite(LED_BUILTIN, HIGH);
      digitalWrite(dirPin, HIGH);
      if (steps < 50){
        for (; i < steps; ++i) {
          digitalWrite(stepPin, HIGH);
          delayMicroseconds(maxTime);
          digitalWrite(stepPin, LOW);
          delayMicroseconds(maxTime);  
        }
      } else {
        trapezoidal();
      }
      inParameters = "";
      readSerial = true;
    }

  if (readSerial == false && direct == "CCW") {
    digitalWrite(LED_BUILTIN, HIGH);
    digitalWrite(dirPin, LOW);
    if (steps < 50){
      for (; i < steps; ++i) {
        digitalWrite(stepPin, HIGH);
        delayMicroseconds(maxTime);
        digitalWrite(stepPin, LOW);
        delayMicroseconds(maxTime);  
      }  
    } else {
      trapezoidal();
    }
  }
  delay(5000);
}
