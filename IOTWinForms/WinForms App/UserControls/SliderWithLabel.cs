using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_App.UserControls
{
    public partial class SliderWithLabel : UserControl
    {
        /// <summary>
        /// Creates a new instance of the SliderWithLabel class.
        /// </summary>
        public SliderWithLabel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of the SliderWithLabel class.
        /// </summary>
        /// <param name="min">The minimum slider value.</param>
        /// <param name="max">The maximum slider value.</param>
        /// <param name="title">The title of the control.</param>
        public SliderWithLabel(int min, int max, string title) : this()
        {
            Minimum = min;
            Maximum = max;
        }

        private string _Title;
        /// <summary>
        /// Gets or sets the title of the control.
        /// </summary>
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                TitleLabel.Text = value;
                _Title = value;
            }
        }

        /// <summary>
        /// Occurs when the user changes the slider value.
        /// </summary>
        new public event EventHandler<int> Scroll;
        public void OnScroll(int e) => Scroll?.Invoke(this, e);

        /// <summary>
        /// Occurs when the user starts changing the slider value.
        /// </summary>
        public event EventHandler<int> ScrollStart;
        public void OnScrollStart(int e) => ScrollStart?.Invoke(this, e);

        /// <summary>
        /// Occurs when the user stops changing the slider value.
        /// </summary>
        public event EventHandler<int> ScrollEnd;
        public void OnScrollEnd(int e) => ScrollEnd?.Invoke(this, e);


        private int _Minimum;
        /// <summary>
        /// Gets or sets the minimum slider value.
        /// </summary>
        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                MainTrackBar.Minimum = value;
                _Minimum = value;
            }
        }

        private int _Maximum;
        /// <summary>
        /// Gets or sets the maximum slider value.
        /// </summary>
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                MainTrackBar.Maximum = value;
                _Maximum = value;
            }
        }

        private int _Value;
        /// <summary>
        /// Gets or sets the value of the slider.
        /// </summary>
        public int Value
        {
            get
            {
                return MainTrackBar.Value;
            }
            set
            {
                _Value = value;
                MainLabel.Text = value.ToString();
                MainTrackBar.Value = value;
            }
        }

        private void MainTrackBar_Scroll(object sender, EventArgs e)
        {
            MainLabel.Text = MainTrackBar.Value.ToString();
            OnScroll(MainTrackBar.Value);
        }

        private void MainTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            OnScrollStart(MainTrackBar.Value);
        }

        private void MainTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            OnScrollEnd(MainTrackBar.Value);
        }
    }
}
