using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLApp
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            userNameField.Text = "Enter your name";
            userNameField.ForeColor = Color.Gray;

            userSurnameField.Text = "Enter your surname";
            userSurnameField.ForeColor = Color.Gray;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
          
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            passField.UseSystemPasswordChar = true;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            passField.UseSystemPasswordChar = true;
        }

        private void loginField_Enter(object sender, EventArgs e)
        {

        }

        private void loginField_Leave(object sender, EventArgs e)
        {

        }

        private void userNameField_Leave(object sender, EventArgs e)
        {
            if (userNameField.Text == "")
                userNameField.Text = "Enter your name";
        }

        private void userNameField_Enter(object sender, EventArgs e)
        {
            if (userNameField.Text == "Enter your name")
            { userNameField.Text = "";
              userNameField.ForeColor = Color.Black;
            }
                
        }

        private void userSurnameField_Enter(object sender, EventArgs e)
        {
            if (userSurnameField.Text == "Enter your surname")
            {
                userSurnameField.Text = "";
                userSurnameField.ForeColor = Color.Black;
            }
        }

        private void userSurnameField_Leave(object sender, EventArgs e)
        {
            if (userSurnameField.Text == "")
                userSurnameField.Text = "Enter your surname";
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (userNameField.Text == "Enter your name")
            {
                MessageBox.Show("Enter your name!");
                return;
            }

            if (userSurnameField.Text == "Enter your surname")
            {
                MessageBox.Show("Enter your surname!");
                return;
            }

            if(isUserExists()) 
            {
                return;
            }


            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `password`, `name`, `surname`) VALUES (@login, @password, @name, @surname)", db.getConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = loginField.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = passField.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = userNameField.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = userSurnameField.Text;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("you are create new account");
            }
            else
            {
                MessageBox.Show("you are DONOT create new account");
            }
            db.closeConnection();
        }

             Boolean isUserExists()
            {
                DB db = new DB();

                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.getConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginField.Text;


                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("user with this login already exists");
                    return true;
                }
                else
                {

                    return false;
                }
            }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
      }
    }

