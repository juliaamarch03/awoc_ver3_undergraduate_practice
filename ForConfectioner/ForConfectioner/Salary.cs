using MySql.Data.MySqlClient;
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
    public partial class Salary : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;" +
            "username=root;password=;database=confectioners_workplace;");
        MySqlCommand command;
        public Salary(string username)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            BindGridCakes();
            BindGridEarnedForADay();

            label1.Text = username;

            this.dataGridViewCakes.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dataGridViewCakes.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Regular);
            this.dataGridViewEarnedForADay.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dataGridViewEarnedForADay.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Regular);
        }

        private void countSalaryForADay()
        {
            try
            {
                connection.Open();
                MySqlCommand sc = new MySqlCommand("SELECT ROUND(SUM(earned_for_a_day),3) FROM daily_report_cakes " +
                    "WHERE `date` = CURDATE() AND `confectioner`='" + label1.Text + "'", connection);
                MySqlDataReader reader;
                reader = sc.ExecuteReader();
                while (reader.Read())
                {
                    textBoxEarnedForADay.Text = reader.GetValue(0).ToString().Replace(",",".");
                }
                connection.Close();
            }
            catch (Exception)
            {

            }
        }

        private void countSalaryForAMonth()
        {
            try
            {
                connection.Open();
                MySqlCommand sc = new MySqlCommand("SELECT ROUND(SUM(earned_for_a_day),3) FROM daily_report_cakes " +
                    "WHERE MONTH(date)=MONTH(CURDATE()) AND `confectioner`='" + label1.Text + "'", connection);
                MySqlDataReader reader;
                reader = sc.ExecuteReader();
                while (reader.Read())
                {
                    textBoxEarnedForAMonth.Text = reader.GetValue(0).ToString().Replace(",", ".");
                }
                connection.Close();
            }
            catch (Exception)
            {

            }
        }
        
        private void btnBackToTheMainPage_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPageForTheMainEmployee backToMainPage = new MainPageForTheMainEmployee(label1.Text);
            backToMainPage.Show();
        }

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

        private void BindGridEarnedForADay()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `id` , `name_of_cake` , `price_for_the_kg` , `quantity`" +
                ", `date`, `confectioner`, `earned_for_a_day` FROM `daily_report_cakes`", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridViewEarnedForADay.DataSource = table;

            dataGridViewEarnedForADay.Columns["id"].HeaderText = "Код";
            dataGridViewEarnedForADay.Columns["name_of_cake"].HeaderText = "Продукція";
            dataGridViewEarnedForADay.Columns["price_for_the_kg"].HeaderText = "Ціна за кг";
            dataGridViewEarnedForADay.Columns["quantity"].HeaderText = "К-сть (кг)";
            dataGridViewEarnedForADay.Columns["date"].HeaderText = "Дата випікання";
            dataGridViewEarnedForADay.Columns["confectioner"].HeaderText = "К-сть (кг)";
            dataGridViewEarnedForADay.Columns["earned_for_a_day"].HeaderText = "Зароблено за день";
        }

        private void btnChangeCake_Click(object sender, EventArgs e)
        {
            string query = "UPDATE `cakes` SET `price_for_the_kg` = '" + textBoxPriceForTheKg.Text + "' " +
                "WHERE `cakes`.`code` = '" + code.Text + "';";
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

        private void btnDeleteCake_Click(object sender, EventArgs e)
        {
            string query = "UPDATE `cakes` SET `price_for_the_kg` = '" + 0 + "' WHERE `cakes`.`code` = '" + code.Text + "';";
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

        private void Salary_Load(object sender, EventArgs e)
        {
            countSalaryForADay();
            countSalaryForAMonth();

            try
            {
                connection.Open();
                MySqlCommand sc = new MySqlCommand("SELECT * FROM `users`", connection);
                MySqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("UserName", typeof(string));
                dt.Load(reader);
                comboBoxUsersCakes.ValueMember = "UserName";
                comboBoxUsersCakes.DataSource = dt;
                connection.Close();
            }
            catch (Exception)
            {

            }
        }

        private void btnClearSearching_Click(object sender, EventArgs e)
        {
            BindGridEarnedForADay();
            textBoxEarnedForSpecificDay.Clear();
            textBoxEarnedForSpecificMonth.Clear();
        }

        private void btnSearchEarnedSalary_Click(object sender, EventArgs e)
        {
            countSalaryForSpecificDay();
            countSalaryForSpecificMonth();
            searchEarnedSalaryByDate();
        }

        private void countSalaryForSpecificDay()
        {
            try
            {
                connection.Open();
                MySqlCommand sc = new MySqlCommand("SELECT ROUND(SUM(earned_for_a_day),3) FROM daily_report_cakes " +
                    "WHERE `date` = '" + this.dateTimePickerSearchCakes.Text + "' AND `confectioner`='" + comboBoxUsersCakes.Text + "'", connection);
                MySqlDataReader reader;
                reader = sc.ExecuteReader();
                while (reader.Read())
                {
                    textBoxEarnedForSpecificDay.Text = reader.GetValue(0).ToString().Replace(",", ".");
                }
                connection.Close();
            }
            catch (Exception)
            {

            }
        }

        private void countSalaryForSpecificMonth()
        {
            try
            {
                connection.Open();
                MySqlCommand sc = new MySqlCommand("SELECT ROUND(SUM(earned_for_a_day),3) FROM daily_report_cakes " +
                    "WHERE MONTH(date)=MONTH('" + this.dateTimePickerSearchCakes.Text + "') AND `confectioner`='" + comboBoxUsersCakes.Text + "'", connection);
                MySqlDataReader reader;
                reader = sc.ExecuteReader();
                while (reader.Read())
                {
                    textBoxEarnedForSpecificMonth.Text = reader.GetValue(0).ToString().Replace(",", ".");
                }
                connection.Close();
            }
            catch (Exception)
            {

            }
        }
    
        private void searchEarnedSalaryByDate()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `id` , `name_of_cake` , `price_for_the_kg` , `quantity`" +
                ", `date`, `confectioner`, `earned_for_a_day` FROM `daily_report_cakes` WHERE `date`= '" + this.dateTimePickerSearchCakes.Text + "' AND `confectioner`= '" + comboBoxUsersCakes.Text + "' ", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridViewEarnedForADay.DataSource = table;

            dataGridViewEarnedForADay.Columns["id"].HeaderText = "Код";
            dataGridViewEarnedForADay.Columns["name_of_cake"].HeaderText = "Продукція";
            dataGridViewEarnedForADay.Columns["price_for_the_kg"].HeaderText = "Ціна за кг";
            dataGridViewEarnedForADay.Columns["quantity"].HeaderText = "К-сть (кг)";
            dataGridViewEarnedForADay.Columns["date"].HeaderText = "Дата випікання";
            dataGridViewEarnedForADay.Columns["confectioner"].HeaderText = "К-сть (кг)";
            dataGridViewEarnedForADay.Columns["earned_for_a_day"].HeaderText = "Зароблено за день";
        }
    }
}
