using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalNotesManager
{
    public partial class LoginForm : Form
    {
        public LoginForm( )
        {
            InitializeComponent();
        }

        private void GoToRegisterForm_Click(object sender, EventArgs e)
        {

            this.Hide();
            RegisterForm loginForm = new RegisterForm();
            loginForm.ShowDialog();
            this.Close();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = NameTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Plz enter both username and password", "Validation Error");
                return;
            }

            using (var context = new Context())
            {
                var user = context.Users
                                  .FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    MessageBox.Show("Login successful", "Success");

                    this.Hide();
                    var mainForm = new MainForm(user.UserID, user.Username);
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("invalid username or password", "Login Failed");
                }
            }

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
