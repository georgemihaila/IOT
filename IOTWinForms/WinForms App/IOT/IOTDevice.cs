using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_App.IOT
{
    [Serializable]
    public class IOTDevice
    {
        /// <summary>
        /// Creates a new instance of the IOTDevice class.
        /// </summary>
        public IOTDevice()
        {

        }

        /// <summary>
        /// Creates a new instance of the IOTDevice class.
        /// </summary>
        /// <param name="Name">The name of the IOT device.</param>
        /// <param name="IPAddress">The IP address of the IOT device.</param>
        public IOTDevice(string Name, string IPAddress) : this()
        {
            this.Name = Name;
            this.IPAddress = IPAddress;
        }
        #region Properties

        /// <summary>
        /// Gets or sets the name of the IOT device.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the IP address of the IOT device.
        /// </summary>
        public string IPAddress { get; set; }

        #endregion
    }
}
