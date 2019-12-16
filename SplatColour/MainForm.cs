using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SplatColour.Properties;

namespace SplatColour
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            btnAlphaColour.Click += HandleColourButtonClick;
            btnBravoColour.Click += HandleColourButtonClick;
            btnNeutralColour.Click += HandleColourButtonClick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnAlphaColour.BackColor = Settings.Default.LastColourAlpha;
            btnBravoColour.BackColor = Settings.Default.LastColourBravo;
            btnNeutralColour.BackColor = Settings.Default.LastColourNeutral;

            GenerateCode();
        }

        private void HandleColourButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            colourDialog.Color = btn.BackColor;

            DialogResult result = colourDialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                btn.BackColor = colourDialog.Color;
                GenerateCode();
                
                Settings.Default.LastColourAlpha = btnAlphaColour.BackColor;
                Settings.Default.LastColourBravo = btnBravoColour.BackColor;
                Settings.Default.LastColourNeutral = btnNeutralColour.BackColor;
                Settings.Default.Save();
            }
        }

        public void GenerateCode()
        {
            string code = "";

            code += "{\r\n";
            code += "\t{\r\n";
            code += "\t\t\"mTeamAColor\"\r\n";
            code += "\t\t" + GenerateColourParams(btnAlphaColour.BackColor) + "\r\n";
            code += "\t}\r\n";
            code += "\t{\r\n";
            code += "\t\t\"mTeamBColor\"\r\n";
            code += "\t\t" + GenerateColourParams(btnBravoColour.BackColor) + "\r\n";
            code += "\t}\r\n";
            code += "\t{\r\n";
            code += "\t\t\"mTeamNeutralColor\"\r\n";
            code += "\t\t" + GenerateColourParams(btnBravoColour.BackColor) + "\r\n";
            code += "\t}\r\n";
            code += "}\r\n";

            tbCode.Text = code;
        }

        private string GenerateColourParams(Color color)
        {
            string s = "";

            double r = (double) color.R / 255.0;
            double g = (double) color.G / 255.0;
            double b = (double) color.B / 255.0;

            s += $"{r:0.00000000}";
            s += " ";
            s += $"{g:0.00000000}";
            s += " ";
            s += $"{b:0.00000000}";
            s += " ";
            s += $"{1.0:0.00000000}";
            s += " ";

            return s;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbCode.Text);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            DisableUi();
            
            saveDialog.FileName = Settings.Default.LastSavePath;
            DialogResult result = saveDialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                string path = saveDialog.FileName;
                GenerateCode();
                File.WriteAllText(path, tbCode.Text);
                Console.WriteLine($"Saved to {path}");

                Settings.Default.LastSavePath = path;
                Settings.Default.Save();
            }

            EnableUi();
        }

        private void SetUiEnabled(bool enabled)
        {
            foreach (Control control in Controls)
            {
                if (control is Button)
                {
                    control.Enabled = enabled;
                }
            }
        }

        private void EnableUi()
        {
            SetUiEnabled(true);
        }

        private void DisableUi()
        {
            SetUiEnabled(false);
        }
    }
}
