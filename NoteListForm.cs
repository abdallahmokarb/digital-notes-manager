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
    public partial class NoteListForm : Form
    {
        private readonly int _userID;

        public NoteListForm(int userID)
        {
            InitializeComponent();
            _userID = userID;
            LoadUserNotes(userID);
        }

        private void NoteListForm_Load(object sender, EventArgs e)
        {
        }

        private void LoadUserNotes(int userId)
        {
            NoteRepository repo = new NoteRepository();
            var notes = repo.GetNotesByUserId(userId);
            dataGridView1.DataSource = notes;
        }

        public void ShowNoteForm()
        {
            NoteForm noteForm = new NoteForm(_userID);
            noteForm.NoteSaved += () => LoadUserNotes(_userID);
            noteForm.ShowDialog();
        }

        public void SubscribeToNoteCard(NoteCard noteCard)
        {
            noteCard.NoteDeleted += () => LoadUserNotes(_userID);
        }
    }
}
