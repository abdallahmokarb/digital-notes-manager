using DigitalNotesManager.Repository;

namespace DigitalNotesManager
{
    public partial class NoteForm : Form
    {
        public string NoteID { get; set; }
        public bool IsNewNote { get; set; } = true;
        public int userID;
        public Font ContentFont { get; set; } 
        public Color ContentColor { get; set; }  
        public delegate void NoteSavedEventHandler();
        public event NoteSavedEventHandler NoteSaved;
        public event EventHandler SelectionChanged;
        public RichTextBox MainTextBox => richTextBox1;

        public NoteForm(int ID)
        {
            InitializeComponent();
            this.userID = ID;
            richTextBox1.SelectionChanged += (s, e) => SelectionChanged?.Invoke(this, EventArgs.Empty);
            ContentFont = new Font("Arial", 12);  
            ContentColor = Color.White;  
        }

        public void LoadNoteFromText(string title, string content, string category, DateTime reminderDate, Font font = null, Color? color = null)
        {
            textBox1.Text = title ?? "";


            var (extractedFont, extractedColor, cleanContent) = ExtractFontColorFromContent(content);

            richTextBox1.Text = cleanContent ?? "";
            richTextBox1.SelectionFont = font ?? extractedFont;
            richTextBox1.SelectionColor = color ?? extractedColor;
            ContentFont = font ?? extractedFont;
            ContentColor = color ?? extractedColor;
            comboBox1.SelectedItem = comboBox1.Items.Contains(category) ? category : "General";
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
                            writer.WriteLine("Content: " + richTextBox1.Text);
                            writer.WriteLine("Category: " + (comboBox1.SelectedItem?.ToString() ?? "General"));
                            writer.WriteLine("ReminderDate: " + dateTimePicker1.Value.ToString());
                            writer.WriteLine("FontName: " + richTextBox1.SelectionFont.Name);
                            writer.WriteLine("FontSize: " + richTextBox1.SelectionFont.Size);
                            writer.WriteLine("FontStyle: " + richTextBox1.SelectionFont.Style);
                            writer.WriteLine("Color: " + richTextBox1.SelectionColor.Name);
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

                    Font currentFont = richTextBox1.SelectionFont ?? ContentFont;
                    Color currentColor = richTextBox1.SelectionColor;


                    string fontColorInfo = $"[FONT:{currentFont.Name},{currentFont.Size},{currentFont.Style}|COLOR:{currentColor.Name}]";
                    string contentWithFormatting = fontColorInfo + content;

                    Note newNote = new Note
                    {
                        Title = title,
                        Content = contentWithFormatting, 
                        Category = category ?? "General",
                        CreationDate = DateTime.Now,
                        ReminderDate = reminderDate,
                        UserID = userID,
                    };

                    NoteRepository repo = new NoteRepository();
                    repo.AddNote(newNote);
                    ContentFont = currentFont;
                    ContentColor = currentColor;
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


                    Font currentFont = richTextBox1.SelectionFont ?? ContentFont;
                    Color currentColor = richTextBox1.SelectionColor;


                    string fontColorInfo = $"[FONT:{currentFont.Name},{currentFont.Size},{currentFont.Style}|COLOR:{currentColor.Name}]";
                    string contentWithFormatting = fontColorInfo + content;

                    Note updatedNote = new Note
                    {
                        NoteID = noteId,
                        Title = title,
                        Content = contentWithFormatting,  
                        Category = category ?? "General",
                        CreationDate = existingNote.CreationDate,
                        ReminderDate = reminderDate,
                        UserID = userID
                    };
                    repo.UpdateNote(updatedNote);
                    ContentFont = currentFont;
                    ContentColor = currentColor;
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


        private (Font font, Color color, string cleanContent) ExtractFontColorFromContent(string content)
        {
            Font defaultFont = new Font("Arial", 12);
            Color defaultColor = Color.Black;

            if (string.IsNullOrEmpty(content) || !content.StartsWith("[FONT:"))
                return (defaultFont, defaultColor, content);

            try
            {
                int endIndex = content.IndexOf("]");
                if (endIndex == -1) return (defaultFont, defaultColor, content);

                string formatInfo = content.Substring(1, endIndex - 1);  
                string cleanContent = content.Substring(endIndex + 1); 

                string[] parts = formatInfo.Split('|');

                // Extract font info
                if (parts[0].StartsWith("FONT:"))
                {
                    string fontInfo = parts[0].Substring(5); // Remove "FONT:"
                    string[] fontParts = fontInfo.Split(',');

                    string fontName = fontParts[0];
                    float fontSize = float.Parse(fontParts[1]);
                    FontStyle fontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), fontParts[2]);

                    defaultFont = new Font(fontName, fontSize, fontStyle);
                }

                 if (parts.Length > 1 && parts[1].StartsWith("COLOR:"))
                {
                    string colorName = parts[1].Substring(6); 
                    defaultColor = Color.FromName(colorName);
                }

                return (defaultFont, defaultColor, cleanContent);
            }
            catch
            {
                return (defaultFont, defaultColor, content);
            }
        }
    }
}