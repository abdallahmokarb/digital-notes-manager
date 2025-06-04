using DigitalNotesManager.Repository;
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
    public partial class NoteCard : UserControl
    {
        private Note note;
        public delegate void NoteDeletedEventHandler();
        public event NoteDeletedEventHandler NoteDeleted;
        public event EventHandler CategoryChanged;


        public NoteCard()
        {
            InitializeComponent();
            this.CategoryChanged += (s, e) =>
            {
                this.BackColor = Color.LightCoral;
            };
        }

        public void SetNote(Note note)
        {
            this.note = note;
            lblTitle.Text = note?.Title ?? "No Title";
            lblContent.Text = note?.Content ?? "No Content";
            lblCategory.Text = note?.Category ?? "General";
            lblCreated.Text = note?.CreationDate.ToShortDateString() ?? DateTime.Now.ToShortDateString();
            lblReminder.Text = note?.ReminderDate.ToShortDateString() ?? DateTime.Now.ToShortDateString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (note == null || note.NoteID <= 0)
            {
                MessageBox.Show("Invalid note selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                NoteRepository repo = new NoteRepository();
                repo.DeleteNote(note.NoteID);
                NoteDeleted?.Invoke();
                if (this.Parent != null)
                {
                    this.Parent.Invoke((MethodInvoker)(() => this.Parent.Controls.Remove(this)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting note: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            if (note != null && note.NoteID > 0)
            {
                this.BackColor = Color.LightGreen;
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (note == null || note.NoteID <= 0)
            {
                MessageBox.Show("Invalid note selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                NoteForm editForm = new NoteForm(note.UserID)
                {
                    IsNewNote = false,
                    NoteID = note.NoteID.ToString()
                };
                editForm.LoadNoteFromText(note.Title, note.Content, note.Category, note.ReminderDate);

                editForm.NoteSaved += () =>
                {
                    try
                    {
                        var updatedNote = new NoteRepository().GetNoteByID(note.NoteID);
                        if (updatedNote != null)
                        {
                            CheckCategoryChangeAndRaise(note, updatedNote);

                            SetNote(updatedNote);
                        }
                        else
                        {
                            MessageBox.Show("Failed to refresh note.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error refreshing note: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                editForm.MdiParent = this.FindForm()?.MdiParent;
                editForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening edit form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        ///fire event
        private void CheckCategoryChangeAndRaise(Note oldNote, Note newNote)
        {
            if (oldNote.Category != newNote.Category)
            {
                OnCategoryChanged();
            }
        }

        protected virtual void OnCategoryChanged()
        {
            CategoryChanged?.Invoke(this, EventArgs.Empty);
        }

        ///
        private void NoteCard_Load(object sender, EventArgs e)
        {

        }




    }
}

