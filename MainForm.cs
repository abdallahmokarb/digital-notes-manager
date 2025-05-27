using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalNotesManager
{

    public partial class MainForm : Form
    {
        private readonly int _userID;
        private readonly string _username;
        public MainForm(int userID, string username)
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            _userID = userID;
            _username = username;

            CurrentUserID.Text = $"{{ {_userID} }}";
            CurrentUserName.Text = $"{{ {_username} }}";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoteForm form = new NoteForm(_userID);
            form.MdiParent = this;
            form.Show();
        }

        private void notesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoteListForm form = new NoteListForm(_userID);
            form.MdiParent = this;
            form.Show();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string[] lines = File.ReadAllLines(filePath);

                string title = "";
                string content = "";
                string category = "";
                DateTime reminderDate = DateTime.Now;

                foreach (var line in lines)
                {
                    if (line.StartsWith("Title:"))
                        title = line.Substring(6).Trim();
                    else if (line.StartsWith("Content:"))
                        content = line.Substring(8).Trim();
                    else if (line.StartsWith("Category:"))
                        category = line.Substring(9).Trim();
                    else if (line.StartsWith("ReminderDate:"))
                        reminderDate = DateTime.Parse(line.Substring(13).Trim());
                }


                NoteForm noteForm = new NoteForm(_userID);
                noteForm.LoadNoteFromText(title, content, category, reminderDate);
                noteForm.Show();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            foreach (Form form in Application.OpenForms)
            {
                if (form is NoteForm noteForm)
                {
                    noteForm.SaveNoteToFile();
                    return;
                }
            }

           
            MessageBox.Show("Please open a note before saving.", "No Note Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
