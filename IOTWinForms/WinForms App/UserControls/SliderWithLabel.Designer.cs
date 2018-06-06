namespace WinForms_App.UserControls
{
    partial class SliderWithLabel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainLabel = new System.Windows.Forms.Label();
            this.MainTrackBar = new System.Windows.Forms.TrackBar();
            this.TitleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MainTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.AutoSize = true;
            this.MainLabel.Location = new System.Drawing.Point(3, 13);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(13, 13);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "0";
            // 
            // MainTrackBar
            // 
            this.MainTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTrackBar.BackColor = System.Drawing.Color.White;
            this.MainTrackBar.Location = new System.Drawing.Point(6, 29);
            this.MainTrackBar.Name = "MainTrackBar";
            this.MainTrackBar.Size = new System.Drawing.Size(156, 45);
            this.MainTrackBar.SmallChange = 0;
            this.MainTrackBar.TabIndex = 1;
            this.MainTrackBar.Scroll += new System.EventHandler(this.MainTrackBar_Scroll);
            this.MainTrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainTrackBar_MouseDown);
            this.MainTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainTrackBar_MouseUp);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(3, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(32, 13);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "Title";
            // 
            // SliderWithLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.MainTrackBar);
            this.Controls.Add(this.MainLabel);
            this.Name = "SliderWithLabel";
            this.Size = new System.Drawing.Size(165, 74);
            ((System.ComponentModel.ISupportInitialize)(this.MainTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MainLabel;
        private System.Windows.Forms.TrackBar MainTrackBar;
        private System.Windows.Forms.Label TitleLabel;
    }
}
