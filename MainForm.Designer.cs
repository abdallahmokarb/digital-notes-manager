namespace DigitalNotesManager
{
    partial class MainForm
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
            CurrentUserName = new Label();
            CurrentUserID = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(12, 60);
            label1.Name = "label1";
            label1.Size = new Size(155, 41);
            label1.TabIndex = 1;
            label1.Text = "Welcome ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Navy;
            label2.Location = new Point(79, 266);
            label2.Name = "label2";
            label2.Size = new Size(612, 23);
            label2.TabIndex = 2;
            label2.Text = "This App under Designe, Programme, and Develope by Software Engineers";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Navy;
            label3.Location = new Point(12, 313);
            label3.Name = "label3";
            label3.Size = new Size(763, 28);
            label3.TabIndex = 3;
            label3.Text = "Neveen Reda , Roaa Ehab , Nardeen Emad , Mina AbuSeifain , Abdallah Mokarb";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CurrentUserName
            // 
            CurrentUserName.AutoSize = true;
            CurrentUserName.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CurrentUserName.ForeColor = Color.Navy;
            CurrentUserName.Location = new Point(149, 60);
            CurrentUserName.Name = "CurrentUserName";
            CurrentUserName.Size = new Size(0, 41);
            CurrentUserName.TabIndex = 4;
            // 
            // CurrentUserID
            // 
            CurrentUserID.AutoSize = true;
            CurrentUserID.Location = new Point(356, 140);
            CurrentUserID.Name = "CurrentUserID";
            CurrentUserID.Size = new Size(0, 20);
            CurrentUserID.TabIndex = 5;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Navy;
            label4.Location = new Point(329, 60);
            label4.Name = "label4";
            label4.Size = new Size(472, 41);
            label4.TabIndex = 6;
            label4.Text = "to Main Board of our Notes App";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(CurrentUserID);
            Controls.Add(CurrentUserName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label CurrentUserName;
        private Label CurrentUserID;
        private Label label4;
    }
}