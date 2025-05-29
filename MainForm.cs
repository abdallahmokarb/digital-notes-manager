using DigitalNotesManager.Repository;
using System;
using System.IO;
using System.Windows.Forms;

namespace DigitalNotesManager
{
    public partial class MainForm : Form
    {
        private readonly NoteRepository _noteRepo = new NoteRepository();
        private readonly int _userID;
        private readonly string _username;

        public MainForm(int userID, string username)
        {
            InitializeComponent();

            // Fix for MDI error
            this.IsMdiContainer = true;

            _userID = userID;
            _username = username;

            CurrentUserID.Text = $" {_userID}";
            CurrentUserName.Text = $"Welcome Back {_username} ; Last Logged in was today at {DateTime.Now:T}";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);

            LoadNotes();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void MainForm_Load(object sender, EventArgs e) { }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoteForm form = new NoteForm(_userID);
            form.MdiParent = this;
            form.NoteSaved += LoadNotes;
            form.Show();
        }

        private void notesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoteListForm form = new NoteListForm(_userID);
            form.MdiParent = this;
            form.Show();

            // Subscribe existing NoteCards to NoteListForm
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is NoteCard noteCard)
                {
                    form.SubscribeToNoteCard(noteCard);
                }
            }
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
                noteForm.NoteSaved += LoadNotes;
                noteForm.MdiParent = this;
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

        private void LoadNotes()
        {
            var notes = _noteRepo.GetNotesByUserId(_userID);
            flowLayoutPanel1.Controls.Clear();

            foreach (var note in notes)
            {
                NoteCard card = new NoteCard();
                card.SetNote(note);
                card.Width = 410;
                card.NoteDeleted += LoadNotes;

                // Subscribe to NoteListForm if open
                foreach (Form form in Application.OpenForms)
                {
                    if (form is NoteListForm noteListForm)
                    {
                        noteListForm.SubscribeToNoteCard(card);
                    }
                }

                flowLayoutPanel1.Controls.Add(card);
            }
        }
    }
}
