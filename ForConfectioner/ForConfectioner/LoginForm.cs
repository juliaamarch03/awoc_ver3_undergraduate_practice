using MySql.Data.MySqlClient;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForConfectioner
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

  
        private void signInBtn_Click(object sender, EventArgs e)
        {
            String username = usernameField.Text;
            String password = passwordField.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE  `login` = @um AND `password` = @pw", db.getConnection());
            command.Parameters.Add("@um", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pw", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {      
                MainPageForTheMainEmployee mainpage = new MainPageForTheMainEmployee(table.Rows[0][1].ToString());
                mainpage.Show(); 
                this.Hide();
            }
                
            else
                MessageBox.Show("Логін або пароль введено неправильно!");

        }

    }
}
