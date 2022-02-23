using Microsoft.Win32;
using System.Windows.Forms;

namespace ScreenSaverDemo
{
    public partial class SettingsForm : Form
    {
        private float brightness;
        private float contrast;
        private float hue;
        private float saturation;
        private float gamma;

        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private bool IsSettingsFieldSet()
        {
            if (brightness != 0F && contrast != 0F && hue != 0F && saturation != 0F & gamma != 0F)
            {
                return true;
            }
            return false;
        }

        private void LoadSettings()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Demo_ScreenSaver");
            // Get the value stored in the Registry
            if (key == null)
            {
                key.SetValue("brightness", "10");
                key.SetValue("contrast", "10");
                key.SetValue("hue", "10");
                key.SetValue("saturation", "10");
                key.SetValue("gamma", "10");
            }
            else
            {
                if (!IsSettingsFieldSet())
                {
                    brightness = (float.Parse((string)key.GetValue("brightness")));
                    brightnessTrackBar.Value = ((int)brightness);
                    contrast = (float.Parse((string)key.GetValue("contrast")));
                    contrastTrackBar.Value = ((int)contrast);
                    hue = (float.Parse((string)key.GetValue("hue")));
                    hueTrackBar.Value = ((int)hue);
                    saturation = (float.Parse((string)key.GetValue("saturation")));
                    saturationTrackBar.Value = ((int)saturation);
                    gamma = (float.Parse((string)key.GetValue("gamma")));
                    gammaTrackBar.Value = ((int)gamma);
                }
            }
        }

        private void SaveSettings()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Demo_ScreenSaver");
            // Create or get existing Registry subkey
            if (IsSettingsFieldSet())
            {
                key.SetValue("brightness", brightness.ToString());
                key.SetValue("contrast", contrast.ToString());
                key.SetValue("hue", hue.ToString());
                key.SetValue("saturation", saturation.ToString());
                key.SetValue("gamma", gamma.ToString());
            }
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            SaveSettings();
            Close();
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void brightnessTrackBar_Scroll(object sender, System.EventArgs e)
        {
            brightness = (float)(brightnessTrackBar.Value);
        }

        private void contrastTrackBar_Scroll(object sender, System.EventArgs e)
        {
            contrast = (float)(contrastTrackBar.Value);
        }

        private void hueTrackBar_Scroll(object sender, System.EventArgs e)
        {
            hue = (float)(hueTrackBar.Value);
        }

        private void saturationTrackBar_Scroll(object sender, System.EventArgs e)
        {
            saturation = (float)(saturationTrackBar.Value);
        }

        private void gammaTrackBar_Scroll(object sender, System.EventArgs e)
        {
            gamma = (float)(gammaTrackBar.Value);
        }
    }
}
