using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_App.IOT.API.RGBWWLED
{
    [Serializable]
    public class RGBWWLEDConfiguration
    {
        /// <summary>
        /// Creates a new instance of the RGBWWLEDConfiguration class.
        /// </summary>
        public RGBWWLEDConfiguration()
        {

        }

        /// <summary>
        /// Creates a new instance of the RGBWWLEDConfiguration class.
        /// </summary>
        /// <param name="PWMValues">The LEDs' PWM values.</param>
        /// <param name="vumeterConfiguration">The vumeter configuration.</param>
        public RGBWWLEDConfiguration(int[] PWMValues, VumeterConfiguration vumeterConfiguration) : this()
        {
            this.PWMValues = PWMValues;
            this.VumeterConfiguration = vumeterConfiguration;
        }

        /// <summary>
        /// Gets or sets the LED PWM values.
        /// </summary>
        public int[] PWMValues { get; set; }

        /// <summary>
        /// Gets or sets the vumeter configuration.
        /// </summary>
        public VumeterConfiguration VumeterConfiguration { get; set; }
    }
}
