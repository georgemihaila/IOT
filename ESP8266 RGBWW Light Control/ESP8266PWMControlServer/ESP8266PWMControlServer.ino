#include <ESP8266WebServerSecure.h>
#include <ESP8266WiFi.h>

#define PWM_Min 0
#define PWM_Max 1023

#define SSID "George"
#define Password "$"

ESP8266WebServer server(80);;

byte ledPins[] = { 14, 15, 16, 12, 13 };
int pwmValues[] = { 0, 0, 0, 0, 0 };

float vuMin = 56;
float vuMax = 228;
bool vumeter = false;

void ydelayms(int millisecondDelay) {
	delay(millisecondDelay);
	yield();
}

void ydelayus(int microsecondDelay) {
	delayMicroseconds(microsecondDelay);
	yield();
}

void turnOnLED(int index) {
	analogWrite(ledPins[index], PWM_Min);
	pwmValues[index] = PWM_Min;
}

void turnOffLED(int index) {
	analogWrite(ledPins[index], PWM_Max);
	pwmValues[index] = PWM_Max;
}

void turnOffAllLEDs() {
	for (int i = 0; i < 5; i++) {
		turnOffLED(i);
	}
}

void turnOffAllLEDs_Server() {
	for (int i = 0; i < 5; i++) {
		turnOffLED(i);
	}
	server.send(200, "text/plain", "LEDs off");
}

void turnOnAllLEDs() {
	for (int i = 0; i < 5; i++) {
		turnOnLED(i);
	}
}

void turnOnAllLEDs_Server() {
	for (int i = 0; i < 5; i++) {
		turnOnLED(i);
	}
	server.send(200, "text/plain", "LEDs on");
}

void setupLEDs() {
	for (int i = 0; i < 5; i++) {
		pinMode(ledPins[i], OUTPUT);
		turnOffLED(i);
	}
}

void handlePWMRequest_Server() {
	bool handled = false;
	for (int i = 0; i < server.args(); i++) {
		String argName = server.argName(i);
		String argValue = server.arg(i);
		int argAsInt = atoi(argValue.c_str());
		if (argName == "cw") {
			for (int i = pwmValues[0]; (pwmValues[0] <= argAsInt) ? i < argAsInt : i >= argAsInt; (pwmValues[0] < argAsInt) ? i++ : i--) {
				analogWrite(ledPins[0], i);
				ydelayus(50);
			}
			pwmValues[0] = argAsInt;
			handled = true;
		}
		else if (argName == "r") {
			for (int i = pwmValues[1]; (pwmValues[1] <= argAsInt) ? i < argAsInt : i >= argAsInt; (pwmValues[1] < argAsInt) ? i++ : i--) {
				analogWrite(ledPins[1], i);
				ydelayus(50);
			}
			pwmValues[1] = argAsInt;
			handled = true;
		}
		else if (argName == "g") {
			for (int i = pwmValues[2]; (pwmValues[2] <= argAsInt) ? i < argAsInt : i >= argAsInt; (pwmValues[2] < argAsInt) ? i++ : i--) {
				analogWrite(ledPins[2], i);
				ydelayus(50);
			}
			pwmValues[2] = argAsInt;
			handled = true;
		}
		else if (argName == "b") {
			for (int i = pwmValues[3]; (pwmValues[3] <= argAsInt) ? i < argAsInt : i >= argAsInt; (pwmValues[3] < argAsInt) ? i++ : i--) {
				analogWrite(ledPins[3], i);
				ydelayus(50);
			}
			pwmValues[3] = argAsInt;
			handled = true;
		}
		else if (argName == "ww") {
			for (int i = pwmValues[4]; (pwmValues[4] <= argAsInt) ? i < argAsInt : i >= argAsInt; (pwmValues[4] < argAsInt) ? i++ : i--) {
				analogWrite(ledPins[4], i);
				ydelayus(50);
			}
			pwmValues[4] = argAsInt;
			handled = true;
		}
	}

	if (!handled) {
		server.send(400, "text/plain", "Wrong arguments.");
	}
	else {
		server.send(200, "text/plain", "OK");
	}
}

void handleRestart_Server() {
	server.send(200, "text/plain", "Restarting.");
	ESP.restart();
}

float mapValue(float minFrom, float maxFrom, float value, float minTo, float maxTo) {
	float Y = (((maxTo - minTo) / (maxFrom - minFrom)) * (value - minFrom));
	if (Y > maxTo) return maxTo;
	if (Y < minTo) return minTo;
	return Y;
}

void switchVumeter_Server() {
	vumeter = !vumeter;
	server.send(200, "text/plain", (vumeter) ? "vumeter on" : "vumeter off");
}

void setVumeter_Server() {
	for (int i = 0; i < server.args(); i++) {
		String argName = server.argName(i);
		String argValue = server.arg(i);
		int argAsInt = atoi(argValue.c_str());
		if (argName == "min") {
			vuMin = argAsInt;
		}
		else if (argName == "max") {
			vuMax = argAsInt;
		}
	}
	server.send(200, "text/plain", "set vumeter values");
}

void playWiFiConnectingAnimation(int time) {
	analogWrite(ledPins[3], PWM_Max);
	ydelayms(time);
	analogWrite(ledPins[3], PWM_Min);
	ydelayms(time);
}

ulong formerus = 0;

void setup() {
	setupLEDs();
	Serial.begin(9600);
	Serial.println("OK");
	WiFi.begin(SSID, Password);
	while (WiFi.status() != WL_CONNECTED) {
		playWiFiConnectingAnimation(75);
	}
	server.on("/on", turnOnAllLEDs_Server);
	server.on("/off", turnOffAllLEDs_Server);
	server.on("/pwm", handlePWMRequest_Server);
	server.on("/restart", handleRestart_Server);
	server.on("/vumeter", switchVumeter_Server);
	server.on("/setvumeter", setVumeter_Server);
	server.begin();
	for (int i = 0; i < 5; i++) {
		analogWrite(ledPins[i], 512);
		pwmValues[i] = 512;
	}
	pinMode(5, INPUT);
	formerus = micros();
}

int bpm = 130;
int currentVUMeterLevel = 0;
bool increaseVU = true;

void vuMeter() {
	/*ulong currentus = micros();
	if (currentus - formerus > 5000 * 1000) { //Reset min and max every 5 seconds
		formerus = currentus;
		vuMin = vuMax = analogRead(A0);
	}*/
	float current = analogRead(A0);/*
	if (current > vuMax) {
		vuMax = current;
		Serial.print("Reset vuMax to ");
		Serial.println(vuMax);
	}
	else if (current < vuMin) {
		vuMin = current;
		Serial.print("Reset vuMin to ");
		Serial.println(vuMin);
	}*/
	float delta = vuMax - vuMin;
	if (current >= abs(delta * 0 / 5)) {
		analogWrite(ledPins[0], mapValue(vuMin, vuMax, current, PWM_Min, PWM_Max));
		
	}
	else {
		analogWrite(ledPins[0], PWM_Min);
		
	}
	if (current >= abs(delta * 3.3 / 5)) {
		analogWrite(ledPins[1], mapValue(vuMin, vuMax, current, PWM_Min, PWM_Max));
		
	}
	else {
		analogWrite(ledPins[1], PWM_Min);
		
	}
	if (current >= abs(delta * 4.4 / 5)) {
		analogWrite(ledPins[2], mapValue(vuMin, vuMax, current, PWM_Min, PWM_Max));
		
	}
	else {
		analogWrite(ledPins[2], PWM_Min);
		
	}
	if (current >= abs(delta * 5.5 / 5)) {
		analogWrite(ledPins[3], mapValue(vuMin, vuMax, current, PWM_Min, PWM_Max));
		
	}
	else {
		analogWrite(ledPins[3], PWM_Min);
		
	}
	if (current >= abs(delta * 4.6 / 5)) {
		analogWrite(ledPins[4], mapValue(vuMin, vuMax, current, PWM_Min, PWM_Max));
		
	}
	else {
		analogWrite(ledPins[4], PWM_Min);
		
	}
	
}

int loops = 0;

void loop() {
	while (WiFi.status() != WL_CONNECTED) {
		playWiFiConnectingAnimation(75);
		vumeter = false;
	}
	server.handleClient();
	if (loops++ >= 150) {
		loops = 0;
		if (vumeter) {
			vuMeter();
		}
	}
}

/* METRONOME - NON-BLOCKING
ulong currentus = micros();
if (currentus - formerus > (bpm * 4) / (60 * 1024)) {
currentus = formerus;
currentVUMeterLevel = (increaseVU) ? currentVUMeterLevel + 1 : currentVUMeterLevel - 1;
if (currentVUMeterLevel == 1023 && increaseVU) {
increaseVU = false;
}
if (!increaseVU && currentVUMeterLevel == 0) {
increaseVU = true;
}
for (int i = 0; i < 5; i++) {
analogWrite(ledPins[i], currentVUMeterLevel);
}
yield();
}
*/
