using LibVLCSharp.Shared;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ScreenSaverDemo
{
    public partial class ScreenSaverForm : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

        private bool previewMode = false;
        private Point mouseLocation;


public ScreenSaverForm(IntPtr previewWndHandle)
        {
            InitializeComponent();

            // Set the preview window as the parent of this window
            SetParent(this.Handle, previewWndHandle);

            // Make this a child window so it will close when the parent dialog closes
            // GWL_STYLE = -16, WS_CHILD = 0x40000000
            SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));

            // Place our window inside the parent
            Rectangle ParentRect;
            GetClientRect(previewWndHandle, out ParentRect);
            Size = ParentRect.Size;
            Location = new Point(0, 0);

            previewMode = true;
        }

        public ScreenSaverForm(Rectangle bounds)
        {
            InitializeComponent();
            this.Bounds = bounds;
        }

        private void ScreenSaverForm_Load(object sender, EventArgs e)
        {
            // Initialize the settings variables
            float brightness = 10F;
            float contrast = 10F;
            float hue = 10F;
            float saturation = 10F;
            float gamma = 10F;

            // Use the settings from the Registry if it exists
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Cennest_Demo_ScreenSaver");

            if(regKey == null || regKey.ValueCount == 0 || regKey.ValueCount == 1)
            {
                regKey.SetValue("brightness", brightness.ToString());
                regKey.SetValue("contrast", contrast.ToString());
                regKey.SetValue("hue", hue.ToString());
                regKey.SetValue("saturation", saturation.ToString());
                regKey.SetValue("gamma", gamma.ToString());
            }

            else
            {
                brightness = float.Parse((string)regKey.GetValue("brightness"));
                contrast = float.Parse((string)regKey.GetValue("contrast"));
                hue = float.Parse((string)regKey.GetValue("hue"));
                saturation = float.Parse((string)regKey.GetValue("saturation"));
                gamma = float.Parse((string)regKey.GetValue("gamma"));
            }

            // Hiding the cursor and setting the Form Window State
            Cursor.Hide();
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            // Initialising LibVLC and other objects need to capture and play the incoming stream
            Core.Initialize();
            LibVLC _libVLC = new LibVLC("--video-filter=transform", "--transform-type=hflip", "--no-audio", " --live-caching=1", "--dshow-adev=none", "--avcodec-hw=d3d11va");
            MediaPlayer _mediaPlayer = new MediaPlayer(_libVLC);
            Media media = new Media(_libVLC, "dshow://", FromType.FromLocation);

            // Setting the media player properties
            _mediaPlayer.Scale = 0;
            _mediaPlayer.FileCaching = 0;


            //Setting the Video View properties
            vlcVideoView.Visible = true;
            vlcVideoView.Dock = DockStyle.Fill;
            vlcVideoView.MediaPlayer = _mediaPlayer;
            vlcVideoView.MediaPlayer.AspectRatio = $"{vlcVideoView.Width.ToString()}:{vlcVideoView.Height.ToString()}";
            
            // Enabling Video Adjust Options and setting the properties
            _mediaPlayer.SetAdjustFloat(LibVLCSharp.Shared.VideoAdjustOption.Enable, 1);
            _mediaPlayer.SetAdjustFloat(LibVLCSharp.Shared.VideoAdjustOption.Brightness, (brightness/10));
            _mediaPlayer.SetAdjustFloat(LibVLCSharp.Shared.VideoAdjustOption.Contrast, (contrast/10));
            _mediaPlayer.SetAdjustFloat(LibVLCSharp.Shared.VideoAdjustOption.Hue, (hue/10));
            _mediaPlayer.SetAdjustFloat(LibVLCSharp.Shared.VideoAdjustOption.Saturation, (saturation/10));
            _mediaPlayer.SetAdjustFloat(LibVLCSharp.Shared.VideoAdjustOption.Gamma, (gamma/10));

            _mediaPlayer.Play(media);
            _mediaPlayer.Playing += OnPlaying;

        }


        private void OnPlaying(object sender, EventArgs e)
        {
            // Need to set these to false so that the Video View is able to detect click and key input
            vlcVideoView.MediaPlayer.EnableKeyInput = false;
            vlcVideoView.MediaPlayer.EnableMouseInput = false;
        }
        private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseLocation.IsEmpty)
            {
                // Terminate if mouse is moved a significant distance
                if (Math.Abs(mouseLocation.X - e.X) > 5 ||
                    Math.Abs(mouseLocation.Y - e.Y) > 5)
                { 
                    Application.Exit(); 
                }
            }

            // Update current mouse location
            mouseLocation = e.Location;
        }

        private void ScreenSaverForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!previewMode)
            {
                Application.Exit();
            }
        }

        private void ScreenSaverForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void vlcVideoView_KeyPress(object sender, KeyPressEventArgs e)
        {
            Application.Exit();
        }

        private void ScreenSaverForm_Deactivate(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void vlcVideoView_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
    }
}
