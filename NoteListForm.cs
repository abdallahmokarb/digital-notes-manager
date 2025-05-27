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
       
        public NoteListForm(int userID)
        {
            
            InitializeComponent();
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
    }
}
