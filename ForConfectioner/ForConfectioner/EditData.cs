using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForConfectioner
{
    public partial class EditData : Form
    {

        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=confectioners_workplace;");
        MySqlCommand command;
        public EditData(string username)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            BindGridCakes();
            BindGridRaw();
            BindGridShops();
            this.dataGridViewCakes.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            this.dataGridViewRaw.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            this.dataGridViewShops.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dataGridViewCakes.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
            dataGridViewRaw.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
            dataGridViewShops.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);

            labelUserName.Text = username;
        }

        private void backToMainPage_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPageForTheMainEmployee backToMainPage = new MainPageForTheMainEmployee(labelUserName.Text);
            backToMainPage.Show();

        }

       //виведення з бази даних найменування та код продукції в таблицю
        private void BindGridCakes()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `cakes`", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridViewCakes.DataSource = table;

            dataGridViewCakes.Columns["code"].HeaderText = "Код";
            dataGridViewCakes.Columns["name_of_cake"].HeaderText = "Продукція";
            dataGridViewCakes.Columns["price_for_the_kg"].HeaderText = "Ціна за кг";
        }

        //виведення з бази даних найменування та код сировини в таблицю
        private void BindGridRaw()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `raw`", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridViewRaw.DataSource = table;

            dataGridViewRaw.Columns["code"].HeaderText = "Код";
            dataGridViewRaw.Columns["name_of_raw"].HeaderText = "Сировина";
        }

        //виведення з бази даних найменування та код магазинів в таблицю
        private void BindGridShops()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `shops`", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridViewShops.DataSource = table;

            dataGridViewShops.Columns["code"].HeaderText = "Код";
            dataGridViewShops.Columns["name_of_shop"].HeaderText = "Магазин";
        }

        //додавання продукції
        private void btnAddCake_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO cakes (code, name_of_cake, price_for_the_kg) VALUES ('" + code.Text + "', '" + name_of_cake.Text + "', '" + textBoxPriceForTheKg.Text + "');";
            connection.Open();
            command = new MySqlCommand(query,connection);

            if (command.ExecuteNonQuery()==1)
            {
                MessageBox.Show("Успішно додано!");
                BindGridCakes();
                code.Clear();
                name_of_cake.Clear();
                textBoxPriceForTheKg.Clear();
            }
            else
            {
                MessageBox.Show("Помилка!");
            }

            connection.Close();
        }

       //видалення продукції
        private void btnDeleteCake_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM `cakes` WHERE `cakes`.`code` = '" +code.Text+ "'";
            connection.Open();
            command = new MySqlCommand(query, connection);

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успішно видалено!");
                BindGridCakes();
            }
            else
            {
                MessageBox.Show("Помилка!");
            }
            connection.Close();
        }

        //змінення назви продукції
        private void btnChangeCake_Click(object sender, EventArgs e)
        {
            string query = "UPDATE `cakes` SET `name_of_cake` = '" + name_of_cake.Text + "' WHERE `cakes`.`code` = '" + code.Text +"';";
            connection.Open();
            command = new MySqlCommand(query, connection);
       
            
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успішно змінено!");
                BindGridCakes();
            }
            else
            {
                MessageBox.Show("Помилка!");
            }

            connection.Close();
        }

        //додавання сировини
        private void btnAddRaw_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO raw (code, name_of_raw) VALUES ('" + code_of_raw.Text + "', '" + name_of_raw.Text + "');";
            connection.Open();
            command = new MySqlCommand(query, connection);
            
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успішно додано!");
                BindGridRaw();
            }
            else
            {
                MessageBox.Show("Помилка!");
            }

            connection.Close();
        }

        private void btnDeleteRaw_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM `raw` WHERE `raw`.`code` = '" + code_of_raw.Text + "'";
            connection.Open();
            command = new MySqlCommand(query, connection);

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успішно видалено!");
                BindGridRaw();
            }
            else
            {
                MessageBox.Show("Помилка!");
            }
            connection.Close();
        }

        //змінення назви сировини
        private void btnChangeRaw_Click(object sender, EventArgs e)
        {
            string query = "UPDATE `raw` SET `name_of_raw` = '" + name_of_raw.Text + "' WHERE `raw`.`code` = '" + code_of_raw.Text + "';";
            connection.Open();
            command = new MySqlCommand(query, connection);

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успішно змінено!");
                BindGridRaw();
            }
            else
            {
                MessageBox.Show("Помилка!");
            }

            connection.Close();
        }

        //додавання магазинів
        private void btnAddShop_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO shops (code, name_of_shop) VALUES ('" + code_of_shop.Text + "', '" + name_of_shop.Text + "');";
            connection.Open();
            command = new MySqlCommand(query, connection);

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успішно додано!");
                BindGridShops();
            }
            else
            {
                MessageBox.Show("Помилка!");
            }

            connection.Close();
        }

        //видалення магазинів
        private void btnDeleteShop_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM `shops` WHERE `shops`.`code` = '" + code_of_shop.Text + "'";
            connection.Open();
            command = new MySqlCommand(query, connection);

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успішно видалено!");
                BindGridShops();
            }
            else
            {
                MessageBox.Show("Помилка!");
            }
            connection.Close();
        }

        //змінення назви магазину
        private void btnChangeShop_Click(object sender, EventArgs e)
        {
            string query = "UPDATE `shops` SET `name_of_shop` = '" + name_of_shop.Text + "' WHERE `shops`.`code` = '" + code_of_shop.Text + "';";
            connection.Open();
            command = new MySqlCommand(query, connection);

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успішно змінено!");
                BindGridShops();
            }
            else
            {
                MessageBox.Show("Помилка!");
            }

            connection.Close();
        }

        private void textBoxPriceForTheKg_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && (e.KeyChar <= 39 || e.KeyChar >= 46) && number != 47 && number != 61)
            {
                e.Handled = true;
            }
        }
    }
}
