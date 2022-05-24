
namespace ForConfectioner
{
    partial class Remainder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Remainder));
            this.dataGridViewRemainderOfRaw = new System.Windows.Forms.DataGridView();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxRaw = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerFirstDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerLastDay = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxQuantityForMonth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sumOfRaw = new System.Windows.Forms.Label();
            this.btnFindRemainder = new System.Windows.Forms.Button();
            this.btnBackToMainPage = new System.Windows.Forms.Button();
            this.remainderL = new System.Windows.Forms.Label();
            this.btnDeleteRemainderOfRaw = new System.Windows.Forms.Button();
            this.btnChangeRemainderOfRaw = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelusername = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRemainderOfRaw)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewRemainderOfRaw
            // 
            this.dataGridViewRemainderOfRaw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRemainderOfRaw.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewRemainderOfRaw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRemainderOfRaw.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewRemainderOfRaw.Location = new System.Drawing.Point(0, 281);
            this.dataGridViewRemainderOfRaw.Name = "dataGridViewRemainderOfRaw";
            this.dataGridViewRemainderOfRaw.RowHeadersWidth = 51;
            this.dataGridViewRemainderOfRaw.RowTemplate.Height = 24;
            this.dataGridViewRemainderOfRaw.Size = new System.Drawing.Size(1923, 708);
            this.dataGridViewRemainderOfRaw.TabIndex = 0;
            // 
            // textBoxCode
            // 
            this.textBoxCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCode.Location = new System.Drawing.Point(17, 100);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(100, 28);
            this.textBoxCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Код";
            // 
            // comboBoxRaw
            // 
            this.comboBoxRaw.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxRaw.FormattingEnabled = true;
            this.comboBoxRaw.Location = new System.Drawing.Point(160, 100);
            this.comboBoxRaw.Name = "comboBoxRaw";
            this.comboBoxRaw.Size = new System.Drawing.Size(254, 30);
            this.comboBoxRaw.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(155, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Найменування сировини";
            // 
            // dateTimePickerFirstDate
            // 
            this.dateTimePickerFirstDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerFirstDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerFirstDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFirstDate.Location = new System.Drawing.Point(708, 100);
            this.dateTimePickerFirstDate.Name = "dateTimePickerFirstDate";
            this.dateTimePickerFirstDate.Size = new System.Drawing.Size(280, 28);
            this.dateTimePickerFirstDate.TabIndex = 5;
            // 
            // dateTimePickerLastDay
            // 
            this.dateTimePickerLastDay.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerLastDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerLastDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerLastDay.Location = new System.Drawing.Point(1036, 98);
            this.dateTimePickerLastDay.Name = "dateTimePickerLastDay";
            this.dateTimePickerLastDay.Size = new System.Drawing.Size(280, 28);
            this.dateTimePickerLastDay.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(703, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Дата отримання сировини";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(1031, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Кінцева дата";
            // 
            // textBoxQuantityForMonth
            // 
            this.textBoxQuantityForMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxQuantityForMonth.Location = new System.Drawing.Point(458, 100);
            this.textBoxQuantityForMonth.Name = "textBoxQuantityForMonth";
            this.textBoxQuantityForMonth.Size = new System.Drawing.Size(207, 28);
            this.textBoxQuantityForMonth.TabIndex = 9;
            this.textBoxQuantityForMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxQuantityForMonth_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(453, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Дано на місяць (кг)";
            // 
            // sumOfRaw
            // 
            this.sumOfRaw.AutoSize = true;
            this.sumOfRaw.ForeColor = System.Drawing.Color.White;
            this.sumOfRaw.Location = new System.Drawing.Point(219, 146);
            this.sumOfRaw.Name = "sumOfRaw";
            this.sumOfRaw.Size = new System.Drawing.Size(76, 17);
            this.sumOfRaw.TabIndex = 11;
            this.sumOfRaw.Text = "sumOfRaw";
            // 
            // btnFindRemainder
            // 
            this.btnFindRemainder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(151)))), ((int)(((byte)(174)))));
            this.btnFindRemainder.FlatAppearance.BorderSize = 0;
            this.btnFindRemainder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindRemainder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFindRemainder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFindRemainder.Location = new System.Drawing.Point(1198, 181);
            this.btnFindRemainder.Name = "btnFindRemainder";
            this.btnFindRemainder.Size = new System.Drawing.Size(242, 48);
            this.btnFindRemainder.TabIndex = 12;
            this.btnFindRemainder.Text = "Обчислити залишок";
            this.btnFindRemainder.UseVisualStyleBackColor = false;
            this.btnFindRemainder.Click += new System.EventHandler(this.btnFindRemainder_Click);
            // 
            // btnBackToMainPage
            // 
            this.btnBackToMainPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(151)))), ((int)(((byte)(174)))));
            this.btnBackToMainPage.FlatAppearance.BorderSize = 0;
            this.btnBackToMainPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToMainPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBackToMainPage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBackToMainPage.Location = new System.Drawing.Point(3, 12);
            this.btnBackToMainPage.Name = "btnBackToMainPage";
            this.btnBackToMainPage.Size = new System.Drawing.Size(144, 35);
            this.btnBackToMainPage.TabIndex = 13;
            this.btnBackToMainPage.Text = "На головну";
            this.btnBackToMainPage.UseVisualStyleBackColor = false;
            this.btnBackToMainPage.Click += new System.EventHandler(this.btnBackToMainPage_Click);
            // 
            // remainderL
            // 
            this.remainderL.AutoSize = true;
            this.remainderL.ForeColor = System.Drawing.Color.White;
            this.remainderL.Location = new System.Drawing.Point(314, 146);
            this.remainderL.Name = "remainderL";
            this.remainderL.Size = new System.Drawing.Size(72, 17);
            this.remainderL.TabIndex = 14;
            this.remainderL.Text = "remainder";
            // 
            // btnDeleteRemainderOfRaw
            // 
            this.btnDeleteRemainderOfRaw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(151)))), ((int)(((byte)(174)))));
            this.btnDeleteRemainderOfRaw.FlatAppearance.BorderSize = 0;
            this.btnDeleteRemainderOfRaw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRemainderOfRaw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteRemainderOfRaw.ForeColor = System.Drawing.Color.Snow;
            this.btnDeleteRemainderOfRaw.Location = new System.Drawing.Point(1702, 181);
            this.btnDeleteRemainderOfRaw.Name = "btnDeleteRemainderOfRaw";
            this.btnDeleteRemainderOfRaw.Size = new System.Drawing.Size(209, 48);
            this.btnDeleteRemainderOfRaw.TabIndex = 15;
            this.btnDeleteRemainderOfRaw.Text = "Видалити запис";
            this.btnDeleteRemainderOfRaw.UseVisualStyleBackColor = false;
            this.btnDeleteRemainderOfRaw.Click += new System.EventHandler(this.btnDeleteRemainderOfRaw_Click);
            // 
            // btnChangeRemainderOfRaw
            // 
            this.btnChangeRemainderOfRaw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(151)))), ((int)(((byte)(174)))));
            this.btnChangeRemainderOfRaw.FlatAppearance.BorderSize = 0;
            this.btnChangeRemainderOfRaw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeRemainderOfRaw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChangeRemainderOfRaw.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnChangeRemainderOfRaw.Location = new System.Drawing.Point(1470, 181);
            this.btnChangeRemainderOfRaw.Name = "btnChangeRemainderOfRaw";
            this.btnChangeRemainderOfRaw.Size = new System.Drawing.Size(209, 48);
            this.btnChangeRemainderOfRaw.TabIndex = 16;
            this.btnChangeRemainderOfRaw.Text = "Змінити запис";
            this.btnChangeRemainderOfRaw.UseVisualStyleBackColor = false;
            this.btnChangeRemainderOfRaw.Click += new System.EventHandler(this.btnChangeRemainderOfRaw_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(151)))), ((int)(((byte)(174)))));
            this.panel1.Controls.Add(this.btnBackToMainPage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1923, 54);
            this.panel1.TabIndex = 17;
            // 
            // labelusername
            // 
            this.labelusername.AutoSize = true;
            this.labelusername.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelusername.Location = new System.Drawing.Point(1394, 77);
            this.labelusername.Name = "labelusername";
            this.labelusername.Size = new System.Drawing.Size(73, 17);
            this.labelusername.TabIndex = 18;
            this.labelusername.Text = "userName";
            // 
            // Remainder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1923, 989);
            this.Controls.Add(this.labelusername);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnChangeRemainderOfRaw);
            this.Controls.Add(this.btnDeleteRemainderOfRaw);
            this.Controls.Add(this.remainderL);
            this.Controls.Add(this.btnFindRemainder);
            this.Controls.Add(this.sumOfRaw);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxQuantityForMonth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePickerLastDay);
            this.Controls.Add(this.dateTimePickerFirstDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxRaw);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCode);
            this.Controls.Add(this.dataGridViewRemainderOfRaw);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Remainder";
            this.Load += new System.EventHandler(this.Remainder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRemainderOfRaw)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRemainderOfRaw;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRaw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerFirstDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerLastDay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxQuantityForMonth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label sumOfRaw;
        private System.Windows.Forms.Button btnFindRemainder;
        private System.Windows.Forms.Button btnBackToMainPage;
        private System.Windows.Forms.Label remainderL;
        private System.Windows.Forms.Button btnDeleteRemainderOfRaw;
        private System.Windows.Forms.Button btnChangeRemainderOfRaw;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelusername;
    }
}