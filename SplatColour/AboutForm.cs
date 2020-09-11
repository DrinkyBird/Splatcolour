using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace SplatColour
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            var ver = Assembly.GetExecutingAssembly().GetName().Version;
            titleLine.Text = "SplatColour v" + ver;
        }

        private void websiteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var info = new ProcessStartInfo
            {
                FileName = "https://drinkybird.net",
                UseShellExecute = true
            };

            Process.Start(info);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
