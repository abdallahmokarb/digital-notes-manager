using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DigitalNotesManager
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "About - Digital Notes Manager";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;


            Label titleLabel = new Label
            {
                Text = "Digital Notes Manager",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 20)
            };


            Label descriptionLabel = new Label
            {
                Text =
                    "Team 5 Notes Manager App\n" +
                    "Version: 0.0.1\n\n" +
                    "Digital Notes Manager is a Windows Forms application that allows users to create, edit, organize, and manage their personal notes efficiently.\n" +
                    "The system supports a multi-document interface, custom control for note categorization.",
                AutoSize = true,
                MaximumSize = new Size(540, 0),
                Location = new Point(20, 70)
            };


            Label teamLabel = new Label
            {
                Text = "Designed, Programmed, and Developed by:\n" +
                       "Neveen Reda\nRoaa Ehab\nNardeen Emad\nMina AbuSeifain\nAbdallah Mokarb",
                AutoSize = true,
                Location = new Point(20, 210)
            };


            Label licenseLabel = new Label
            {
                Text = "Licensed under the MIT License",
                AutoSize = true,
                Location = new Point(20, 330)
            };


            LinkLabel githubLink = new LinkLabel
            {
                Text = "GitHub : github.com/abdallahmokarb/digital-notes-manager",
                AutoSize = true,
                Location = new Point(20, 350)
            };
            githubLink.LinkClicked += GithubLink_LinkClicked;

          


            Controls.Add(titleLabel);
            Controls.Add(descriptionLabel);
            Controls.Add(teamLabel);
            Controls.Add(licenseLabel);
            Controls.Add(githubLink);
         }

        private void GithubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/abdallahmokarb/digital-notes-manager",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link" + ex.Message);
            }
        }
    }
}
