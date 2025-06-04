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


        private List<Note> _currentNotes = new List<Note>();

        public NoteListForm(int userID)
        {
            InitializeComponent();
            _userID = userID;
            LoadUserNotes(_userID);
            LoadCategories();

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


        ///****************Filter*******************
        private void FilterNotes()
        {
            string searchText = txtSearch.Text.Trim();
            string selectedCategory = cmbCategory.SelectedItem?.ToString();

            NoteRepository repo = new NoteRepository();

            if (string.IsNullOrEmpty(searchText) && string.IsNullOrEmpty(selectedCategory))
            {

                LoadUserNotes(_userID);
            }
            else
            {
                List<Note> filteredNotes = repo.GetFilteredNotes(_userID, searchText, selectedCategory);
                dataGridView1.DataSource = filteredNotes;
            }
        }



        private void LoadCategories()
        {
            NoteRepository repo = new NoteRepository();
            var categories = repo.GetUserCategories(_userID); // <-- you’ll write this

            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(categories.ToArray());
            cmbCategory.SelectedIndex = -1; // nothing selected by default
        }


        ///////////////Downloading


        private void ExportNotesToCsv()
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No notes to download.", "Download", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV file (*.csv)|*.csv",
                FileName = "Notes.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false))
                    {
                        // Write header
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            sw.Write(dataGridView1.Columns[i].HeaderText);
                            if (i < dataGridView1.Columns.Count - 1)
                                sw.Write(",");
                        }
                        sw.WriteLine();

                        // Write rows
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                                {
                                    sw.Write(row.Cells[i].Value?.ToString()?.Replace(",", " ")); // handle commas
                                    if (i < dataGridView1.Columns.Count - 1)
                                        sw.Write(",");
                                }
                                sw.WriteLine();
                            }
                        }
                    }

                    MessageBox.Show("Notes downloaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting notes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        //**********Refresh************
        private void ClearFiltersAndReload()
        {
            txtSearch.Clear();
            cmbCategory.SelectedIndex = -1;
            LoadUserNotes(_userID);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ExportNotesToCsv();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FilterNotes();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            ClearFiltersAndReload();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                int noteId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["NoteID"].Value);

                NoteRepository repo = new NoteRepository();
                var note = repo.GetNoteByID(noteId);

                if (note != null)
                {
                    NoteViewerForm viewerForm = new NoteViewerForm();
                    viewerForm.LoadNote(note);
                    viewerForm.Show(); // opens in new window
                }
                else
                {
                    MessageBox.Show("Note not found.");
                }
            }
        }

        private void SortBtn_Click(object sender, EventArgs e)
        {
            if (_currentNotes == null || !_currentNotes.Any())
            {
                 MessageBox.Show("You already sorted notes by latest created date");
                return;
            }

            var sortedNotes = _currentNotes.OrderByDescending(n => n.CreationDate).ToList();
 

            _currentNotes = sortedNotes;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = sortedNotes;
            MessageBox.Show("Sorting triggered!");
        }
    }
}
