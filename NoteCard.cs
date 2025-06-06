using DigitalNotesManager.Repository;

namespace DigitalNotesManager
{
    public partial class NoteCard : UserControl
    {
        private Note note;
        private Font contentFont; 
        private Color contentColor;  
        public delegate void NoteDeletedEventHandler();
        public event NoteDeletedEventHandler NoteDeleted;
        public event EventHandler CategoryChanged;

        public NoteCard()
        {
            InitializeComponent();
            this.CategoryChanged += (s, e) => this.BackColor = Color.LightCoral;
            contentFont = new Font("Arial", 12);  
            contentColor = Color.White;  
        }

        public void SetNote(Note note, Font font = null, Color? color = null)
        {
            this.note = note;
            lblTitle.Text = note?.Title ?? "No Title";
            lblCategory.Text = note?.Category ?? "General";
            lblCreated.Text = note?.CreationDate.ToShortDateString() ?? DateTime.Now.ToShortDateString();
            lblReminder.Text = note?.ReminderDate.ToShortDateString() ?? DateTime.Now.ToShortDateString();


            var (extractedFont, extractedColor, cleanContent) = ExtractFontColorFromContent(note?.Content ?? "");

            lblContent.Text = cleanContent ?? "No Content";
            lblContent.Font = font ?? extractedFont;
            lblContent.ForeColor = color ?? extractedColor;
            contentFont = font ?? extractedFont;
            contentColor = color ?? extractedColor;
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
                editForm.LoadNoteFromText(note.Title, note.Content, note.Category, note.ReminderDate, contentFont, contentColor);

                editForm.NoteSaved += () =>
                {
                    try
                    {
                        var updatedNote = new NoteRepository().GetNoteByID(note.NoteID);
                        if (updatedNote != null)
                        {
                            CheckCategoryChangeAndRaise(note, updatedNote);
                            SetNote(updatedNote, editForm.ContentFont, editForm.ContentColor);
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

        private void NoteCard_Load(object sender, EventArgs e) { }

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

                 if (parts[0].StartsWith("FONT:"))
                {
                    string fontInfo = parts[0].Substring(5); 
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