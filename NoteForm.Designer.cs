namespace DigitalNotesManager
{
    partial class NoteForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            Deletebutton2 = new Button();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(4, 68);
            label1.Name = "label1";
            label1.Size = new Size(119, 28);
            label1.TabIndex = 0;
            label1.Text = "Note Title :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(4, 124);
            label2.Name = "label2";
            label2.Size = new Size(109, 28);
            label2.TabIndex = 1;
            label2.Text = "Category :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(4, 178);
            label3.Name = "label3";
            label3.Size = new Size(120, 28);
            label3.TabIndex = 2;
            label3.Text = "Reminder : ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(119, 72);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(278, 27);
            textBox1.TabIndex = 3;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(119, 128);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(278, 28);
            comboBox1.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(119, 179);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(278, 27);
            dateTimePicker1.TabIndex = 5;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(119, 238);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(278, 251);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.BackColor = Color.DeepSkyBlue;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(119, 505);
            button1.Name = "button1";
            button1.Size = new Size(135, 50);
            button1.TabIndex = 7;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Deletebutton2
            // 
            Deletebutton2.BackColor = Color.DeepSkyBlue;
            Deletebutton2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Deletebutton2.ForeColor = SystemColors.ButtonFace;
            Deletebutton2.Location = new Point(262, 505);
            Deletebutton2.Name = "Deletebutton2";
            Deletebutton2.Size = new Size(135, 50);
            Deletebutton2.TabIndex = 8;
            Deletebutton2.Text = "Save Edit";
            Deletebutton2.UseVisualStyleBackColor = false;
            Deletebutton2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(4, 238);
            label4.Name = "label4";
            label4.Size = new Size(98, 28);
            label4.TabIndex = 9;
            label4.Text = "Content :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DeepSkyBlue;
            label5.Location = new Point(4, 22);
            label5.Name = "label5";
            label5.Size = new Size(152, 28);
            label5.TabIndex = 10;
            label5.Text = "Add New Note";
            // 
            // NoteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 171, 194);
            ClientSize = new Size(408, 568);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(Deletebutton2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "NoteForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NoteForm";
            Load += NoteForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private DateTimePicker dateTimePicker1;
        private RichTextBox richTextBox1;
        private Button button1;
        private Button Deletebutton2;
        private Label label4;
        private Label label5;
    }
}