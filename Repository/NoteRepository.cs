using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DigitalNotesManager.Repository
{
    public class NoteRepository
    {
        private readonly string connectionString = "Server=ABDALLAH;Database=DNMDb;Trusted_Connection=True;TrustServerCertificate=True;";
        private readonly Context context;

        public NoteRepository()
        {
            context = new Context();
        }

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
                string query = "SELECT * FROM Notes WHERE UserID = @UserID ORDER BY CreationDate DESC";
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

        // ******************** Filteration ***********

        public List<Note> SearchNotesByText(int userId, string text)
        {
            return context.Notes
                .Where(n => n.UserID == userId &&
                           (n.Title.Contains(text) || n.Content.Contains(text)))
                .OrderByDescending(n => n.CreationDate)
                .ToList();
        }

        public List<Note> GetNotesByCategory(int userId, string category)
        {
            return context.Notes
                .Where(n => n.UserID == userId && n.Category == category)
                .OrderByDescending(n => n.CreationDate)
                .ToList();
        }

        public List<Note> GetFilteredNotes(int userId, string text, string category)
        {
            using (var context = new Context())
            {
                var query = context.Notes.AsQueryable();

                query = query.Where(n => n.UserID == userId);

                if (!string.IsNullOrEmpty(text))
                {
                    query = query.Where(n => n.Title.Contains(text) || n.Content.Contains(text));
                }

                if (!string.IsNullOrEmpty(category))
                {
                    query = query.Where(n => n.Category == category);
                }

                return query
                    .OrderByDescending(n => n.CreationDate)
                    .ToList();
            }
        }

        public List<string> GetUserCategories(int userId)
        {
            using (var context = new Context())
            {
                return context.Notes
                    .Where(n => n.UserID == userId && n.Category != null)
                    .Select(n => n.Category)
                    .Distinct()
                    .ToList();
            }
        }
    }
}
