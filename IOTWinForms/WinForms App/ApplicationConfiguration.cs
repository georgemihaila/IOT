using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_App
{
    [Serializable]
    public class ApplicationConfiguration
    {
        /// <summary>
        /// Creates a new instance of the ApplicationConfiguration class.
        /// </summary>
        public ApplicationConfiguration()
        {

        }

        /// <summary>
        /// Creates a new instance of the ApplicationConfiguration class.
        /// </summary>
        /// <param name="AutoSaveConfiguration">Whether to automatically save the configuration file on exit.</param>
        public ApplicationConfiguration(bool AutoSaveConfiguration) : this()
        {
            this.AutoSaveConfiguration = AutoSaveConfiguration;
        }

        /// <summary>
        /// Creates a new instance of the ApplicationConfiguration class.
        /// </summary>
        /// <param name="AutoSaveConfiguration">Whether to automatically save the configuration file on exit.</param>
        /// <param name="configuration">The RGBWW LED configuration.</param>
        public ApplicationConfiguration(bool AutoSaveConfiguration, IOT.API.RGBWWLED.RGBWWLEDConfiguration configuration) : this(AutoSaveConfiguration)
        {
            this.RGBWWLEDConfiguration = configuration;
        }
        /// <summary>
        /// Gets or sets whether to automatically save the configuration file on exit.
        /// </summary>
        public bool AutoSaveConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the RGBWW LED configuration.
        /// </summary>
        public IOT.API.RGBWWLED.RGBWWLEDConfiguration RGBWWLEDConfiguration { get; set; }
    }
}
