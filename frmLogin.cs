using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CIS376_Project
{
    public partial class frmLogin : Form
    {
        public bool verifyLogin(string un, string pw) //function will verify the username and password have been typed correctly
        {
            StreamReader file = new StreamReader(@"Data\user.dat"); //opens user data file
            string line = ""; //will hold individual lines from file
            bool unFound = false; //username was found within data file?

            string corrUn = null; //correct username
            string corrPw = null; //correct password

            while ((line = file.ReadLine()) != null && unFound == false) //loops through line to find username in data file
            {
                string[] splitLine = line.Split(' '); //splits line into username, password, and names
                string username = splitLine[0]; //username from line
                string password = splitLine[1]; //password from line
                                
                if (un == username)
                {
                    unFound = true; //username is found in the data file
                    corrUn = username; //found username is set as the correct username
                    corrPw = password; //found password is set as the correct password
                }
            }

            file.Close();

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
        private void btnReg_Click(object sender, EventArgs e)
        {
            this.Hide(); //removes login form
            frmReg newForm = new frmReg(); //sets up registration form
            newForm.ShowDialog(); //shows registration form
        }
    }
}
