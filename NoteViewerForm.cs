using System;
using System.Drawing;
using System.Windows.Forms;
 
namespace DigitalNotesManager
{
    public partial class NoteViewerForm : Form
    {
        private Label lblTitleLabel;
        private Label lblTitle;
        private Label lblCategoryLabel;
        private Label lblCategory;
        private Label lblContentLabel;
        private TextBox txtContent;
        private Label lblReminderLabel;
        private Label lblReminder;

        public NoteViewerForm()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Note Viewer";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            lblTitleLabel = new Label() { Text = "Title:", Location = new Point(20, 20), AutoSize = true };
            lblTitle = new Label() { Location = new Point(100, 20), AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Bold) };

            lblCategoryLabel = new Label() { Text = "Category:", Location = new Point(20, 50), AutoSize = true };
            lblCategory = new Label() { Location = new Point(100, 50), AutoSize = true };

            lblContentLabel = new Label() { Text = "Content:", Location = new Point(20, 80), AutoSize = true };
            txtContent = new TextBox()
            {
                Location = new Point(100, 80),
                Size = new Size(450, 250),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical
            };

            lblReminderLabel = new Label() { Text = "Reminder:", Location = new Point(20, 350), AutoSize = true };
            lblReminder = new Label() { Location = new Point(100, 350), AutoSize = true };


            this.Controls.Add(lblTitleLabel);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblCategoryLabel);
            this.Controls.Add(lblCategory);
            this.Controls.Add(lblContentLabel);
            this.Controls.Add(txtContent);
            this.Controls.Add(lblReminderLabel);
            this.Controls.Add(lblReminder);
        }

        public void LoadNote(Note note)
        {
            lblTitle.Text = note.Title;
            lblCategory.Text = note.Category;
            txtContent.Text = note.Content;
            lblReminder.Text = note.ReminderDate.ToString("f");  
        }
    }
}
