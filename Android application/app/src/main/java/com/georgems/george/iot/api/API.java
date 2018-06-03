package com.georgems.george.iot.api;

import android.widget.SeekBar;

public class API {
    public static class RGBWWControl {

        //region Properties

        public static String ESP8266RGBWWIpAddress = "http://10.1.0.101/";
        public static String[] ledName = {"Cold white", "Red", "Green", "Blue", "Warm white"};
        public static String[] ledName_Short = { "cw", "r", "g", "b", "ww" };
        public static final int PWM_Min = 0;
        public static final int PWM_Max = 1023;
        public static final int LEDCount = 5;
        public enum simpleCommand { turnAllLEDsOn, turnAllLEDsOff, restart }
        public enum led { cw, r, g, b, ww }

        //endregion

        //region Methods

        public static String createSimpleRequestString(simpleCommand command){
            String requestString = ESP8266RGBWWIpAddress;
            switch (command){
                case turnAllLEDsOn:
                    requestString += "on";
                    break;
                case turnAllLEDsOff:
                    requestString += "off";
                    break;
                case restart:
                    requestString += "restart";
                    break;
            }
            return requestString;
        }

        public static String createPWMRequestString(led[] leds, int[] values){
            String requestString = ESP8266RGBWWIpAddress + "pwm?";
            for (int i = 0; i < leds.length; i++){
                requestString += leds[i].toString() + "=" + values[i];
                if (i != leds.length - 1)
                    requestString += "&";
            }
            return  requestString;
        }

        public static String createPWMRequestString(SeekBar seekBar){
            return ESP8266RGBWWIpAddress + "pwm?" + ledName_Short[(int)seekBar.getTag()] + "=" + (1023 - seekBar.getProgress());
        }

        //endregion

    }
}
