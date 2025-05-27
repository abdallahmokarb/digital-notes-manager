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

        public NoteForm(int ID)
        {
            InitializeComponent();
            this.userID = ID;
        }
        public void LoadNoteFromText(string title, string content, string category, DateTime reminderDate)
        {
            textBox1.Text = title;
            richTextBox1.Text = content;
            comboBox1.SelectedItem = category; 
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
                        }

                        MessageBox.Show("Note saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving note: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void NoteForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var title = textBox1.Text;
            var content = richTextBox1.Text;
            var category = comboBox1.SelectedItem?.ToString();
            var reminderDate = dateTimePicker1.Value;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content) )
                {
                MessageBox.Show("Title and content are required");
                return;
                 }
            if (IsNewNote) {
                Note newNote = new Note
                {
                    Title = title,
                    Content = content,
                    Category = category?? "General",
                    CreationDate = DateTime.Now,
                    ReminderDate = reminderDate,
                    UserID = userID,
                };

                NoteRepository repo = new NoteRepository();
                repo.AddNote(newNote);
            }
            else {
                // update to Database
            }
            MessageBox.Show("Note saved successfully.");
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
