using DigitalNotesManager.Repository;
using Microsoft.VisualBasic.ApplicationServices;
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
        private List<Note> notes = new List<Note>();
        private NotifyIcon notifyIcon;



        public MainForm(int userID, string username)
        {
            InitializeComponent();
            InitializeNotifyIcon();

            // Fix for MDI error
            this.IsMdiContainer = true;

            _userID = userID;
            _username = username;

            CurrentUserID.Text = $" {_userID}";
            CurrentUserName.Text = $"Welcome Back {_username} ; Last Logged in was today at {DateTime.Now:T}";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);

            LoadNotes();



        }


        private void InitializeNotifyIcon()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Visible = true;  
            notifyIcon.Icon = SystemIcons.Information;  
            notifyIcon.BalloonTipTitle = "Reminder";

        }

        private void CheckReminders()
        {
            DateTime today = DateTime.Today;

            var todayReminders = notes
                .Where(n => n.ReminderDate.Date == today)
                .ToList();

            if (todayReminders.Any())
            {
                string message = $"Hi {_username}, You have {todayReminders.Count} reminders today";
                notifyIcon.BalloonTipText = message;
                notifyIcon.ShowBalloonTip(5000);
            }
        }



        private void fileToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void MainForm_Load(object sender, EventArgs e)
        {

            cutToolStripMenuItem.Enabled = false;
            copyToolStripMenuItem.Enabled = false;
            pasteToolStripMenuItem.Enabled = false;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoteForm form = new NoteForm(_userID);
            form.MdiParent = this;
            form.NoteSaved += LoadNotes;
            //nardine
            form.FormClosed += NoteForm_FormClosed;
            form.SelectionChanged += NoteForm_SelectionChanged;
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
                ///nardine
                noteForm.FormClosed += NoteForm_FormClosed;
                noteForm.SelectionChanged += NoteForm_SelectionChanged;
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
             notes = _noteRepo.GetNotesByUserId(_userID);
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
            CheckReminders();  

        }

        private void btnShowProgress_Click(object sender, EventArgs e)
        {

            ProgressForm progressForm = new ProgressForm(_userID, _username);
            progressForm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();


        }

        //---------------------------------------------- neveen
        //private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    this.LayoutMdi(MdiLayout.TileHorizontal);
        //}

        //private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    this.LayoutMdi(MdiLayout.Cascade);

        //}

        private void tileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);

        }

        private void cascadeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);

        }


        /////Nardine
        private void NoteForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (!Application.OpenForms.OfType<NoteForm>().Any())
            {
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                pasteToolStripMenuItem.Enabled = false;
            }

        }

        private void NoteForm_SelectionChanged(object sender, EventArgs e)
        {
            var note = sender as NoteForm;
            if (note != null)
            {
                var rtb = note.MainTextBox;

                cutToolStripMenuItem.Enabled = !string.IsNullOrEmpty(rtb.SelectedText);
                ////
                copyToolStripMenuItem.Enabled = !string.IsNullOrEmpty(rtb.SelectedText);
                pasteToolStripMenuItem.Enabled = Clipboard.ContainsText();

            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var note = Application.OpenForms.OfType<NoteForm>().FirstOrDefault();
            if (note != null)
            {
                var rtb = note.MainTextBox;
                if (!string.IsNullOrEmpty(rtb.SelectedText))
                {
                    rtb.Cut();
                }
            }


        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var note = Application.OpenForms.OfType<NoteForm>().FirstOrDefault();
            if (note != null)
            {
                var rtb = note.MainTextBox;
                if (!string.IsNullOrEmpty(rtb.SelectedText))
                {
                    rtb.Copy();
                }
            }

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var note = Application.OpenForms.OfType<NoteForm>().FirstOrDefault();
            if (note != null)
            {
                var rtb = note.MainTextBox;
                if (Clipboard.ContainsText())
                {
                    rtb.Paste();
                }
            }
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
        }


       


      
       

      
    }
}
   

