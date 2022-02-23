using Microsoft.Win32;
using System.Windows.Forms;

namespace ScreenSaverDemo
{
    public partial class SettingsForm : Form
    {
        private float brightness = 10F;
        private float contrast = 10F;
        private float hue = 10F;
        private float saturation = 10F;
        private float gamma = 10F;

        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Cennest_Demo_ScreenSaver");
            // Get the value stored in the Registry
            if (key == null || key.ValueCount == 0 || key.ValueCount == 1)
            {
                key.SetValue("brightness", brightness.ToString());
                key.SetValue("contrast", contrast.ToString());
                key.SetValue("hue", hue.ToString());
                key.SetValue("saturation", hue.ToString());
                key.SetValue("gamma", gamma.ToString());
            }
            else
            {
                brightness = key.GetValue("brightness") != null ? (float.Parse((string)key.GetValue("brightness"))) : brightness;
                contrast = key.GetValue("contrast") != null ? (float.Parse((string)key.GetValue("contrast"))) : contrast;
                hue = key.GetValue("hue") != null ? (float.Parse((string)key.GetValue("hue"))) : hue;
                saturation = key.GetValue("saturation") != null ? (float.Parse((string)key.GetValue("saturation"))) : saturation;
                gamma = key.GetValue("gamma") != null ? (float.Parse((string)key.GetValue("gamma"))) : gamma;
            }

            brightnessTrackBar.Value = ((int)brightness);
            brightnessTextBox.Text = brightness.ToString();
            contrastTrackBar.Value = ((int)contrast);
            contrastTextBox.Text = contrast.ToString();
            hueTrackBar.Value = ((int)hue);
            hueTextBox.Text = hue.ToString();
            saturationTrackBar.Value = ((int)saturation);
            saturationTextBox.Text = saturation.ToString();
            gammaTrackBar.Value = ((int)gamma);
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
