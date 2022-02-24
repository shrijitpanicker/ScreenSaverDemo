namespace ScreenSaverDemo
{
    partial class ScreenSaverForm
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
            this.vlcVideoView = new LibVLCSharp.WinForms.VideoView();
            ((System.ComponentModel.ISupportInitialize)(this.vlcVideoView)).BeginInit();
            this.SuspendLayout();
            // 
            // vlcVideoView
            // 
            this.vlcVideoView.BackColor = System.Drawing.Color.Black;
            this.vlcVideoView.Location = new System.Drawing.Point(6, 5);
            this.vlcVideoView.MediaPlayer = null;
            this.vlcVideoView.Name = "vlcVideoView";
            this.vlcVideoView.Size = new System.Drawing.Size(788, 441);
            this.vlcVideoView.TabIndex = 0;
            this.vlcVideoView.Text = "vlcVideoView";
            this.vlcVideoView.Visible = false;
            this.vlcVideoView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vlcVideoView_KeyPress);
            this.vlcVideoView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.vlcVideoView_MouseClick);
            // 
            // ScreenSaverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.vlcVideoView);
            this.Name = "ScreenSaverForm";
            this.Text = "Form1";
            this.Deactivate += new System.EventHandler(this.ScreenSaverForm_Deactivate);
            this.Load += new System.EventHandler(this.ScreenSaverForm_Load);
            this.Click += new System.EventHandler(this.ScreenSaverForm_Click);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScreenSaverForm_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.vlcVideoView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LibVLCSharp.WinForms.VideoView vlcVideoView;
    }
}

