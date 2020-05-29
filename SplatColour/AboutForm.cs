using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
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
                FileName = "https://csnxs.uk",
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
