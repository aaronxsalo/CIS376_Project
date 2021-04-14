using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIS376_Project
{
    public partial class frmLogin : Form
    {
        public bool verifyLogin(string un, string pw) //function will verify the username and password have been typed correctly
        {
            //can be expanded on later!!!
            string corrUn = "username"; //correct username
            string corrPw = "password"; //correct password
            /////////////////////////////
            
            if (un == corrUn && pw == corrPw) //checks if arguments are correct strings
            {
                return true; //if they are
            }
            else
            {
                return false; //if they are not
            }
        }
        public frmLogin()
        {
            InitializeComponent();

            txtPassword.PasswordChar = '*'; //makes the password not visible while typing
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text; 
            string password = txtPassword.Text;

            if (verifyLogin(username, password)) //checks that login info is correct
            {
                this.Hide(); //removes login form
                frmMain newForm = new frmMain(); //sets up main form
                newForm.ShowDialog(); //shows main form
            }
            else //if incorrect, shows error message box
            {
                MessageBox.Show("Incorrect username or password entered.", "Login Error");
            }
        }
    }
}
