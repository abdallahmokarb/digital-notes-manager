namespace DigitalNotesManager
{
    partial class RegisterForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            label1 = new Label();
            NameLabel = new Label();
            PasswordLabel = new Label();
            NameErrorLabel = new Label();
            PasswordErrorLabel = new Label();
            CreateAccount = new Button();
            GoToLogin = new Button();
            NameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(370, 20);
            label1.Name = "label1";
            label1.Size = new Size(418, 28);
            label1.TabIndex = 0;
            label1.Text = "Create an Account to Your Notes Manager ";
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(411, 112);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(56, 20);
            NameLabel.TabIndex = 1;
            NameLabel.Text = "Name :";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(411, 182);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(77, 20);
            PasswordLabel.TabIndex = 2;
            PasswordLabel.Text = "Password :";
            // 
            // NameErrorLabel
            // 
            NameErrorLabel.AutoSize = true;
            NameErrorLabel.Location = new Point(586, 149);
            NameErrorLabel.Name = "NameErrorLabel";
            NameErrorLabel.Size = new Size(0, 20);
            NameErrorLabel.TabIndex = 3;
            // 
            // PasswordErrorLabel
            // 
            PasswordErrorLabel.AutoSize = true;
            PasswordErrorLabel.Location = new Point(586, 218);
            PasswordErrorLabel.Name = "PasswordErrorLabel";
            PasswordErrorLabel.Size = new Size(0, 20);
            PasswordErrorLabel.TabIndex = 4;
            // 
            // CreateAccount
            // 
            CreateAccount.BackColor = Color.Navy;
            CreateAccount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateAccount.ForeColor = SystemColors.ButtonHighlight;
            CreateAccount.Location = new Point(504, 269);
            CreateAccount.Name = "CreateAccount";
            CreateAccount.Size = new Size(173, 44);
            CreateAccount.TabIndex = 5;
            CreateAccount.Text = "Create Now";
            CreateAccount.UseVisualStyleBackColor = false;
            CreateAccount.Click += CreateAccount_Click;
            // 
            // GoToLogin
            // 
            GoToLogin.Location = new Point(411, 404);
            GoToLogin.Name = "GoToLogin";
            GoToLogin.Size = new Size(373, 34);
            GoToLogin.TabIndex = 6;
            GoToLogin.Text = "Have an accont Signin Now";
            GoToLogin.UseVisualStyleBackColor = true;
            GoToLogin.Click += GoToLogin_Click;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(504, 109);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(247, 27);
            NameTextBox.TabIndex = 7;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(504, 175);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(247, 27);
            PasswordTextBox.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(-6, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(356, 449);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(PasswordTextBox);
            Controls.Add(NameTextBox);
            Controls.Add(GoToLogin);
            Controls.Add(CreateAccount);
            Controls.Add(PasswordErrorLabel);
            Controls.Add(NameErrorLabel);
            Controls.Add(PasswordLabel);
            Controls.Add(NameLabel);
            Controls.Add(label1);
            Name = "RegisterForm";
            Text = "Register an account ";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label NameLabel;
        private Label PasswordLabel;
        private Label NameErrorLabel;
        private Label PasswordErrorLabel;
        private Button CreateAccount;
        private Button GoToLogin;
        private TextBox NameTextBox;
        private TextBox PasswordTextBox;
        private PictureBox pictureBox1;
    }
}
