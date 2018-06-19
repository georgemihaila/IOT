using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_App.IOT.API.RGBWWLED
{
    /// <summary>
    /// An API for managing an RGBWW LED.
    /// </summary>
    public class RGBWWLEDControl
    {
        /// <summary>
        /// Creates a new instance of the RGBWWLEDControl class.
        /// </summary>
        public RGBWWLEDControl()
        {

        }

        public enum LED { CW = 0, R, G, B, WW }
        public enum VumeterVariable { Vuloops, Vumin, Vumax }

        /// <summary>
        /// Turns off all the LEDs.
        /// </summary>
        /// <returns></returns>
        public async Task<string> TurnOffAsync()
        {
            return await DeviceRequestAsync("off");
        }

        /// <summary>
        /// Turns on all the LEDs.
        /// </summary>
        /// <returns></returns>
        public async Task<string> TurnOnAsync()
        {
            return await DeviceRequestAsync("on");
        }

        /// <summary>
        /// Sets an LED's duty cycle.
        /// </summary>
        /// <param name="led">The name of the LED.</param>
        /// <param name="value">The duty cycle of the LED.</param>
        /// <returns></returns>
        public async Task<string> SetLEDValueAsync(LED led, int value)
        {
            if (value < 0 || value > 1023)
                throw new ArgumentOutOfRangeException("The value must be a number between 0 and 1023.");
            return await DeviceRequestAsync("pwm?" + led.ToString().ToLower() + "=" + value);
        }

        /// <summary>
        /// Sets multiple LEDs' duty cycle.
        /// </summary>
        /// <param name="leds">The name of the LEDs.</param>
        /// <param name="values">The duty cycle for the LEDs.</param>
        /// <returns></returns>
        public async Task<string> SetLEDValueAsync(LED[] leds, int[] values)
        {
            if (leds.Length != values.Length)
                throw new ArgumentException("The leds length and the values length don't match.");
            if (leds.Length == 0) return "No led values changed because there were no arguments provided";
            foreach (int x in values)
                if (x < 0 || x > 1023)
                    throw new ArgumentOutOfRangeException("At least one of the values in the array is not a number between 0 and 1023.");
            string query = string.Empty;
            for (int i = 0; i < leds.Length; i++)
            {
                query += leds[i].ToString().ToLower() + "=" + values[i] + "&";
            }
            return await DeviceRequestAsync("pwm?" + query.Remove(query.Length - 1, 1));
        }

        /// <summary>
        /// Switches the vumeter on or off depending on its current state.
        /// </summary>
        /// <returns></returns>
        public async Task<string> SwitchVumeterAsync()
        {
            return await DeviceRequestAsync("vumeter");
        }
        
        /// <summary>
        /// Sets a vumeter variable's value.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<string> SetVumeterVariableAsync(VumeterVariable v, int value)
        {
            return await DeviceRequestAsync("setvumeter?" + v.ToString().ToLower() + "=" + value);
        }

        /// <summary>
        /// Creates a new instance of the RGBWWLEDControl class.
        /// </summary>
        /// <param name="device">The RGBWW device.</param>
        public RGBWWLEDControl(IOTDevice device) : this()
        {
            this.Device = device;
        }

        private async Task<string> DeviceRequestAsync(string query)
        {
            string url = Device.IPAddress;
            if (!url.StartsWith("http://"))
                url = url.Insert(0, "http://");
            url += "/" + query;
            string html = string.Empty;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            var response = await httpWebRequest.GetResponseAsync();
            var responseStream = response.GetResponseStream();
            using (System.IO.StreamReader reader = new System.IO.StreamReader(responseStream))
            {
                return reader.ReadToEnd();
            }
        }

        public IOTDevice Device { get; set; }
    }
}
