using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalNotesManager.Repository;

namespace DigitalNotesManager
{
    public partial class NoteForm : Form
    { 
        public string NoteID { get; set; }
        public bool IsNewNote { get; set; } = true;
        public int userID;
        public delegate void NoteSavedEventHandler();
        public event NoteSavedEventHandler NoteSaved;
        //cut & copy part
        public event EventHandler SelectionChanged;
        public RichTextBox MainTextBox
        {
            get { return richTextBox1; }
        }
        public NoteForm(int ID)
        {
            InitializeComponent();
            this.userID = ID;
            ////rest cut
            richTextBox1.SelectionChanged += (s, e) =>
            {
                SelectionChanged?.Invoke(this, EventArgs.Empty);
            };

        }

        public void LoadNoteFromText(string title, string content, string category, DateTime reminderDate)
        {
            textBox1.Text = title ?? "";
            richTextBox1.Text = content ?? "";
            if (!string.IsNullOrEmpty(category) && comboBox1.Items.Contains(category))
                comboBox1.SelectedItem = category;
            else
                comboBox1.SelectedItem = "General";
            dateTimePicker1.Value = reminderDate;
        }

        public void SaveNoteToFile()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save Note As";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog.FileName;

                    try
                    {
                        using (StreamWriter writer = new StreamWriter(path))
                        {
                            writer.WriteLine("Title: " + textBox1.Text);
                            writer.WriteLine("Content:");
                            writer.WriteLine(richTextBox1.Text);
                            writer.WriteLine("Category: " + (comboBox1.SelectedItem?.ToString() ?? "General"));
                            writer.WriteLine("ReminderDate: " + dateTimePicker1.Value.ToString());
                        }
                        MessageBox.Show("Note saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving note: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void NoteForm_Load(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count == 0)
            {
                comboBox1.Items.AddRange(new[] { "General", "Work", "Personal", "Ideas" });
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var title = textBox1.Text;
            var content = richTextBox1.Text;
            var category = comboBox1.SelectedItem?.ToString();
            var reminderDate = dateTimePicker1.Value;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("Title and content are required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (IsNewNote)
                {
                    Note newNote = new Note
                    {
                        Title = title,
                        Content = content,
                        Category = category ?? "General",
                        CreationDate = DateTime.Now,
                        ReminderDate = reminderDate,
                        UserID = userID,
                    };

                    NoteRepository repo = new NoteRepository();
                    repo.AddNote(newNote);
                    MessageBox.Show("Note saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                NoteSaved?.Invoke();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving note: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var title = textBox1.Text;
            var content = richTextBox1.Text;
            var category = comboBox1.SelectedItem?.ToString();
            var reminderDate = dateTimePicker1.Value;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("Title and content are required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsNewNote && !string.IsNullOrEmpty(NoteID) && int.TryParse(NoteID, out int noteId))
            {
                try
                {
                    NoteRepository repo = new NoteRepository();
                    var existingNote = repo.GetNoteByID(noteId);
                    if (existingNote == null)
                    {
                        MessageBox.Show($"Note not found in database. NoteID: {noteId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Note updatedNote = new Note
                    {
                        NoteID = noteId,
                        Title = title,
                        Content = content,
                        Category = category ?? "General",
                        CreationDate = existingNote.CreationDate,
                        ReminderDate = reminderDate,
                        UserID = userID
                    };
                    repo.UpdateNote(updatedNote);
                    MessageBox.Show("Note updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NoteSaved?.Invoke();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating note (NoteID: {noteId}): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Invalid note ID for editing: {NoteID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
