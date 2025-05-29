using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DigitalNotesManager.Repository
{
    public class NoteRepository
    {
        private readonly string connectionString = "Server=ABDALLAH;Database=DNMDb;Trusted_Connection=True;TrustServerCertificate=True;";

        public void AddNote(Note note)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Notes (Title, Content, Category, CreationDate, ReminderDate, UserID)
                         VALUES (@Title, @Content, @Category, @CreationDate, @ReminderDate, @UserID)";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Title", note.Title);
                cmd.Parameters.AddWithValue("@Content", note.Content);
                cmd.Parameters.AddWithValue("@Category", note.Category);
                cmd.Parameters.AddWithValue("@CreationDate", note.CreationDate);
                cmd.Parameters.AddWithValue("@ReminderDate", note.ReminderDate);
                cmd.Parameters.AddWithValue("@UserID", note.UserID);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Note> GetNotesByUserId(int userId)
        {
            List<Note> notes = new List<Note>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Notes WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Note note = new Note
                    {
                        NoteID = Convert.ToInt32(reader["NoteID"]),
                        Title = reader["Title"].ToString(),
                        Content = reader["Content"].ToString(),
                        Category = reader["Category"].ToString(),
                        CreationDate = Convert.ToDateTime(reader["CreationDate"]),
                        ReminderDate = Convert.ToDateTime(reader["ReminderDate"]),
                        UserID = Convert.ToInt32(reader["UserID"])
                    };

                    notes.Add(note);
                }
            }

            return notes;
        }

        public Note GetNoteByID(int noteId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Notes WHERE NoteID = @NoteID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NoteID", noteId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Note
                    {
                        NoteID = Convert.ToInt32(reader["NoteID"]),
                        Title = reader["Title"].ToString(),
                        Content = reader["Content"].ToString(),
                        Category = reader["Category"].ToString(),
                        CreationDate = Convert.ToDateTime(reader["CreationDate"]),
                        ReminderDate = Convert.ToDateTime(reader["ReminderDate"]),
                        UserID = Convert.ToInt32(reader["UserID"])
                    };
                }
                return null;
            }
        }

        public void DeleteNote(int noteId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Notes WHERE NoteID = @NoteID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NoteID", noteId);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateNote(Note note)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Notes SET Title = @Title, Content = @Content, Category = @Category, 
                        ReminderDate = @ReminderDate WHERE NoteID = @NoteID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NoteID", note.NoteID);
                cmd.Parameters.AddWithValue("@Title", note.Title);
                cmd.Parameters.AddWithValue("@Content", note.Content);
                cmd.Parameters.AddWithValue("@Category", note.Category);
                cmd.Parameters.AddWithValue("@ReminderDate", note.ReminderDate);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }


}

