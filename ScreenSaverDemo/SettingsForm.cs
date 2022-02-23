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

        private float setValueInRegistryAndReturnValue(string key, string value)
        {
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Cennest_Demo_ScreenSaver");
            regKey.SetValue(key, value);
            return float.Parse(value);
        }

        private void LoadSettings()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Cennest_Demo_ScreenSaver");
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
                brightness = key.GetValue("brightness") != null ? (float.Parse((string)key.GetValue("brightness"))) : setValueInRegistryAndReturnValue("brightness", "10");
                brightnessTrackBar.Value = ((int)brightness);
                contrast = key.GetValue("contrast") != null ? (float.Parse((string)key.GetValue("contrast"))) : setValueInRegistryAndReturnValue("contrast", "10");
                contrastTrackBar.Value = ((int)contrast);
                hue = key.GetValue("hue") != null ? (float.Parse((string)key.GetValue("hue"))) : setValueInRegistryAndReturnValue("hue", "10"); ;
                hueTrackBar.Value = ((int)hue);
                saturation = key.GetValue("saturation") != null ? (float.Parse((string)key.GetValue("saturation"))) : setValueInRegistryAndReturnValue("saturation", "10"); ;
                saturationTrackBar.Value = ((int)saturation);
                gamma = key.GetValue("gamma") != null ? (float.Parse((string)key.GetValue("gamma"))) : setValueInRegistryAndReturnValue("gamma", "10"); ;
                gammaTrackBar.Value = ((int)gamma);
            }

            brightnessTextBox.Text = brightness.ToString();
            contrastTextBox.Text = contrast.ToString();
            hueTextBox.Text = hue.ToString();
            saturationTextBox.Text = saturation.ToString();
            gammaTextBox.Text = gamma.ToString();
        }

        private void SaveSettings()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Cennest_Demo_ScreenSaver");
            
            key.SetValue("brightness", brightness.ToString());
            key.SetValue("contrast", contrast.ToString());
            key.SetValue("hue", hue.ToString());
            key.SetValue("saturation", saturation.ToString());
            key.SetValue("gamma", gamma.ToString());
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
            brightnessTextBox.Text = brightness.ToString();
        }

        private void contrastTrackBar_Scroll(object sender, System.EventArgs e)
        {
            contrast = (float)(contrastTrackBar.Value);
            contrastTextBox.Text = contrast.ToString();
        }

        private void hueTrackBar_Scroll(object sender, System.EventArgs e)
        {
            hue = (float)(hueTrackBar.Value);
            hueTextBox.Text = hue.ToString();
        }

        private void saturationTrackBar_Scroll(object sender, System.EventArgs e)
        {
            saturation = (float)(saturationTrackBar.Value);
            saturationTextBox.Text = saturation.ToString();
        }

        private void gammaTrackBar_Scroll(object sender, System.EventArgs e)
        {
            gamma = (float)(gammaTrackBar.Value);
            gammaTextBox.Text = gamma.ToString();
        }
    }
}
