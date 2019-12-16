using System;
using System.Collections.Generic;
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
            code += "\t\t" + GenerateColourParams(btnNeutralColour.BackColor) + "\r\n";
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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openDialog.FileName = Settings.Default.LastSavePath;
            DialogResult result = openDialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                string path = openDialog.FileName;

                Console.WriteLine($"parsing {path}");

                Settings.Default.LastSavePath = path;
                Settings.Default.Save();

                string text = File.ReadAllText(path);
                
                List<List<string>> lines = new List<List<string>>();

                // crappy parsing code
                {
                    uint bracketLevel = 0;
                    bool inQuotes = false;
                    string buffer = "";
                    List<string> keys = new List<String>();

                    for (int i = 0; i < text.Length; i++)
                    {
                        char c = text[i];

                        if (c == '\r' || c == '\n')
                        {
                            continue;
                        }

                        if (c == '{')
                        {
                            bracketLevel++;
                        }
                        else if (c == '}')
                        {
                            bracketLevel--;

                            if (bracketLevel == 1 && keys.Count >= 1)
                            {
                                lines.Add(new List<string>(keys));
                                keys.Clear();
                            }
                        }
                        else if (c == '"')
                        {
                            inQuotes = !inQuotes;
                        }
                        else if (c == ' ' || c == '\t')
                        {
                            if (buffer.Trim().Length >= 1)
                            {
                                keys.Add(buffer);
                                buffer = "";
                            }
                        }
                        else
                        {
                            buffer += c;
                        }
                    }
                }

                for (int i = 0; i < lines.Count; i++)
                {
                    List<string> line = lines[i];
                    string key = line[0];
                    double rd = ClampColour(double.Parse(line[1]));
                    double gd = ClampColour(double.Parse(line[2]));
                    double bd = ClampColour(double.Parse(line[3]));
                    double ad = ClampColour(double.Parse(line[4]));

                    int r = (int)(rd * 255.0);
                    int g = (int)(gd * 255.0);
                    int b = (int)(bd * 255.0);
                    int a = (int)(ad * 255.0);

                    Color col = Color.FromArgb(a, r, g, b);

                    switch (key)
                    {
                        case "mTeamAColor":
                        {
                            btnAlphaColour.BackColor = col;
                            break;
                        }

                        case "mTeamBColor":
                        {
                            btnBravoColour.BackColor = col;
                            break;
                        }

                        case "mTeamNeutralColor":
                        {
                            btnNeutralColour.BackColor = col;
                            break;
                        }
                    }

                    Settings.Default.LastColourAlpha = btnAlphaColour.BackColor;
                    Settings.Default.LastColourBravo = btnBravoColour.BackColor;
                    Settings.Default.LastColourNeutral = btnNeutralColour.BackColor;
                    Settings.Default.Save();
                    GenerateCode();
                }
            }
        }

        private double ClampColour(double v)
        {
            if (v < 0.0) v = 0.0;
            if (v > 1.0) v = 1.0;
            return v;
        }
    }
}
