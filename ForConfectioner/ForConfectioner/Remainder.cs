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
    public partial class Remainder : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;" +
            "database=confectioners_workplace;Convert Zero Datetime=True");
        MySqlCommand command;
        
        public Remainder(string username)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            labelusername.Text = username; 

            BindGridRemainderOfRaw();
            this.dataGridViewRemainderOfRaw.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dataGridViewRemainderOfRaw.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
        }

       //Виводимо дані про залишок сировини в таблицю
        private void BindGridRemainderOfRaw()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `remainder_of_raw`", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridViewRemainderOfRaw.DataSource = table;

            dataGridViewRemainderOfRaw.Columns["id"].HeaderText = "Код";
            dataGridViewRemainderOfRaw.Columns["name_of_raw"].HeaderText = "Найменування сировини";
            dataGridViewRemainderOfRaw.Columns["quantity_for_a_month"].HeaderText = "Сировина на місяць (кг)";
            dataGridViewRemainderOfRaw.Columns["first_day_of_the_moth"].HeaderText = "Дата отримання сировини";
            dataGridViewRemainderOfRaw.Columns["last_day_of_the_month"].HeaderText = "Останній день місяця";
            dataGridViewRemainderOfRaw.Columns["general_used_raw"].HeaderText = "Використано за місяць (кг)";
            dataGridViewRemainderOfRaw.Columns["remainder"].HeaderText = "Залишок";
            dataGridViewRemainderOfRaw.Columns["date_of_calculation"].HeaderText = "Дата обчислення залишку";

        }

        private void FindRemainderOfRaw()
        {
           double quantityForMonth = double.Parse(textBoxQuantityForMonth.Text.ToString());
            double remainder;
        //   double sumOfUsedRaw = double.Parse(sumOfRaw.Text.ToString());
           if(sumOfRaw.Text != String.Empty)
            {
                remainder = quantityForMonth - double.Parse(sumOfRaw.Text.ToString());
            }
            else
            {
                double sumOfUsedRaw = 0;
                remainder = quantityForMonth - sumOfUsedRaw;
            }

           remainderL.Text = (remainder.ToString());
        }
        private void btnFindRemainder_Click(object sender, EventArgs e)
        {
            findSumOfUsedRaw();
            FindRemainderOfRaw();
            
            string query = "INSERT INTO remainder_of_raw (id, name_of_raw, quantity_for_a_month, first_day_of_the_moth, " +
                "last_day_of_the_month, general_used_raw, remainder, date_of_calculation) VALUES (NULL, '" + this.comboBoxRaw.Text + "', " +
                "'" + textBoxQuantityForMonth.Text + "', '" + dateTimePickerFirstDate.Text + "', '" + dateTimePickerLastDay.Text + "', " +
                "'" + sumOfRaw.Text + "', '" + remainderL.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
            connection.Open();
            command = new MySqlCommand(query, connection);

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успішно додано!");
                BindGridRemainderOfRaw();
            }
            else
            {
                MessageBox.Show("Помилка!");
            }

            connection.Close();


        }

        private void findSumOfUsedRaw()
        {
                try
                {
                    connection.Open();
                    MySqlCommand sc = new MySqlCommand("SELECT SUM(used_raw) FROM daily_report_raw WHERE name_of_raw='" + comboBoxRaw.Text + "' " +
                        "AND date BETWEEN CAST('" + this.dateTimePickerFirstDate.Text + "' AS DATE) AND CAST('" + this.dateTimePickerLastDay.Text + "' AS DATE)", connection);
                    MySqlDataReader reader;
                    reader = sc.ExecuteReader();
                  while (reader.Read())
                    {
                      sumOfRaw.Text = reader.GetValue(0).ToString();
                    }
                    connection.Close();
                }
                catch (Exception)
                {

                }
        }

        private void Remainder_Load(object sender, EventArgs e)
        {
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
        }

        private void btnBackToMainPage_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPageForTheMainEmployee backToMainPage = new MainPageForTheMainEmployee(labelusername.Text);
            backToMainPage.Show();
        }

        private void textBoxQuantityForMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
      
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && (e.KeyChar <= 39 || e.KeyChar >= 46) && number != 47 && number != 61)
            {
                e.Handled = true;
            }
          
        }

        private void btnDeleteRemainderOfRaw_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM `remainder_of_raw` WHERE `remainder_of_raw`.`id` = '" + textBoxCode.Text + "'";
            connection.Open();
            command = new MySqlCommand(query, connection);

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успішно видалено!");
                BindGridRemainderOfRaw();
                textBoxCode.Clear();
            }
            else
            {
                MessageBox.Show("Помилка!");
            }
            connection.Close();
        }

        private void btnChangeRemainderOfRaw_Click(object sender, EventArgs e)
        {
            findSumOfUsedRaw();
            FindRemainderOfRaw();

            string query = "UPDATE remainder_of_raw SET name_of_raw = '" + this.comboBoxRaw.Text + "', quantity_for_a_month = '" + textBoxQuantityForMonth.Text + "', " +
                "first_day_of_the_moth = '" + this.dateTimePickerFirstDate.Text + "', last_day_of_the_month = '" + this.dateTimePickerLastDay.Text + "', " +
                "date_of_calculation = '" + DateTime.Now.ToString("yyyy-MM-dd") + "', `general_used_raw` = '" + sumOfRaw.Text + "', `remainder` = '" + remainderL.Text + "'  WHERE remainder_of_raw.id = '" + textBoxCode.Text + "'";
            connection.Open();
            command = new MySqlCommand(query, connection);

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Успішно змінено!");
                BindGridRemainderOfRaw();
            }
            else
            {
                MessageBox.Show("Помилка!");
            }

            connection.Close();
        }
    }
}
