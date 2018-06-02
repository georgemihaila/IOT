#include "PWMAnimations.h"

const int PWMMinLevel = 0;
const int PWMMaxLevel = 1023;
const int PWMPins[] = { 16, 12, 14, 13, 15 };

void setupPWM() {
	for (int ledIndex = 0; ledIndex < 5; ledIndex++) {
		pinMode(PWMPins[ledIndex], OUTPUT);
	}
}

void turnOnAll() {
	for (int ledIndex = 0; ledIndex < 5; ledIndex++) {
		analogWrite(PWMPins[ledIndex], PWMMaxLevel);
	}
}

void turnOffAll() {
	for (int ledIndex = 0; ledIndex < 5; ledIndex++) {
		analogWrite(PWMPins[ledIndex], PWMMinLevel);
	}
}

void minMaxAll(int time, bool reverse) {
	for (int pwmlevel = PWMMinLevel; pwmlevel < PWMMaxLevel; pwmlevel++) {
		for (int ledIndex = 0; ledIndex < 5; ledIndex++) {
			analogWrite(PWMPins[ledIndex], pwmlevel);
		}
		delayMicroseconds(time);
	}
	if (reverse) {
		for (int pwmlevel = PWMMaxLevel; pwmlevel >= PWMMinLevel; pwmlevel--) {
			for (int ledIndex = 0; ledIndex < 5; ledIndex++) {
				analogWrite(PWMPins[ledIndex], pwmlevel);
			}
			delayMicroseconds(time);
		}
	}
}