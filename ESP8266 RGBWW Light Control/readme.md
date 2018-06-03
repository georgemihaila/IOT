This is the code that is running on an ESP8266 that is controling an RGBWW light.

API description:

**Turning on all LEDs**

http://ESP8266_IP/**on**

**Turning off all LEDs**

http://ESP8266_IP/**off**

**Soft resetting the MCU**

http://ESP8266_IP/**restart**

**Setting the PWM duty cycle for an LED (must be a value between 0 and 1023)**

http://ESP8266_IP/**pwm**/***led_name=duty_cycle***

LED name list:

cw - Cold white

r - Red

g - Green

b - Blue

ww - Warm white

**Example request:**

http://ESP8266_IP/**pwm**/***cw=422&r=1023&b=255***

Multiple parameters are optional.

**Turning on/off the vumeter**

http://ESP8266_IP/**vumeter**

**Setting the vumeter minimum and maximum threshold (manual sensitivity calibration)**

http://ESP8266_IP/**setvumeter**?***min=value0&max=value1***
