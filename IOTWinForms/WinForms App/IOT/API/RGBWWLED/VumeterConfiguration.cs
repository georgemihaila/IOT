using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_App.IOT.API.RGBWWLED
{
    [Serializable]
    public class VumeterConfiguration
    {
        /// <summary>
        /// Creates a new instance of the VumeterConfiguration class.
        /// </summary>
        public VumeterConfiguration()
        {

        }

        /// <summary>
        /// Creates a new instance of the VumeterConfiguration class.
        /// </summary>
        /// <param name="LoopSkip">The number of loops that the vumeter should skip.</param>
        /// <param name="Minimum">The minimum threshold value for the vumeter.</param>
        /// <param name="Maximum">The maximum threshold value for the vumeter.</param>
        public VumeterConfiguration(int LoopSkip, int Minimum, int Maximum) : this()
        {
            this.LoopSkip = LoopSkip;
            this.Maximum = Maximum;
            this.Minimum = Minimum;
        }

        /// <summary>
        /// Gets or sets the number of loops that the vumeter should skip. Warning: a too low value can result in the device disconnecting from the network.
        /// </summary>
        public int LoopSkip { get; set; }

        /// <summary>
        /// Gets or sets the minimum threshold value for the vumeter.
        /// </summary>
        public int Minimum { get; set; }

        /// <summary>
        /// Gets or sets the maximum threshold value for the vumeter.
        /// </summary>
        public int Maximum { get; set; }
    }
}
