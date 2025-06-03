namespace DigitalNotesManager
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            pictureBox1 = new PictureBox();
            PasswordTextBox = new TextBox();
            NameTextBox = new TextBox();
            GoToRegisterForm = new Button();
            LoginButton = new Button();
            PasswordErrorLabel = new Label();
            NameErrorLabel = new Label();
            PasswordLabel = new Label();
            NameLabel = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(3, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(356, 449);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(513, 178);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(247, 27);
            PasswordTextBox.TabIndex = 18;
            PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(513, 112);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(247, 27);
            NameTextBox.TabIndex = 17;
            // 
            // GoToRegisterForm
            // 
            GoToRegisterForm.Location = new Point(402, 404);
            GoToRegisterForm.Name = "GoToRegisterForm";
            GoToRegisterForm.Size = new Size(373, 34);
            GoToRegisterForm.TabIndex = 16;
            GoToRegisterForm.Text = "Do not have an account Create a free one now";
            GoToRegisterForm.UseVisualStyleBackColor = true;
            GoToRegisterForm.Click += GoToRegisterForm_Click;
            // 
            // LoginButton
            // 
            LoginButton.BackColor = Color.DodgerBlue;
            LoginButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginButton.ForeColor = SystemColors.ButtonHighlight;
            LoginButton.Location = new Point(513, 272);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(173, 44);
            LoginButton.TabIndex = 15;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = false;
            LoginButton.Click += LoginButton_Click;
            // 
            // PasswordErrorLabel
            // 
            PasswordErrorLabel.AutoSize = true;
            PasswordErrorLabel.Location = new Point(595, 221);
            PasswordErrorLabel.Name = "PasswordErrorLabel";
            PasswordErrorLabel.Size = new Size(0, 20);
            PasswordErrorLabel.TabIndex = 14;
            // 
            // NameErrorLabel
            // 
            NameErrorLabel.AutoSize = true;
            NameErrorLabel.Location = new Point(595, 152);
            NameErrorLabel.Name = "NameErrorLabel";
            NameErrorLabel.Size = new Size(0, 20);
            NameErrorLabel.TabIndex = 13;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(420, 185);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(77, 20);
            PasswordLabel.TabIndex = 12;
            PasswordLabel.Text = "Password :";
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(420, 115);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(56, 20);
            NameLabel.TabIndex = 11;
            NameLabel.Text = "Name :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(395, 27);
            label1.Name = "label1";
            label1.Size = new Size(380, 28);
            label1.TabIndex = 10;
            label1.Text = "Login to Your Notes Manager Account ";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(PasswordTextBox);
            Controls.Add(NameTextBox);
            Controls.Add(GoToRegisterForm);
            Controls.Add(LoginButton);
            Controls.Add(PasswordErrorLabel);
            Controls.Add(NameErrorLabel);
            Controls.Add(PasswordLabel);
            Controls.Add(NameLabel);
            Controls.Add(label1);
            Name = "LoginForm";
            Text = "Login to your Account";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox PasswordTextBox;
        private TextBox NameTextBox;
        private Button GoToRegisterForm;
        private Button LoginButton;
        private Label PasswordErrorLabel;
        private Label NameErrorLabel;
        private Label PasswordLabel;
        private Label NameLabel;
        private Label label1;
    }
}