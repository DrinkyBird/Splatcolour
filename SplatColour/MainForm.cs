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
        private string LastOpenedFile;
        private bool OpenedViaList;

        public MainForm()
        {
            InitializeComponent();

            btnAlphaColour.Click += HandleColourButtonClick;
            btnBravoColour.Click += HandleColourButtonClick;
            btnNeutralColour.Click += HandleColourButtonClick;

            InitListView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnAlphaColour.BackColor = Settings.Default.LastColourAlpha;
            btnBravoColour.BackColor = Settings.Default.LastColourBravo;
            btnNeutralColour.BackColor = Settings.Default.LastColourNeutral;

            GenerateCode();
        }

        private void InitListView()
        {
            for (uint i = 0; i < (uint)InkGroup.NumGroups; i++)
            {
                var g = new ListViewGroup(((InkGroup)i).ToString(), InkFile.InkGroupNames[i]);
                fileList.Groups.Add(g);
            }

            for (uint i = 0; i < InkFile.Files.Length; i++)
            {
                InkFile file = InkFile.Files[i];

                var lvitem = new InkFileListItem(file);
                lvitem.Group = fileList.Groups[(int)file.Group];
                fileList.Items.Add(lvitem);
            }

            fileList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            fileList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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

                if (OpenedViaList)
                {
                    SaveFileInPlace();
                }
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

            double r = color.R / 255.0;
            double g = color.G / 255.0;
            double b = color.B / 255.0;

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

        private void CopyCurrentFile()
        {
            Clipboard.SetText(tbCode.Text);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            CopyCurrentFile();
        }

        private void SaveFileViaDialog()
        {
            DisableUi();

            saveDialog.FileName = Settings.Default.LastSavePath;
            DialogResult result = saveDialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                string path = saveDialog.FileName;
                SaveFile(path);
            }

            EnableUi();
        }

        private void SaveFileInPlace()
        {
            SaveFile(LastOpenedFile);
        }

        private void SaveFile(string path)
        {
            GenerateCode();
            File.WriteAllText(path, tbCode.Text);
            Console.WriteLine($"Saved to {path}");
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileViaDialog();
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

        private void OpenFileViaDialog()
        {
            openDialog.FileName = Settings.Default.LastSavePath;
            DialogResult result = openDialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                string path = openDialog.FileName;

                OpenFile(path);
            }
        }

        private void OpenFile(string path)
        {
            LastOpenedFile = null;
            OpenedViaList = false;
            Text = "SplatColour";

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

            LastOpenedFile = Path.GetFullPath(path);
        }

        private double ClampColour(double v)
        {
            if (v < 0.0) v = 0.0;
            if (v > 1.0) v = 1.0;
            return v;
        }

        private void menuSetParamsDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = Settings.Default.LastParamsDir;
            dialog.Description = "Select your Params/ folder";

            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = dialog.SelectedPath;

                Console.WriteLine(path);

                Settings.Default.LastParamsDir = path;
                Settings.Default.Save();
            }
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            SaveFileViaDialog();
        }

        private void menuLoad_Click(object sender, EventArgs e)
        {
            OpenFileViaDialog();
        }

        private void menuCopy_Click(object sender, EventArgs e)
        {
            CopyCurrentFile();
        }

        private void fileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fileList.SelectedItems.Count < 1)
            {
                return;
            }

            if (string.IsNullOrEmpty(Settings.Default.LastParamsDir))
            {
                MessageBox.Show(
                    "You haven't specified a Parameter/ directory!\nUse Options > Set Params dir to specify where your .params files are located.",
                    "SplatColour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            InkFileListItem item = (InkFileListItem) fileList.SelectedItems[0];
            InkFile file = item.File;
            string path = Path.Combine(Settings.Default.LastParamsDir, file.FileName);

            if (!File.Exists(path))
            {
                MessageBox.Show($"File {path} does not exist!", "SplatColour", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            OpenFile(path);
            OpenedViaList = true;
            Text = "SplatColour - " + file.Name;
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            var form = new AboutForm();
            form.ShowDialog(this);
        }
    }
}
