﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Helpers;
using WinForms_App.UserControls;

namespace WinForms_App
{
    public partial class MainWindow : Form
    {

        #region Initialization

        public MainWindow()
        {
            InitializeComponent();
            RequiredDirectories = new string[] { "Data", "Cache" };
            if (File.Exists(ConfigurationFileName))
            {
                AppConfiguration = (ApplicationConfiguration)SerializationHelper.DeserializeObject<ApplicationConfiguration>(ConfigurationFileName);
            }
            if (File.Exists(IOTDevicesFileName))
            {
                IOTDevices = (List<IOT.IOTDevice>)SerializationHelper.DeserializeObject<List<IOT.IOTDevice>>(IOTDevicesFileName);
            }
#if DEBUG
            if (IOTDevices == null || IOTDevices.Count == 0)
            {
                IOTDevices.Add(new IOT.IOTDevice()
                {
                    Name = "ESP8266_0",
                    IPAddress = "10.1.0.101"
                });
            }
#endif
            RGBWWLED = new IOT.API.RGBWWLED.RGBWWLEDControl(IOTDevices?.Where(o => o.Name == "ESP8266_0").ToList()[0]);
            InitializeUI();
            RGBWWLED_TabPage.AutoScroll = true;
            VuLoops_SliderWithLabel.ScrollEnd += VuLoops_SliderWithLabel_ScrollEnd;
            Vumin_SliderWithLabel.ScrollEnd += Vumin_SliderWithLabel_ScrollEnd;
            Vumax_SliderWithLabel.ScrollEnd += Vumax_SliderWithLabel_ScrollEnd;
            this.FormClosing += MainWindow_FormClosing;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppConfiguration = new ApplicationConfiguration()
            {
                AutoSaveConfiguration = AutoSave_CheckBox.Checked,
            };
            if (AppConfiguration.AutoSaveConfiguration)
            {
                AppConfiguration.RGBWWLEDConfiguration = new IOT.API.RGBWWLED.RGBWWLEDConfiguration()
                {
                    PWMValues = colorSliders.Select(o => o.Value).ToArray(),
                    VumeterConfiguration = new IOT.API.RGBWWLED.VumeterConfiguration()
                    {
                        LoopSkip = VuLoops_SliderWithLabel.Value,
                        Maximum = Vumax_SliderWithLabel.Value,
                        Minimum = Vumin_SliderWithLabel.Value
                    }
                };
            }
            AppConfiguration.SerializeObject(ConfigurationFileName);
            IOTDevices.SerializeObject(IOTDevicesFileName);
        }

        private void InitializeUI()
        {
            //Setup color sliders.
            string[] titles = { "Cold white", "Red", "Green", "Blue", "Warm white"};
            for (int i = 0; i < colorSliders.Length; i++)
            {
                colorSliders[i] = new SliderWithLabel()
                {
                    Minimum = 0,
                    Maximum = 1023,
                    Title = titles[i],
                    Tag = i,
                    Value = random.Next(0, 1024)
                };

                colorSliders[i].Scroll += (sender, e) =>
                {

                };

                colorSliders[i].ScrollStart += (sender, e) => 
                {

                };

                colorSliders[i].ScrollEnd += async (sender, e) =>
                {
                    Status_Label.Text = await RGBWWLED.SetLEDValueAsync((IOT.API.RGBWWLED.RGBWWLEDControl.LED)(int)(sender as SliderWithLabel).Tag, e);
                };

                RGBWWLED_TabPage.Controls.Add(colorSliders[i]);
                colorSliders[i].Width = RandomColor_Button.Left + RandomColor_Button.Width - 10;
                colorSliders[i].Left = 10;
                colorSliders[i].Top = On_Button.Top + On_Button.Height + 10 + colorSliders[i].Height * i;
                if (AppConfiguration.RGBWWLEDConfiguration != null)
                {
                    colorSliders[i].Value = AppConfiguration.RGBWWLEDConfiguration.PWMValues[i];
                }
            }
            if (AppConfiguration.RGBWWLEDConfiguration?.VumeterConfiguration != null)
            {
                VuLoops_SliderWithLabel.Value = AppConfiguration.RGBWWLEDConfiguration.VumeterConfiguration.LoopSkip;
                Vumin_SliderWithLabel.Value = AppConfiguration.RGBWWLEDConfiguration.VumeterConfiguration.Minimum;
                Vumax_SliderWithLabel.Value = AppConfiguration.RGBWWLEDConfiguration.VumeterConfiguration.Maximum;
            }
        }

        #endregion

        #region Properties

        private readonly string ConfigurationFileName = "Data/config.xml";
        private readonly string IOTDevicesFileName = "Data/devices.xml";
        private string[] _RequiredDirectories;
        private string[] RequiredDirectories
        {
            get
            {
                return _RequiredDirectories;
            }
            set
            {
                foreach (string directory in value)
                {
                    if (!System.IO.Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                }
                _RequiredDirectories = value;
            }
        }
        private ApplicationConfiguration _AppConfiguration;
        private ApplicationConfiguration AppConfiguration
        {
            get
            {
                return _AppConfiguration;
            }
            set
            {
                //TODO: update UI
                AutoSave_CheckBox.Checked = value.AutoSaveConfiguration;
                _AppConfiguration = value;
            }
        }
        List<IOT.IOTDevice> _IOTDevices;
        List<IOT.IOTDevice> IOTDevices
        {
            get
            {
                return _IOTDevices;
            }
            set
            {
                //TODO: update UI
                _IOTDevices = value;
            }
        }
        IOT.API.RGBWWLED.RGBWWLEDControl RGBWWLED;
        SliderWithLabel[] colorSliders = new SliderWithLabel[5];
        Random random = new Random();

        #endregion

        #region Interaction

        async private void On_Button_Click(object sender, EventArgs e)
        {
            try
            {
                On_Button.Enabled = false;
                Status_Label.Text = await RGBWWLED.TurnOnAsync();
                for (int i = 0; i < colorSliders.Length; i++)
                {
                    colorSliders[i].Value = 1023;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                On_Button.Enabled = true;
            }
        }

        async private void Off_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Off_Button.Enabled = false;
                Status_Label.Text = await RGBWWLED.TurnOffAsync();
                for (int i = 0; i < colorSliders.Length; i++)
                {
                    colorSliders[i].Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Off_Button.Enabled = true;
            }
        }

        async private void RandomColor_Button_Click(object sender, EventArgs e)
        {
            try
            {
                RandomColor_Button.Enabled = false;
                for (int i = 0; i < colorSliders.Length; i++)
                {
                    colorSliders[i].Value = random.Next(0, 1024);
                }
                Status_Label.Text = await RGBWWLED.SetLEDValueAsync(new IOT.API.RGBWWLED.RGBWWLEDControl.LED[] { IOT.API.RGBWWLED.RGBWWLEDControl.LED.CW, IOT.API.RGBWWLED.RGBWWLEDControl.LED.R, IOT.API.RGBWWLED.RGBWWLEDControl.LED.G, IOT.API.RGBWWLED.RGBWWLEDControl.LED.B, IOT.API.RGBWWLED.RGBWWLEDControl.LED.WW }, new int[] { colorSliders[0].Value, colorSliders[1].Value, colorSliders[2].Value, colorSliders[3].Value, colorSliders[4].Value, });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                RandomColor_Button.Enabled = true;
            }
        }

        async private void SwitchVumeter_button_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchVumeter_Button.Enabled = false;
                Status_Label.Text = await RGBWWLED.SwitchVumeterAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SwitchVumeter_Button.Enabled = true;
            }
        }

        async private void VuLoops_SliderWithLabel_ScrollEnd(object sender, int e)
        {
            Status_Label.Text = await RGBWWLED.SetVumeterVariableAsync(IOT.API.RGBWWLED.RGBWWLEDControl.VumeterVariable.Vuloops, e);
        }
        
        async private void Vumax_SliderWithLabel_ScrollEnd(object sender, int e)
        {
            Status_Label.Text = await RGBWWLED.SetVumeterVariableAsync(IOT.API.RGBWWLED.RGBWWLEDControl.VumeterVariable.Vumax, e);
        }

        async private void Vumin_SliderWithLabel_ScrollEnd(object sender, int e)
        {
            Status_Label.Text = await RGBWWLED.SetVumeterVariableAsync(IOT.API.RGBWWLED.RGBWWLEDControl.VumeterVariable.Vumin, e);
        }

        #endregion
    }
}
