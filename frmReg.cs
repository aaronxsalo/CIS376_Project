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
    public partial class frmReg : Form
    {
        bool boxesCorrect()
        {
            bool empty = false; //is there an empty box?

            if(txtFirst.Text == "") //first name empty
            {
                txtFirst.BackColor = Color.Red;
                empty = true;
            }

            if (txtLast.Text == "") //last name empty
            {
                txtLast.BackColor = Color.Red;
                empty = true;
            }

            if (txtUser.Text == "") //username empty
            {
                txtUser.BackColor = Color.Red;
                empty = true;
            }

            if (txtPass.Text == "") //password empty
            {
                txtPass.BackColor = Color.Red;
                empty = true;
            }

            if (empty == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public frmReg()
        {
            InitializeComponent();
        }
        
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            StreamReader readFile = new StreamReader(@"Data\user.dat"); //opens user data file for reading
            string line = ""; //will hold individual lines from file
            bool unFound = false; //username was found within data file?
                  

            while ((line = readFile.ReadLine()) != null && unFound == false) //loops through line to find username in data file
            {
                string unCheck = line.Substring(0, line.IndexOf(" ")); //username from line
                                
                if (unCheck == txtUser.Text)
                {
                    unFound = true;
                }
            }

            readFile.Close();

            if (unFound == false && boxesCorrect()) //if username does not already exist than user will be added to file
            {
                StreamWriter writeFile = File.AppendText(@"Data\user.dat"); //opens user data file for writing

                writeFile.WriteLine(txtUser.Text + " " + txtPass.Text + " " + txtFirst.Text + " " + txtLast.Text);

                writeFile.Close();

                MessageBox.Show("You have been registered correctly.", "Registration Complete");

                this.Hide(); //removes registration form
                frmLogin newForm = new frmLogin(); //sets up login form
                newForm.ShowDialog(); //shows login form
            }
            else
            {
                if (!boxesCorrect())
                {
                    MessageBox.Show("Must fill out form completely.", "Registration Error"); //shows if username already exists
                }
                else
                {
                    MessageBox.Show("Username is already in use. Please choose another username.", "Registration Error"); //shows if username already exists
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide(); //removes registration form
            frmLogin newForm = new frmLogin(); //sets up login form
            newForm.ShowDialog(); //shows login form
        }

    }
}
