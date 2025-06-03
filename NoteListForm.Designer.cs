namespace DigitalNotesManager
{
    partial class NoteListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            txtSearch = new TextBox();
            label1 = new Label();
            label2 = new Label();
            cmbCategory = new ComboBox();
            btnSearch = new Button();
            downloadBtn = new Button();
            btnClearFilter = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 77);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(635, 187);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(12, 40);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(152, 31);
            txtSearch.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(96, 28);
            label1.TabIndex = 3;
            label1.Text = "Enter Text";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(192, 9);
            label2.Name = "label2";
            label2.Size = new Size(92, 28);
            label2.TabIndex = 4;
            label2.Text = "Category";
            // 
            // cmbCategory
            // 
            cmbCategory.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(183, 40);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(187, 33);
            cmbCategory.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(128, 128, 255);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(376, 40);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(106, 34);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // downloadBtn
            // 
            downloadBtn.BackColor = Color.ForestGreen;
            downloadBtn.FlatStyle = FlatStyle.Flat;
            downloadBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            downloadBtn.ForeColor = SystemColors.ButtonFace;
            downloadBtn.Location = new Point(489, 273);
            downloadBtn.Name = "downloadBtn";
            downloadBtn.Size = new Size(135, 34);
            downloadBtn.TabIndex = 7;
            downloadBtn.Text = "Download All";
            downloadBtn.UseVisualStyleBackColor = false;
            downloadBtn.Click += button1_Click;
            // 
            // btnClearFilter
            // 
            btnClearFilter.BackColor = Color.FromArgb(128, 128, 255);
            btnClearFilter.FlatStyle = FlatStyle.Popup;
            btnClearFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClearFilter.ForeColor = Color.White;
            btnClearFilter.Location = new Point(489, 40);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(94, 35);
            btnClearFilter.TabIndex = 8;
            btnClearFilter.Text = "Refresh";
            btnClearFilter.UseVisualStyleBackColor = false;
            btnClearFilter.Click += btnClearFilter_Click;
            // 
            // NoteListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 319);
            Controls.Add(btnClearFilter);
            Controls.Add(downloadBtn);
            Controls.Add(btnSearch);
            Controls.Add(cmbCategory);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSearch);
            Controls.Add(dataGridView1);
            Name = "NoteListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NoteListForm";
            Load += NoteListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtSearch;
        private Label label1;
        private Label label2;
        private ComboBox cmbCategory;
        private Button btnSearch;
        private Button downloadBtn;
        private Button btnClearFilter;
    }
}