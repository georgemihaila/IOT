# 200W RGBW Room Light

## Introduction

This is a room light made out of 4 50W LEDs, controlled with an ESP8266. The LEDs are cooled automatically, based on their heatsink's temperature.

## Materials used

-[4 x 50W LEDs (Red, Green, Blue, White)](https://www.aliexpress.com/item/10W-20W-30W-50W-100W-RGB-LED-light-COB-Integrated-Diodes-chip-lamp-Bulb-For-Flood/32822751209.html?spm=a2g0s.9042311.0.0.15e74c4djlJp3c) - $13.2

-[1 x ESP8266](https://www.aliexpress.com/item/5pcs-lot-New-Wireless-module-NodeMcu-Lua-WIFI-Internet-of-Things-development-board-based-ESP8266-with/32266751149.html?spm=2114.search0104.3.1.1365d8ea9V7yFz&ws_ab_test=searchweb0_0,searchweb201602_5_10152_10151_10065_10344_10068_10342_10343_10340_10341_10696_10084_10083_10618_5723416_10304_10307_10820_10821_10301_10059_100031_10103_10624_10623_10622_10621_10620,searchweb201603_35,ppcSwitch_2&algo_expid=0e6207e9-9c50-4b29-acea-dbf44940dc64-3&algo_pvid=0e6207e9-9c50-4b29-acea-dbf44940dc64&transAbTest=ae803_2&priceBeautifyAB=0) - $2.71

-[4 x 40mm 12V fans](https://www.aliexpress.com/item/2Pcs-12V-Mini-Computer-Fans-Cooling-Small-40mm-x-10mm-DC-Brushless-with-2-pin-HOT/32844651460.html?spm=2114.search0104.3.9.6f3b198d1quB5n&ws_ab_test=searchweb0_0,searchweb201602_5_10152_10151_10065_10344_10068_10342_10343_10340_10341_10696_10084_10083_10618_5723416_10304_10307_10820_10821_10301_10059_100031_10103_10624_10623_10622_10621_10620,searchweb201603_35,ppcSwitch_2&algo_expid=8cccce9c-e250-4fac-956d-4ea3203e76a2-1&algo_pvid=8cccce9c-e250-4fac-956d-4ea3203e76a2&transAbTest=ae803_2&priceBeautifyAB=0) - $3.22

-[4 x 60x150x25mm aluminum heatsinks](https://www.aliexpress.com/item/Aluminum-Heatsink-Cooling-Fin-150mmx60mmx25mm-for-Power-Amplifier/32788936024.html?spm=2114.search0104.3.43.20ce6abdRRmob4&ws_ab_test=searchweb0_0,searchweb201602_5_10152_10151_10065_10344_10068_10342_10343_10340_10341_10696_10084_5723415_10083_10618_10304_10307_10820_10821_10301_10059_100031_10103_10624_10623_10622_10621_10620,searchweb201603_35,ppcSwitch_2&algo_expid=0eea2dd1-f3b5-4757-8a55-af34012056f6-9&algo_pvid=0eea2dd1-f3b5-4757-8a55-af34012056f6&transAbTest=ae803_2&priceBeautifyAB=0) - $18.64

Note: I actually use 40x140x20mm heatsinks for this project, but I can't find any on AliExpress. I got them at a local store for ~ $10

-[4 x DS18B20 temperature sensors](https://www.aliexpress.com/item/5PCS-DALLAS-DS18B20-18B20-18S20-TO-92-IC-CHIP-Thermometer-Temperature-Sensor/32798161162.html?spm=2114.search0104.3.23.351d1320MO3HXJ&ws_ab_test=searchweb0_0,searchweb201602_5_10152_10151_10065_10344_10068_10342_10343_10340_10341_10696_10084_10083_10618_5723416_10304_10307_10820_10821_10301_10059_100031_10103_10624_10623_10622_10621_10620,searchweb201603_35,ppcSwitch_2&algo_expid=a59a1c52-b9e7-40c1-ae6b-cb4804b1b2a6-3&algo_pvid=a59a1c52-b9e7-40c1-ae6b-cb4804b1b2a6&transAbTest=ae803_2&priceBeautifyAB=0) - $2.8

-[2 x LM2596 step down converters](https://www.aliexpress.com/item/2pcs-Ultra-small-LM2596-power-supply-module-DC-DC-BUCK-3A-adjustable-buck-module-regulator-ultra/32650623174.html?spm=a2g0s.9042311.0.0.4d7b4c4duRWgdF) used for stepping down the voltage for the ESP8266 and for the fans - $1.96

-[8 x IRLZ44N transistors](https://www.aliexpress.com/item/10PCS-IRLZ44N-TO-220-IRLZ44-TO220-IRLZ44NPBF-free-shipping/32714396199.html?spm=2114.search0104.3.2.41071aa8ZtDUjY&ws_ab_test=searchweb0_0,searchweb201602_5_10152_10151_10065_10344_10068_10342_10343_10340_10341_10696_10084_10083_10618_5723416_10304_10307_10820_10821_10301_10059_100031_10103_10624_10623_10622_10621_10620,searchweb201603_35,ppcSwitch_2&algo_expid=b0d07a92-f964-441a-af34-80062b9d78d7-0&algo_pvid=b0d07a92-f964-441a-af34-80062b9d78d7&transAbTest=ae803_2&priceBeautifyAB=0) - $1.88

I chose these transistors because they have a low gate threshold voltage and the ESP8266's 3.3V can open them up more than necessary.

-[1 x 36V 10A power supply](https://www.aliexpress.com/item/DC12V-13-8V-15V-18V-24V-27V-28V-30V-32V-36V-42V-48V-60V-300W-350W/32849922581.html?spm=2114.search0104.3.1.19e05dbfvvORiL&ws_ab_test=searchweb0_0,searchweb201602_5_10152_10151_10065_10344_10068_10342_10343_10340_10341_10696_10084_10083_10618_5723416_10304_10307_10820_10821_10301_10059_100031_10103_10624_10623_10622_10621_10620,searchweb201603_35,ppcSwitch_2&algo_expid=ff102518-3483-414b-b2ce-870eefac13b8-0&algo_pvid=ff102518-3483-414b-b2ce-870eefac13b8&transAbTest=ae803_2&priceBeautifyAB=0) - $37.90

Even though the LEDs will draw 6-7A at their max, I chose an overpowered power source to be safe.

-[a prototype PCB](https://www.aliexpress.com/item/10Pcs-DIY-Prototype-Paper-PCB-Universal-Experiment-Matrix-Circuit-Board-5x7CM/32546265487.html?spm=a2g0s.9042311.0.0.7cfd4c4dPVdktJ)

Total: $82

## Setup

After drilling 4 holes in each heatsink, applying thermal paste and fixing them with nuts and bolts, I realized I was lucky with the heatsink size, because they were exactly as wide as the LEDs.

![led](https://github.com/georgemihaila/IOT/blob/master/200W%20RGBW%20Room%20Light/assets/20180717_195816.jpg)
