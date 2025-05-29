namespace DigitalNotesManager
{
    partial class NoteCard
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
            lblTitle = new Label();
            lblContent = new Label();
            lblCategory = new Label();
            lblCreated = new Label();
            lblReminder = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            DoneButton = new Button();
            EditButton = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(79, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(0, 20);
            lblTitle.TabIndex = 0;
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.Location = new Point(85, 53);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(0, 20);
            lblContent.TabIndex = 1;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(60, 91);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(0, 20);
            lblCategory.TabIndex = 2;
            // 
            // lblCreated
            // 
            lblCreated.AutoSize = true;
            lblCreated.Location = new Point(101, 126);
            lblCreated.Name = "lblCreated";
            lblCreated.Size = new Size(0, 20);
            lblCreated.TabIndex = 3;
            // 
            // lblReminder
            // 
            lblReminder.AutoSize = true;
            lblReminder.Location = new Point(101, 168);
            lblReminder.Name = "lblReminder";
            lblReminder.Size = new Size(0, 20);
            lblReminder.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 14);
            label1.Name = "label1";
            label1.Size = new Size(59, 20);
            label1.TabIndex = 5;
            label1.Text = "Name :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 53);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 6;
            label2.Text = "Content :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 91);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 7;
            label3.Text = "Cata :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 126);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 8;
            label4.Text = "Created at :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 168);
            label5.Name = "label5";
            label5.Size = new Size(85, 20);
            label5.TabIndex = 9;
            label5.Text = "reminder  :";
            // 
            // DoneButton
            // 
            DoneButton.ForeColor = Color.Gray;
            DoneButton.Location = new Point(312, 78);
            DoneButton.Name = "DoneButton";
            DoneButton.Size = new Size(94, 29);
            DoneButton.TabIndex = 10;
            DoneButton.Text = "Done";
            DoneButton.UseVisualStyleBackColor = true;
            DoneButton.Click += DoneButton_Click;
            // 
            // EditButton
            // 
            EditButton.ForeColor = Color.Gray;
            EditButton.Location = new Point(312, 122);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(94, 29);
            EditButton.TabIndex = 11;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // button3
            // 
            button3.ForeColor = Color.Gray;
            button3.Location = new Point(312, 164);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 12;
            button3.Text = "Del";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // NoteCard
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 171, 194);
            Controls.Add(button3);
            Controls.Add(EditButton);
            Controls.Add(DoneButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblReminder);
            Controls.Add(lblCreated);
            Controls.Add(lblCategory);
            Controls.Add(lblContent);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Margin = new Padding(1);
            Name = "NoteCard";
            Size = new Size(461, 208);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblContent;
        private Label lblCategory;
        private Label lblCreated;
        private Label lblReminder;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button DoneButton;
        private Button EditButton;
        private Button button3;
    }
}