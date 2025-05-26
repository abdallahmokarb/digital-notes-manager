namespace DigitalNotesManager
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }



        private void CreateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                string username = NameTextBox.Text.Trim();
                string password = PasswordTextBox.Text.Trim();


                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Plz enter both Name and Password.", "Validation Error");
                    return;
                }

                using (var context = new Context())
                {
                    var user = new User
                    {
                        Username = username,
                        Password = password
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                    MessageBox.Show("account created successfully", "Success");

                    // clear fields after registration
                    NameTextBox.Text = "";
                    PasswordTextBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error");
            }
        }

        private void GoToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }










    }
}
