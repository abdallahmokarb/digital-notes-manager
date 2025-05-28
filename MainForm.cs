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

    public partial class MainForm : Form
    {
        private readonly int _userID;
        private readonly string _username;
        public MainForm(int userID, string username)
        {
            InitializeComponent();

            _userID = userID;
            _username = username;

            CurrentUserID.Text = $"{{ {_userID} }}";
            CurrentUserName.Text = $"{{ {_username} }}";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
