namespace WinForms_App
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.RGBWWLED_TabPage = new System.Windows.Forms.TabPage();
            this.Vumax_SliderWithLabel = new WinForms_App.UserControls.SliderWithLabel();
            this.Vumin_SliderWithLabel = new WinForms_App.UserControls.SliderWithLabel();
            this.VuLoops_SliderWithLabel = new WinForms_App.UserControls.SliderWithLabel();
            this.SwitchVumeter_Button = new System.Windows.Forms.Button();
            this.RandomColor_Button = new System.Windows.Forms.Button();
            this.On_Button = new System.Windows.Forms.Button();
            this.Off_Button = new System.Windows.Forms.Button();
            this.Settings_TabPage = new System.Windows.Forms.TabPage();
            this.AutoSave_CheckBox = new System.Windows.Forms.CheckBox();
            this.Status_Label = new System.Windows.Forms.Label();
            this.MainTabControl.SuspendLayout();
            this.RGBWWLED_TabPage.SuspendLayout();
            this.Settings_TabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabControl.Controls.Add(this.RGBWWLED_TabPage);
            this.MainTabControl.Controls.Add(this.Settings_TabPage);
            this.MainTabControl.Location = new System.Drawing.Point(12, 12);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(776, 453);
            this.MainTabControl.TabIndex = 0;
            // 
            // RGBWWLED_TabPage
            // 
            this.RGBWWLED_TabPage.Controls.Add(this.Vumax_SliderWithLabel);
            this.RGBWWLED_TabPage.Controls.Add(this.Vumin_SliderWithLabel);
            this.RGBWWLED_TabPage.Controls.Add(this.VuLoops_SliderWithLabel);
            this.RGBWWLED_TabPage.Controls.Add(this.SwitchVumeter_Button);
            this.RGBWWLED_TabPage.Controls.Add(this.RandomColor_Button);
            this.RGBWWLED_TabPage.Controls.Add(this.On_Button);
            this.RGBWWLED_TabPage.Controls.Add(this.Off_Button);
            this.RGBWWLED_TabPage.Location = new System.Drawing.Point(4, 22);
            this.RGBWWLED_TabPage.Name = "RGBWWLED_TabPage";
            this.RGBWWLED_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.RGBWWLED_TabPage.Size = new System.Drawing.Size(768, 427);
            this.RGBWWLED_TabPage.TabIndex = 0;
            this.RGBWWLED_TabPage.Text = "RGBWW LED";
            this.RGBWWLED_TabPage.UseVisualStyleBackColor = true;
            // 
            // Vumax_SliderWithLabel
            // 
            this.Vumax_SliderWithLabel.Location = new System.Drawing.Point(277, 195);
            this.Vumax_SliderWithLabel.Maximum = 500;
            this.Vumax_SliderWithLabel.Minimum = 0;
            this.Vumax_SliderWithLabel.Name = "Vumax_SliderWithLabel";
            this.Vumax_SliderWithLabel.Size = new System.Drawing.Size(165, 74);
            this.Vumax_SliderWithLabel.TabIndex = 6;
            this.Vumax_SliderWithLabel.Title = "Vumeter max";
            this.Vumax_SliderWithLabel.Value = 200;
            // 
            // Vumin_SliderWithLabel
            // 
            this.Vumin_SliderWithLabel.Location = new System.Drawing.Point(277, 115);
            this.Vumin_SliderWithLabel.Maximum = 500;
            this.Vumin_SliderWithLabel.Minimum = 0;
            this.Vumin_SliderWithLabel.Name = "Vumin_SliderWithLabel";
            this.Vumin_SliderWithLabel.Size = new System.Drawing.Size(165, 74);
            this.Vumin_SliderWithLabel.TabIndex = 5;
            this.Vumin_SliderWithLabel.Title = "Vumeter min";
            this.Vumin_SliderWithLabel.Value = 100;
            // 
            // VuLoops_SliderWithLabel
            // 
            this.VuLoops_SliderWithLabel.Location = new System.Drawing.Point(277, 35);
            this.VuLoops_SliderWithLabel.Maximum = 500;
            this.VuLoops_SliderWithLabel.Minimum = 150;
            this.VuLoops_SliderWithLabel.Name = "VuLoops_SliderWithLabel";
            this.VuLoops_SliderWithLabel.Size = new System.Drawing.Size(165, 74);
            this.VuLoops_SliderWithLabel.TabIndex = 4;
            this.VuLoops_SliderWithLabel.Title = "Vumeter loop skip";
            this.VuLoops_SliderWithLabel.Value = 200;
            // 
            // SwitchVumeter_Button
            // 
            this.SwitchVumeter_Button.Location = new System.Drawing.Point(277, 6);
            this.SwitchVumeter_Button.Name = "SwitchVumeter_Button";
            this.SwitchVumeter_Button.Size = new System.Drawing.Size(113, 23);
            this.SwitchVumeter_Button.TabIndex = 3;
            this.SwitchVumeter_Button.Text = "Switch vumeter";
            this.SwitchVumeter_Button.UseVisualStyleBackColor = true;
            this.SwitchVumeter_Button.Click += new System.EventHandler(this.SwitchVumeter_button_Click);
            // 
            // RandomColor_Button
            // 
            this.RandomColor_Button.Location = new System.Drawing.Point(168, 6);
            this.RandomColor_Button.Name = "RandomColor_Button";
            this.RandomColor_Button.Size = new System.Drawing.Size(103, 23);
            this.RandomColor_Button.TabIndex = 2;
            this.RandomColor_Button.Text = "Set random color";
            this.RandomColor_Button.UseVisualStyleBackColor = true;
            this.RandomColor_Button.Click += new System.EventHandler(this.RandomColor_Button_Click);
            // 
            // On_Button
            // 
            this.On_Button.Location = new System.Drawing.Point(6, 6);
            this.On_Button.Name = "On_Button";
            this.On_Button.Size = new System.Drawing.Size(75, 23);
            this.On_Button.TabIndex = 1;
            this.On_Button.Text = "ON";
            this.On_Button.UseVisualStyleBackColor = true;
            this.On_Button.Click += new System.EventHandler(this.On_Button_Click);
            // 
            // Off_Button
            // 
            this.Off_Button.Location = new System.Drawing.Point(87, 6);
            this.Off_Button.Name = "Off_Button";
            this.Off_Button.Size = new System.Drawing.Size(75, 23);
            this.Off_Button.TabIndex = 0;
            this.Off_Button.Text = "OFF";
            this.Off_Button.UseVisualStyleBackColor = true;
            this.Off_Button.Click += new System.EventHandler(this.Off_Button_Click);
            // 
            // Settings_TabPage
            // 
            this.Settings_TabPage.Controls.Add(this.AutoSave_CheckBox);
            this.Settings_TabPage.Location = new System.Drawing.Point(4, 22);
            this.Settings_TabPage.Name = "Settings_TabPage";
            this.Settings_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Settings_TabPage.Size = new System.Drawing.Size(768, 427);
            this.Settings_TabPage.TabIndex = 1;
            this.Settings_TabPage.Text = "Settings";
            this.Settings_TabPage.UseVisualStyleBackColor = true;
            // 
            // AutoSave_CheckBox
            // 
            this.AutoSave_CheckBox.AutoSize = true;
            this.AutoSave_CheckBox.Checked = true;
            this.AutoSave_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoSave_CheckBox.Location = new System.Drawing.Point(6, 6);
            this.AutoSave_CheckBox.Name = "AutoSave_CheckBox";
            this.AutoSave_CheckBox.Size = new System.Drawing.Size(212, 17);
            this.AutoSave_CheckBox.TabIndex = 0;
            this.AutoSave_CheckBox.Text = "Automatically save configuration on exit";
            this.AutoSave_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Status_Label
            // 
            this.Status_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Status_Label.AutoSize = true;
            this.Status_Label.Location = new System.Drawing.Point(13, 464);
            this.Status_Label.Name = "Status_Label";
            this.Status_Label.Size = new System.Drawing.Size(21, 13);
            this.Status_Label.TabIndex = 1;
            this.Status_Label.Text = "Ok";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 477);
            this.Controls.Add(this.Status_Label);
            this.Controls.Add(this.MainTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IOT";
            this.MainTabControl.ResumeLayout(false);
            this.RGBWWLED_TabPage.ResumeLayout(false);
            this.Settings_TabPage.ResumeLayout(false);
            this.Settings_TabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage RGBWWLED_TabPage;
        private System.Windows.Forms.TabPage Settings_TabPage;
        private System.Windows.Forms.CheckBox AutoSave_CheckBox;
        private System.Windows.Forms.Button On_Button;
        private System.Windows.Forms.Button Off_Button;
        private System.Windows.Forms.Label Status_Label;
        private System.Windows.Forms.Button RandomColor_Button;
        private System.Windows.Forms.Button SwitchVumeter_Button;
        private UserControls.SliderWithLabel VuLoops_SliderWithLabel;
        private UserControls.SliderWithLabel Vumax_SliderWithLabel;
        private UserControls.SliderWithLabel Vumin_SliderWithLabel;
    }
}

