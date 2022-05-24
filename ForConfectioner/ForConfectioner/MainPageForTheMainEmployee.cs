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
    public partial class MainPageForTheMainEmployee : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=confectioners_workplace;Convert Zero Datetime=True");

        public MainPageForTheMainEmployee(string role)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            label1.Text = role;

            textBoxStatusCake.Text = "Залишок готової продукції";

            BindGridBakedCakes();
            BindGridSentToShops();
            BindGridUsedRaw();
            this.dataGridViewSentToShops.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dataGridViewSentToShops.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
            this.dataGridViewBakedCakes.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dataGridViewBakedCakes.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
            this.dataGridViewUsedRaw.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);
            dataGridViewUsedRaw.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Regular);
        }

        private void BindGridUsedRaw()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `daily_report_raw`", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridViewUsedRaw.DataSource = table;

            dataGridViewUsedRaw.Columns["id"].HeaderText = "Код";
            dataGridViewUsedRaw.Columns["name_of_raw"].HeaderText = "Найменування сировини";
            dataGridViewUsedRaw.Columns["used_raw"].HeaderText = "Використана сировина за день (кг)";
            dataGridViewUsedRaw.Columns["date"].HeaderText = "Дата";
            dataGridViewUsedRaw.Columns["employee"].HeaderText = "Зміна";
        }
        private void BindGridSearchProductionBySatusCake()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `id`, `name_of_cake`, `quantity`, `date`, `confectioner`, `status` FROM `daily_report_cakes` WHERE `status`='" + this.textBoxStatusCake.Text + "'", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridViewBakedCakes.DataSource = table;

            dataGridViewBakedCakes.Columns["id"].HeaderText = "Код продукції";
            dataGridViewBakedCakes.Columns["name_of_cake"].HeaderText = "Найменування продукції";
            dataGridViewBakedCakes.Columns["quantity"].HeaderText = "Кількість";
            dataGridViewBakedCakes.Columns["date"].HeaderText = "Дата випікання";
            dataGridViewBakedCakes.Columns["confectioner"].HeaderText = "Зміна";
            dataGridViewBakedCakes.Columns["status"].HeaderText = "Статус";
        }

        private void BindGridSearchProductionByDate()
        {
            string status_of_the_cake = "Відправлено";

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `id` , `name_of_cake` , `quantity` , `date` , " +
                "`confectioner` , `status` , `sent_to_the_shop`, `date_sent`" +
                " FROM `daily_report_cakes` WHERE `date`='" + this.dateTimePickerSentShops.Text + "' " +
                "AND `status`='" + status_of_the_cake + "'", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridViewSentToShops.DataSource = table;

            dataGridViewSentToShops.Columns["id"].HeaderText = "Код продукції";
            dataGridViewSentToShops.Columns["name_of_cake"].HeaderText = "Найменування продукції";
            dataGridViewSentToShops.Columns["quantity"].HeaderText = "Кількість";
            dataGridViewSentToShops.Columns["date"].HeaderText = "Дата випікання";
            dataGridViewSentToShops.Columns["confectioner"].HeaderText = "Зміна";
            dataGridViewSentToShops.Columns["status"].HeaderText = "Статус";
            dataGridViewSentToShops.Columns["sent_to_the_shop"].HeaderText = "Магазин";
            dataGridViewSentToShops.Columns["date_sent"].HeaderText = "Дата відправлення";
        }

        private void BindGridSearchProductionByConfectioner()
        {
            string status_of_the_cake = "Відправлено";
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `id` , `name_of_cake` , `quantity` , `date` , " +
                "`confectioner` , `status` , `sent_to_the_shop`, `date_sent` FROM `daily_report_cakes` WHERE " +
                "`confectioner`='" + this.comboBoxDailyReportShops.Text + "' AND `status`='" + status_of_the_cake + "'", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridViewSentToShops.DataSource = table;

            dataGridViewSentToShops.Columns["id"].HeaderText = "Код продукції";
            dataGridViewSentToShops.Columns["name_of_cake"].HeaderText = "Найменування продукції";
            dataGridViewSentToShops.Columns["quantity"].HeaderText = "Кількість";
            dataGridViewSentToShops.Columns["date"].HeaderText = "Дата випікання";
            dataGridViewSentToShops.Columns["confectioner"].HeaderText = "Зміна";
            dataGridViewSentToShops.Columns["status"].HeaderText = "Статус";
            dataGridViewSentToShops.Columns["sent_to_the_shop"].HeaderText = "Магазин";
            dataGridViewSentToShops.Columns["date_sent"].HeaderText = "Дата відправлення";
        }
        private void BindGridSearchCakesByConfectioner()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `id`, `name_of_cake`, `quantity`, `date`, `confectioner`, `status` FROM `daily_report_cakes` WHERE `confectioner`='" + this.comboBoxUsersCakes.Text + "'", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridViewBakedCakes.DataSource = table;

            dataGridViewBakedCakes.Columns["id"].HeaderText = "Код продукції";
            dataGridViewBakedCakes.Columns["name_of_cake"].HeaderText = "Найменування продукції";
            dataGridViewBakedCakes.Columns["quantity"].HeaderText = "Кількість";
            dataGridViewBakedCakes.Columns["date"].HeaderText = "Дата випікання";
            dataGridViewBakedCakes.Columns["confectioner"].HeaderText = "Зміна";
            dataGridViewBakedCakes.Columns["status"].HeaderText = "Статус";
        }

        private void BindGridSentToShops()
        {
            string status_of_cake = "Відправлено";
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `id` , `name_of_cake` , `quantity` , `date` , " +
                "`confectioner` , `status` , `sent_to_the_shop`, `date_sent` " +
                "FROM `daily_report_cakes` WHERE `status`='" + status_of_cake + "'", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridViewSentToShops.DataSource = table;

            dataGridViewSentToShops.Columns["id"].HeaderText = "Код продукції";
            dataGridViewSentToShops.Columns["name_of_cake"].HeaderText = "Найменування продукції";
            dataGridViewSentToShops.Columns["quantity"].HeaderText = "Кількість";
            dataGridViewSentToShops.Columns["date"].HeaderText = "Дата випікання";
            dataGridViewSentToShops.Columns["confectioner"].HeaderText = "Зміна";
            dataGridViewSentToShops.Columns["status"].HeaderText = "Статус";
            dataGridViewSentToShops.Columns["sent_to_the_shop"].HeaderText = "Магазин";
            dataGridViewSentToShops.Columns["date_sent"].HeaderText = "Дата відправлення";
        }

        private void BindGridBakedCakes()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `id`, `name_of_cake`, `quantity`, `date`, `confectioner`, `status` FROM `daily_report_cakes` ", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridViewBakedCakes.DataSource = table;

            dataGridViewBakedCakes.Columns["id"].HeaderText = "Код продукції";
            dataGridViewBakedCakes.Columns["name_of_cake"].HeaderText = "Найменування продукції";
            dataGridViewBakedCakes.Columns["quantity"].HeaderText = "Кількість";
            dataGridViewBakedCakes.Columns["date"].HeaderText = "Дата випікання";
            dataGridViewBakedCakes.Columns["confectioner"].HeaderText = "Зміна";
            dataGridViewBakedCakes.Columns["status"].HeaderText = "Статус";
        }

        private void BindGridSearchCakesByDate()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `id`, `name_of_cake`, `quantity`, `date`, `confectioner`, `status` FROM `daily_report_cakes` WHERE `date`='" + this.dateTimePickerSearchCakes.Text + "'", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridViewBakedCakes.DataSource = table;

            dataGridViewBakedCakes.Columns["id"].HeaderText = "Код продукції";
            dataGridViewBakedCakes.Columns["name_of_cake"].HeaderText = "Найменування продукції";
            dataGridViewBakedCakes.Columns["quantity"].HeaderText = "Кількість";
            dataGridViewBakedCakes.Columns["date"].HeaderText = "Дата випікання";
            dataGridViewBakedCakes.Columns["confectioner"].HeaderText = "Зміна";
            dataGridViewBakedCakes.Columns["status"].HeaderText = "Статус";
        }
        private void editData_Click(object sender, EventArgs e)
        {
            EditData editData = new EditData(label1.Text);
            this.Hide();
            editData.Show();
        }

        private void addDailyReport_Click(object sender, EventArgs e)
        {
            DailyReport dailyReport = new DailyReport(label1.Text);
            this.Hide();
            dailyReport.Show();
        }

        private void closeProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Знаходимо випечену продукцію за кондитером
        private void btnSearchCakesByConfectioner_Click(object sender, EventArgs e)
        {
            BindGridSearchCakesByConfectioner();
        }

        //Знаходимо випечену продукцію за датою виготовлення
        private void btnSearchCakesByDate_Click(object sender, EventArgs e)
        {
            BindGridSearchCakesByDate();
        }

        //Очищуємо знайдені дані - повертаємось до попереднього вигляду таблиці
        private void btnClearSearchCakes_Click(object sender, EventArgs e)
        {
            BindGridBakedCakes();
        }

        private void MainPageForTheMainEmployee_Load(object sender, EventArgs e)
        {
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

            try
            {
                connection.Open();
                MySqlCommand sc = new MySqlCommand("SELECT * FROM `users`", connection);
                MySqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("UserName", typeof(string));
                dt.Load(reader);
                comboBoxDailyReportShops.ValueMember = "UserName";
                comboBoxDailyReportShops.DataSource = dt;
                connection.Close();
            }
            catch (Exception)
            {

            }


            try
            {
                connection.Open();
                MySqlCommand sc = new MySqlCommand("SELECT * FROM `users`", connection);
                MySqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("UserName", typeof(string));
                dt.Load(reader);
                comboBoxNameUserRaw.ValueMember = "UserName";
                comboBoxNameUserRaw.DataSource = dt;
                connection.Close();
            }
            catch (Exception)
            {

            }
        }

        private void btnSearchSentProductionByDate_Click(object sender, EventArgs e)
        {
            BindGridSearchProductionByDate();
        }
       
        private void btnSearchSentProductionByConfectioner_Click(object sender, EventArgs e)
        {
            BindGridSearchProductionByConfectioner();
        }

        private void btnClearSearchShops_Click(object sender, EventArgs e)
        {
            BindGridSentToShops();
        }

        private void btnClearSearchCakes2_Click(object sender, EventArgs e)
        {
            BindGridSentToShops();
        }

        private void btnClearSearchCakesByDate_Click(object sender, EventArgs e)
        {
            BindGridBakedCakes();
        }

        private void btnClearSearchBakedCakesByStatus_Click(object sender, EventArgs e)
        {
            BindGridBakedCakes();
        }

        private void btnSearchBakedCakesByStatus_Click(object sender, EventArgs e)
        {
            BindGridSearchProductionBySatusCake();
        }

        private void btnSearchUsedRawByConfectioner_Click(object sender, EventArgs e)
        {
            BindgridSearchUsedRawByConfectioner();
        }

        private void BindgridSearchUsedRawByConfectioner()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `daily_report_raw` WHERE `employee`='" + this.comboBoxNameUserRaw.Text + "'", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridViewUsedRaw.DataSource = table;

            dataGridViewUsedRaw.Columns["id"].HeaderText = "Код";
            dataGridViewUsedRaw.Columns["name_of_raw"].HeaderText = "Найменування сировини";
            dataGridViewUsedRaw.Columns["used_raw"].HeaderText = "Використана сировина за день (кг)";
            dataGridViewUsedRaw.Columns["date"].HeaderText = "Дата";
            dataGridViewUsedRaw.Columns["employee"].HeaderText = "Зміна";
        }

        private void BindGridUsedRawByDate()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `daily_report_raw` WHERE `date`='" + this.dateTimePickerUsedRawDate.Text + "'", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridViewUsedRaw.DataSource = table;

            dataGridViewUsedRaw.Columns["id"].HeaderText = "Код";
            dataGridViewUsedRaw.Columns["name_of_raw"].HeaderText = "Найменування сировини";
            dataGridViewUsedRaw.Columns["used_raw"].HeaderText = "Використана сировина за день (кг)";
            dataGridViewUsedRaw.Columns["date"].HeaderText = "Дата";
            dataGridViewUsedRaw.Columns["employee"].HeaderText = "Зміна";
        }

        private void btnClearSearchUsedRawBtConfectioner_Click(object sender, EventArgs e)
        {
            BindGridUsedRaw();
        }

        private void btnClearSearchUsedRawBtDate_Click(object sender, EventArgs e)
        {
            BindGridUsedRaw();
        }

        private void btnSearchUsedRawByDate_Click(object sender, EventArgs e)
        {
            BindGridUsedRawByDate();
        }

        private void btnOpenToCountRemainder_Click(object sender, EventArgs e)
        {
            Remainder remainder = new Remainder(label1.Text);
            this.Hide();
            remainder.Show();
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            Salary salary = new Salary(label1.Text);
            this.Hide();
            salary.Show();
        }
    }
}
