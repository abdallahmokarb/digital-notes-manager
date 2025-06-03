using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DigitalNotesManager.Repository;

namespace DigitalNotesManager
{
    public partial class ProgressForm : Form
    {
        private DataGridView dgvSummary;
        private Button btnExport;
        private int userId;
        private string username;

        public ProgressForm(int userId, string username)
        {
            InitializeComponent();
            this.userId = userId;
            this.username = username;

            this.Text = $"Progress Report for {username}";
            this.Size = new Size(1000, 550);

            dgvSummary = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 450,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            btnExport = new Button
            {
                Name = "btnExport",
                Text = "Export to TXT",
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = ColorTranslator.FromHtml("#18c9dd"),
                ForeColor = Color.White
            };

            btnExport.Click += BtnExport_Click;

            this.Controls.Add(btnExport);
            this.Controls.Add(dgvSummary);

            this.Load += ProgressForm_Load;
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            LoadNoteSummary();
        }

        private void LoadNoteSummary()
        {
            var notes = new NoteRepository().GetNotesByUserId(userId);

            DateTime now = DateTime.Now;

            DateTime startOfWeek = now.Date.AddDays(-(int)now.DayOfWeek + (int)DayOfWeek.Monday);
            if ((int)now.DayOfWeek == 0)
                startOfWeek = now.Date.AddDays(-6);

            DateTime startOfLastWeek = startOfWeek.AddDays(-7);
            DateTime endOfLastWeek = startOfWeek.AddSeconds(-1);

            DateTime startOfMonth = new DateTime(now.Year, now.Month, 1);
            DateTime startOfLastMonth = startOfMonth.AddMonths(-1);
            DateTime endOfLastMonth = startOfMonth.AddSeconds(-1);

            DateTime startOfYear = new DateTime(now.Year, 1, 1);
            DateTime startOfLastYear = startOfYear.AddYears(-1);
            DateTime endOfLastYear = startOfYear.AddSeconds(-1);

            var summary = notes
                .GroupBy(n => n.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    TotalThisWeek = g.Count(n => n.CreationDate >= startOfWeek && n.CreationDate <= now),
                    TotalLastWeek = g.Count(n => n.CreationDate >= startOfLastWeek && n.CreationDate <= endOfLastWeek),
                    TotalThisMonth = g.Count(n => n.CreationDate >= startOfMonth && n.CreationDate <= now),
                    TotalLastMonth = g.Count(n => n.CreationDate >= startOfLastMonth && n.CreationDate <= endOfLastMonth),
                    TotalThisYear = g.Count(n => n.CreationDate >= startOfYear && n.CreationDate <= now),
                    TotalLastYear = g.Count(n => n.CreationDate >= startOfLastYear && n.CreationDate <= endOfLastYear),
                    TotalAllTime = g.Count()
                })
                .ToList();

            if (summary.Any())
            {
                var totals = new
                {
                    Category = "Total all Categories",
                    TotalThisWeek = summary.Sum(x => x.TotalThisWeek),
                    TotalLastWeek = summary.Sum(x => x.TotalLastWeek),
                    TotalThisMonth = summary.Sum(x => x.TotalThisMonth),
                    TotalLastMonth = summary.Sum(x => x.TotalLastMonth),
                    TotalThisYear = summary.Sum(x => x.TotalThisYear),
                    TotalLastYear = summary.Sum(x => x.TotalLastYear),
                    TotalAllTime = summary.Sum(x => x.TotalAllTime)
                };
                summary.Add(totals);
            }

            dgvSummary.DataSource = summary;

            if (summary.Count == 0)
            {
                MessageBox.Show($"No notes found for {username}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dgvSummary.Columns["Category"].HeaderText = "Category";
                dgvSummary.Columns["TotalThisWeek"].HeaderText = "Total This Week";
                dgvSummary.Columns["TotalLastWeek"].HeaderText = "Total Last Week";
                dgvSummary.Columns["TotalThisMonth"].HeaderText = "Total This Month";
                dgvSummary.Columns["TotalLastMonth"].HeaderText = "Total Last Month";
                dgvSummary.Columns["TotalThisYear"].HeaderText = "Total This Year";
                dgvSummary.Columns["TotalLastYear"].HeaderText = "Total Last Year";
                dgvSummary.Columns["TotalAllTime"].HeaderText = "Total All Time";
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (dgvSummary.DataSource == null)
            {
                MessageBox.Show("No data to export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text File|*.txt", FileName = $"NotesSummary_{username}.txt" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sb = new StringBuilder();

                        sb.AppendLine($"Progress Report for {username}");
                        sb.AppendLine();

                        // headers
                        for (int i = 0; i < dgvSummary.Columns.Count; i++)
                        {
                            sb.Append(dgvSummary.Columns[i].HeaderText);
                            if (i < dgvSummary.Columns.Count - 1)
                                sb.Append("\t");
                        }
                        sb.AppendLine();

                        // data rows with category headers
                        for (int i = 0; i < dgvSummary.Rows.Count; i++)
                        {
                            var category = dgvSummary.Rows[i].Cells["Category"].Value?.ToString() ?? "";
                            if (category != "Total")
                            {
                                sb.AppendLine($"Progress Report for Category: {category}");
                            }
                            else
                            {
                                sb.AppendLine();
                                sb.AppendLine("Progress Report for All Categories (Totals)");
                            }

                            for (int j = 0; j < dgvSummary.Columns.Count; j++)
                            {
                                var cellValue = dgvSummary.Rows[i].Cells[j].Value?.ToString() ?? "";
                                sb.Append(cellValue);
                                if (j < dgvSummary.Columns.Count - 1)
                                    sb.Append("\t");
                            }
                            sb.AppendLine();
                            sb.AppendLine();  
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                        MessageBox.Show("Export to TXT successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting to TXT:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}