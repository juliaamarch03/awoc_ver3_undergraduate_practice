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
using MySql.Data.Types;

namespace ForConfectioner
{
    public partial class DailyReport : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=confectioners_workplace;Convert Zero Datetime=True");
        MySqlCommand command;
        public DailyReport(string role)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            BindGridCakes();
            BindGridRaw();
            BindGridShops();
            textBoxUserCakes.Text = role;
            textBoxRawEmployee.Text = role;

            this.dataGridViewProduction.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            this.dataGridViewRaw.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            this.dataGridViewDailyReportShops.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dataGridViewDailyReportShops.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Regular);
            dataGridViewProduction.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Regular);
            dataGridViewRaw.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Regular);
        }

        private void BindGridRaw()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `daily_report_raw`", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridViewRaw.DataSource = table;

            dataGridViewRaw.Columns["id"].HeaderText = "Код";
            dataGridViewRaw.Columns["name_of_raw"].HeaderText = "Найменування сировини";
            dataGridViewRaw.Columns["used_raw"].HeaderText = "Використана сировина за день (кг)";
            dataGridViewRaw.Columns["date"].HeaderText = "Дата";
            dataGridViewRaw.Columns["employee"].HeaderText = "Зміна";

        }

        private void backToMainPage_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPageForTheMainEmployee backToMainPage = new MainPageForTheMainEmployee(textBoxUserCakes.Text);
            backToMainPage.Show();
            
        }

        private void BindGridShops()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `id` , `name_of_cake` , `quantity` , `date` , " +
                "`confectioner` , `status` , `sent_to_the_shop`, `date_sent` FROM `daily_report_cakes`", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridViewDailyReportShops.DataSource = table;

            dataGridViewDailyReportShops.Columns["id"].HeaderText = "Код продукції";
            dataGridViewDailyReportShops.Columns["name_of_cake"].HeaderText = "Найменування продукції";
            dataGridViewDailyReportShops.Columns["quantity"].HeaderText = "Кількість";
            dataGridViewDailyReportShops.Columns["date"].HeaderText = "Дата випікання";
            dataGridViewDailyReportShops.Columns["confectioner"].HeaderText = "Зміна";
            dataGridViewDailyReportShops.Columns["status"].HeaderText = "Статус";
            dataGridViewDailyReportShops.Columns["sent_to_the_shop"].HeaderText = "Магазин";
            dataGridViewDailyReportShops.Columns["date_sent"].HeaderText = "Дата відправлення";
        }
     
        private void BindGridCakes()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `id`, `name_of_cake`, `price_for_the_kg` , `quantity`, `date`, `confectioner` FROM `daily_report_cakes`", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridViewProduction.DataSource = table;

            dataGridViewProduction.Columns["id"].HeaderText = "Код";
            dataGridViewProduction.Columns["name_of_cake"].HeaderText = "Найменування продукції";
            dataGridViewProduction.Columns["price_for_the_kg"].HeaderText = "Ціна за кг";
            dataGridViewProduction.Columns["quantity"].HeaderText = "Кількість";
            dataGridViewProduction.Columns["date"].HeaderText = "Дата";
            dataGridViewProduction.Columns["confectioner"].HeaderText = "Зміна";
        }

        private void btnAddBakedCakes_Click(object sender, EventArgs e)
        {
            countSalaryForADay();

            string status_of_cake = "Залишок готової продукції";
            string query = "INSERT INTO `daily_report_cakes` (`id`, `name_of_cake`, `price_for_the_kg` , `quantity`, " +
                "`date`, `confectioner`,`status`, `earned_for_a_day`) VALUES (NULL,'" + comboBoxCakes.Text + "', '" 
                + textBoxPriceForTheKg.Text + "' , '" + textBoxQuantity.Text + "', '" + this.dateTimePickerCakes.Text + "', " +
                "'" + textBoxUserCakes.Text + "', '" + status_of_cake + "', ROUND('" + labelEarned.Text + "',3));";
            connection.Open();
            command = new MySqlCommand(query, connection);

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успішно додано!");
                BindGridCakes();
                BindGridShops();
                textBoxQuantity.Clear();
      
            }
            else
            {
                MessageBox.Show("Помилка!");
            }

            connection.Close();
        }

        private void DailyReport_Load(object sender, EventArgs e)
        {
             try
              {
                    connection.Open();
                    MySqlCommand sc = new MySqlCommand("SELECT * FROM `cakes`",connection);
                    MySqlDataReader reader;
                    reader = sc.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("name_of_cake", typeof(string));
                    dt.Load(reader);
                    comboBoxCakes.ValueMember = "name_of_cake";
                    comboBoxCakes.DataSource = dt;
                    connection.Close();
              }
              catch(Exception)
              {

              }

                try
                {
                    connection.Open();
                    MySqlCommand sc = new MySqlCommand("SELECT * FROM `raw`", connection);
                    MySqlDataReader reader;
                    reader = sc.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("name_of_raw", typeof(string));
                    dt.Load(reader);
                    comboBoxRaw.ValueMember = "name_of_raw";
                    comboBoxRaw.DataSource = dt;
                    connection.Close();
                }
                catch (Exception)
                {

                }

            try
            {
                connection.Open();
                MySqlCommand sc = new MySqlCommand("SELECT * FROM `shops`", connection);
                MySqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("name_of_shop", typeof(string));
                dt.Load(reader);
                comboBoxNameOfShop.ValueMember = "name_of_shop";
                comboBoxNameOfShop.DataSource = dt;
                connection.Close();
            }
            catch (Exception)
            {

            }

        }

        private void btnDeleteDailyReportCakes_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM `daily_report_cakes` WHERE `daily_report_cakes`.`id` = '" + textBoxCodeOfCakes.Text + "'";
            connection.Open();
            command = new MySqlCommand(query, connection);

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успішно видалено!");
                BindGridCakes();
                textBoxCodeOfCakes.Clear();
            }
            else
            {
                MessageBox.Show("Помилка!");
            }
            connection.Close();
        } 

        private void addUsedRaw_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO `daily_report_raw` (`id`, `name_of_raw`, `used_raw` , `date`, `employee`) VALUES (NULL,'" + comboBoxRaw.Text 
                + "', '" + textBoxUsedRawDay.Text.Replace(",",".") + "' , '" + this.dateTimePickerRaw.Text + "', '" + textBoxRawEmployee.Text + "');";
            connection.Open();
            command = new MySqlCommand(query, connection);

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успішно додано!");
                BindGridRaw();
                textBoxUsedRawDay.Clear();
            }
            else
            {
                MessageBox.Show("Помилка!");
            }

            connection.Close();
        }

        private void btnDeleteRaw_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM `daily_report_raw` WHERE `daily_report_raw`.`id` = '" + textBoxCodeOfRaw.Text + "'";
            connection.Open();
            command = new MySqlCommand(query, connection);

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успішно видалено!");
                BindGridRaw();
                textBoxCodeOfRaw.Clear();
            }
            else
            {
                MessageBox.Show("Помилка!");
            }
            connection.Close();
        }

        private void btnAddDailyReportShops_Click(object sender, EventArgs e)
        {

            string status_of_cake = "Відправлено";
            string query = "UPDATE daily_report_cakes SET status = '" + status_of_cake + "', sent_to_the_shop = '" + comboBoxNameOfShop.Text + "', date_sent = '" + this.dateTimePicker1.Text + "' WHERE daily_report_cakes.id = '" + textBoxDailyReportShops.Text + "';";
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

        private void btnDeleteDailyReportShops_Click(object sender, EventArgs e)
        {
            string status_of_cake = "Залишок готової продукції";
            string query = "UPDATE daily_report_cakes SET status = '" + status_of_cake + "', sent_to_the_shop = '', date_sent = NULL WHERE daily_report_cakes.id = '" + textBoxDailyReportShops.Text + "';";
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

        private void btnDeleteDailyReportShops_Click_1(object sender, EventArgs e)
        {
            string status_of_cake = "Залишок готової продукції";
            string query = "UPDATE daily_report_cakes SET status = '" + status_of_cake + "', " +
                "sent_to_the_shop = '', date_sent = NULL WHERE daily_report_cakes.id = '" + textBoxDailyReportShops.Text + "';";
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

        private void comboBoxCakes_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            try
            {
                connection.Open();
                string query = "SELECT `price_for_the_kg` FROM `cakes` WHERE  `name_of_cake` = '" + comboBoxCakes.SelectedItem.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    textBoxPriceForTheKg.Text = dr["price_for_the_kg"].ToString();
                }
                connection.Close();
            }
            catch (Exception) {
            }
            */
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM `cakes` WHERE  `name_of_cake` = '" + comboBoxCakes.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    textBoxPriceForTheKg.Text = dr[2].ToString();
                }
                connection.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("Problem...");
            }
            
           
        }
    
        private void countSalaryForADay()
        {
            double price_for_the_kg = double.Parse(textBoxPriceForTheKg.Text.ToString());
            double baked_quantity = double.Parse(textBoxQuantity.Text.ToString());

            double earned_for_a_day = baked_quantity * price_for_the_kg;
            labelEarned.Text = (earned_for_a_day.ToString().Replace(",","."));
        }

        private void textBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && (e.KeyChar <= 39 || e.KeyChar >= 46) && number != 47 && number != 61)
            {
                e.Handled = true;
            }
        }
    }
}
