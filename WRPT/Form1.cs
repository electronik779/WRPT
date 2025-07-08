using System.Data;
using System.Globalization;
using System.Linq.Expressions;

namespace WRPT
{
    public partial class Form1 : Form
    {
        //Таблицы по которым строим tableGridView
        DataTable tableTributary = new DataTable();
        DataTable tableUpstream = new DataTable();
        DataTable tableDownstream = new DataTable();
        DataTable tableRemainder = new DataTable();
        DataTable tableSelections = new DataTable();
        DataTable tableResults = new DataTable();
        DataTable tableSecurity = new DataTable();
        DataTable tableDischarges = new DataTable();
        DataTable tableShortage = new DataTable();
        DataTable tableControlMonth = new DataTable();

        DataTable tableExtRemainder = new DataTable();

        public Form1()
        {
            InitializeComponent();

            openFileDialog1.Filter = "CSV файлы (*.csv)|*.csv";
            saveFileDialog1.Filter = "CSV файлы (*.csv)|*.csv";
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.AddExtension = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Оформление таблиц
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AllowUserToOrderColumns = false;

            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.ColumnHeadersVisible = false;
            dataGridView2.AllowUserToOrderColumns = false;

            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.ColumnHeadersVisible = false;
            dataGridView3.AllowUserToOrderColumns = false;

            dataGridView4.AllowUserToAddRows = false;
            dataGridView4.AllowUserToDeleteRows = false;
            dataGridView4.RowHeadersVisible = false;
            dataGridView4.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView4.AllowUserToOrderColumns = false;

            dataGridView5.AllowUserToAddRows = false;
            dataGridView5.AllowUserToDeleteRows = false;
            dataGridView5.RowHeadersVisible = false;
            dataGridView5.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView5.AllowUserToOrderColumns = false;

            dataGridView6.AllowUserToAddRows = false;
            dataGridView6.AllowUserToDeleteRows = false;
            dataGridView6.RowHeadersVisible = false;
            dataGridView6.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView6.AllowUserToOrderColumns = false;

            //Начальная инициализация
            tableTributary.Columns.Add(new DataColumn("0", typeof(string))); //Создаем столбец
            DataRow rowTributary = tableTributary.NewRow(); //Добавляем строку
            rowTributary[0] = 0; //Задаем данные (номер столбца - 0) 
            tableTributary.Rows.Add(rowTributary); //Добавляем данные в таблицу
            dataGridView1.DataSource = tableTributary; //Привязываем таблицу к tableGridView

            tableUpstream.Columns.Add(new DataColumn("0", typeof(string)));
            DataRow rowUpstream0 = tableUpstream.NewRow();
            DataRow rowUpstream1 = tableUpstream.NewRow();
            rowUpstream0[0] = 0;
            rowUpstream1[0] = 0;
            tableUpstream.Rows.Add(rowUpstream0);
            tableUpstream.Rows.Add(rowUpstream1);
            dataGridView2.DataSource = tableUpstream;

            tableDownstream.Columns.Add(new DataColumn("0", typeof(string)));
            DataRow rowDownstream0 = tableDownstream.NewRow();
            DataRow rowDownstream1 = tableDownstream.NewRow();
            rowDownstream0[0] = 0;
            rowDownstream1[0] = 0;
            tableDownstream.Rows.Add(rowDownstream0);
            tableDownstream.Rows.Add(rowDownstream1);
            dataGridView3.DataSource = tableDownstream;

            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            //textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0";
            textBox11.Text = "0";
            textBox12.Text = "0";
            textBox13.Text = "0";

            for (int i = 0; i < 12; i++)
            {
                if (i < 9)
                {
                    tableRemainder.Columns.Add(new DataColumn("0" + (i + 1).ToString(), typeof(string)));
                }
                else
                {
                    tableRemainder.Columns.Add(new DataColumn((i + 1).ToString(), typeof(string)));
                }
            }
            DataRow rowRemainder = tableRemainder.NewRow();
            for (int i = 0; i < 12; i++)
            {
                rowRemainder[i] = 0;
            }
            tableRemainder.Rows.Add(rowRemainder);
            dataGridView4.DataSource = tableRemainder;

            for (int i = 0; i < 12; i++)
            {
                if (i < 9)
                {
                    tableSelections.Columns.Add(new DataColumn("0" + (i + 1).ToString(), typeof(string)));
                }
                else
                {
                    tableSelections.Columns.Add(new DataColumn((i + 1).ToString(), typeof(string)));
                }
            }
            DataRow rowSelections = tableSelections.NewRow();
            for (int i = 0; i < 12; i++)
            {
                rowSelections[i] = 0;
            }
            tableSelections.Rows.Add(rowSelections);
            dataGridView5.DataSource = tableSelections;

            for (int i = 0; i < 12; i++)
            {
                if (i < 9)
                {
                    tableDischarges.Columns.Add(new DataColumn("0" + (i + 1).ToString(), typeof(string)));
                }
                else
                {
                    tableDischarges.Columns.Add(new DataColumn((i + 1).ToString(), typeof(string)));
                }
            }
            DataRow rowDischarges = tableDischarges.NewRow();
            for (int i = 0; i < 12; i++)
            {
                rowDischarges[i] = 0;
            }
            tableDischarges.Rows.Add(rowDischarges);
            dataGridView6.DataSource = tableDischarges;


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label20.Text = "Коэффициент потерь при Qгэс²";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label20.Text = "Потери напора, м";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox8.Text))
                return;

            int m;
            try
            { 
                m = GetInt(textBox1.Text, 0);
                if (m > 12) { LimitMsg("12"); m = 12; textBox1.Text = "12"; }//Месяцев в году 12
            }
            catch
            {
                textBox1.BackColor = Color.Red;
                MessageBox.Show("Необходимо ввести целое число.", "Внимание!",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }

            int n;
            try
            {
                n = GetInt(textBox8.Text, 0);
                if (n > 600) { LimitMsg("600"); n = 600; textBox8.Text = "600"; }//Кол-во эл-тов массива Q
            }
            catch
            {
                textBox8.BackColor = Color.Red;
                MessageBox.Show("Необходимо ввести целое число.", "Внимание!",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }

            while (n % 12 != 0) { n++; }
            textBox8.Text = n.ToString();
            int years = n / 12;

            button1.Enabled = false;

            //Очищаем таблицу
            tableTributary.Clear();
            for (int i = tableTributary.Columns.Count - 1; i >= 0; i--)
            {
                tableTributary.Columns.RemoveAt(i);
            }
            //Создаем таблицу по заданному количеству столбцов
            for (int i = 0; i < n; i++)
            {
                if (m > years * 12) { m = 1; }
                tableTributary.Columns.Add(new DataColumn(m.ToString(), typeof(string)));
                m++;
            }
            //Заполняем строку нулями
            DataRow rowTributary = tableTributary.NewRow();
            for (int i = 0; i < n; i++)
            {
                rowTributary[i] = 0;
            }
            tableTributary.Rows.Add(rowTributary);
            dataGridView1.DataSource = tableTributary;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox9.Text))
                return;

            button2.Enabled = false;

            int n;
            try
            { 
                n = GetInt(textBox9.Text, 0);
                if (n > 20) { LimitMsg("20"); n = 20; textBox9.Text = "20"; }//Кол-во эл-тов массивов VV и ZUU
            }
            catch
            {
                textBox9.BackColor = Color.Red;
                MessageBox.Show("Необходимо ввести целое число.", "Внимание!",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }

            tableUpstream.Clear();
            for (int i = tableUpstream.Columns.Count - 1; i >= 0; i--)
            {
                tableUpstream.Columns.RemoveAt(i);
            }

            for (int i = 0; i < n; i++)
            {
                tableUpstream.Columns.Add(new DataColumn(i.ToString(), typeof(string)));
            }
            DataRow rowUpstream0 = tableUpstream.NewRow();
            DataRow rowUpstream1 = tableUpstream.NewRow();
            for (int i = 0; i < n; i++)
            {
                rowUpstream0[i] = 0;
                rowUpstream1[i] = 0;
            }
            tableUpstream.Rows.Add(rowUpstream0);
            tableUpstream.Rows.Add(rowUpstream1);
            dataGridView2.DataSource = tableUpstream;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox10.Text))
                return;

            button3.Enabled = false;

            int n;
            try
            {
                n = GetInt(textBox10.Text, 0);
                if (n > 20) { LimitMsg("20"); n = 20; textBox10.Text = "20"; }//Кол-во эл-тов массива QLL и ZLL
            }
            catch
            {
                textBox10.BackColor = Color.Red;
                MessageBox.Show("Необходимо ввести целое число.", "Внимание!",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }

            tableDownstream.Clear();
            for (int i = tableDownstream.Columns.Count - 1; i >= 0; i--)
            {
                tableDownstream.Columns.RemoveAt(i);
            }

            for (int i = 0; i < n; i++)
            {
                tableDownstream.Columns.Add(new DataColumn(i.ToString(), typeof(string)));
            }
            DataRow rowDownstream0 = tableDownstream.NewRow();
            DataRow rowDownstream1 = tableDownstream.NewRow();
            for (int i = 0; i < n; i++)
            {
                rowDownstream0[i] = 0;
                rowDownstream1[i] = 0;
            }
            tableDownstream.Rows.Add(rowDownstream0);
            tableDownstream.Rows.Add(rowDownstream1);
            dataGridView3.DataSource = tableDownstream;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.BackColor == Color.Red) { textBox1.BackColor = SystemColors.Window; }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.BackColor == Color.Red) { textBox2.BackColor = SystemColors.Window; }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.BackColor == Color.Red) { textBox5.BackColor = SystemColors.Window; }
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.BackColor == Color.Red) { textBox6.BackColor = SystemColors.Window; }
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.BackColor == Color.Red) { textBox7.BackColor = SystemColors.Window; }
        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            if (textBox9.BackColor == Color.Red) { textBox9.BackColor = SystemColors.Window; }
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (textBox8.BackColor == Color.Red) { textBox8.BackColor = SystemColors.Window; }
        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox11.BackColor == Color.Red) { textBox11.BackColor = SystemColors.Window; }
        }
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (textBox12.BackColor == Color.Red) { textBox12.BackColor = SystemColors.Window; }
        }
        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (textBox13.BackColor == Color.Red) { textBox13.BackColor = SystemColors.Window; }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.BackColor == Color.Red) { textBox3.BackColor = SystemColors.Window; }
        }
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
            if (textBox10.BackColor == Color.Red) { textBox10.BackColor = SystemColors.Window; }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // получаем выбранный файл
                string filename = saveFileDialog1.FileName;
                //если существует - удаляем
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                List<string> block1 = new List<string>();
                block1.Add(textBox1.Text);
                if (radioButton1.Checked == true)
                { block1.Add("0"); }
                else
                { block1.Add("1"); }
                block1.Add(textBox2.Text);
                block1.Add(textBox3.Text);
                block1.Add(textBox12.Text);
                block1.Add(textBox13.Text);
                //block1.Add(textBox4.Text);
                block1.Add(textBox5.Text);
                block1.Add(textBox6.Text);
                block1.Add(textBox7.Text);
                block1.Add(textBox11.Text);

                List<string> block2 = new List<string>();
                block2.Add(textBox8.Text);

                for (int i = 0; i < Convert.ToInt32(textBox8.Text); i++)
                {
                    block2.Add(Convert.ToString(dataGridView1.Rows[0].Cells[i].Value));
                }

                List<string> block3 = new List<string>();
                block3.Add(textBox9.Text);
                for (int i = 0; i < Convert.ToInt32(textBox9.Text); i++)
                {
                    block3.Add(Convert.ToString(dataGridView2.Rows[0].Cells[i].Value));
                }
                for (int i = 0; i < Convert.ToInt32(textBox9.Text); i++)
                {
                    block3.Add(Convert.ToString(dataGridView2.Rows[1].Cells[i].Value));
                }

                List<string> block4 = new List<string>();
                block4.Add(textBox10.Text);
                for (int i = 0; i < Convert.ToInt32(textBox10.Text); i++)
                {
                    block4.Add(Convert.ToString(dataGridView3.Rows[0].Cells[i].Value));
                }
                for (int i = 0; i < Convert.ToInt32(textBox10.Text); i++)
                {
                    block4.Add(Convert.ToString(dataGridView3.Rows[1].Cells[i].Value));
                }

                List<string> block5 = new List<string>();
                for (int i = 0; i < 12; i++)
                {
                    block5.Add(Convert.ToString(dataGridView4.Rows[0].Cells[i].Value));
                }

                List<string> block6 = new List<string>();
                for (int i = 0; i < 12; i++)
                {
                    block6.Add(Convert.ToString(dataGridView5.Rows[0].Cells[i].Value));
                }

                List<string> block7 = new List<string>();
                for (int i = 0; i < 12; i++)
                {
                    block7.Add(Convert.ToString(dataGridView6.Rows[0].Cells[i].Value));
                }

                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine(string.Join(";", block1));
                    writer.WriteLine(string.Join(";", block2));
                    writer.WriteLine(string.Join(";", block3));
                    writer.WriteLine(string.Join(";", block4));
                    writer.WriteLine(string.Join(";", block5));
                    writer.WriteLine(string.Join(";", block6));
                    writer.WriteLine(string.Join(";", block7));
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // получаем выбранный файл
                string filename = openFileDialog1.FileName;

                List<List<string>> blocks = new List<List<string>>();

                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        List<string> row = line.Split(';').ToList();
                        blocks.Add(row);
                    }
                }
                List<string> block1 = blocks.ElementAtOrDefault(0);
                List<string> block2 = blocks.ElementAtOrDefault(1);
                List<string> block3 = blocks.ElementAtOrDefault(2);
                List<string> block4 = blocks.ElementAtOrDefault(3);
                List<string> block5 = blocks.ElementAtOrDefault(4);
                List<string> block6 = blocks.ElementAtOrDefault(5);
                List<string> block7 = blocks.ElementAtOrDefault(6);

                try
                {
                    textBox1.Text = block1?.ElementAtOrDefault(0) ?? string.Empty;
                    string tmp;
                    tmp = block1?.ElementAtOrDefault(1) ?? string.Empty;
                    if (tmp == "0") { radioButton1.Checked = true; }
                    else { radioButton2.Checked = true; }
                    textBox2.Text = block1?.ElementAtOrDefault(2) ?? string.Empty;
                    textBox3.Text = block1?.ElementAtOrDefault(3) ?? string.Empty;
                    textBox12.Text = block1?.ElementAtOrDefault(4) ?? string.Empty;
                    textBox13.Text = block1?.ElementAtOrDefault(5) ?? string.Empty;
                    //textBox4.Text = block1?.ElementAtOrDefault(6) ?? string.Empty;
                    textBox5.Text = block1?.ElementAtOrDefault(6) ?? string.Empty;
                    textBox6.Text = block1?.ElementAtOrDefault(7) ?? string.Empty;
                    textBox7.Text = block1?.ElementAtOrDefault(8) ?? string.Empty;
                    textBox11.Text = block1?.ElementAtOrDefault(9) ?? string.Empty;

                    textBox8.Text = block2?.ElementAtOrDefault(0) ?? string.Empty;

                    int m;
                    try
                    { m = GetInt(textBox1.Text, 0); }
                    catch
                    {
                        textBox1.BackColor = Color.Red;
                        MessageBox.Show("Необходимо ввести целое число.", "Внимание!",
                        MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                        return;
                    }

                    int n;
                    try
                    { n = GetInt(textBox8.Text, 0); }
                    catch
                    {
                        textBox8.BackColor = Color.Red;
                        MessageBox.Show("Необходимо ввести целое число.", "Внимание!",
                        MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                        return;
                    }

                    int years = n / 12;

                    //Очищаем таблицу
                    tableTributary.Clear();
                    for (int i = tableTributary.Columns.Count - 1; i >= 0; i--)
                    {
                        tableTributary.Columns.RemoveAt(i);
                    }
                    //Создаем таблицу по заданному количеству столбцов
                    for (int i = 0; i < n; i++)
                    {
                        if (m > years * 12) { m = 1; }
                        tableTributary.Columns.Add(new DataColumn(m.ToString(), typeof(string)));
                        m++;
                    }

                    DataRow rowTributary = tableTributary.NewRow();
                    for (int i = 0; i < n; i++)
                    {
                        rowTributary[i] = block2?.ElementAtOrDefault(i + 1) ?? string.Empty;
                    }
                    tableTributary.Rows.Add(rowTributary);
                    dataGridView1.DataSource = tableTributary;


                    textBox9.Text = block3?.ElementAtOrDefault(0) ?? string.Empty;
                    try
                    { n = GetInt(textBox9.Text, 0); }
                    catch
                    {
                        textBox9.BackColor = Color.Red;
                        MessageBox.Show("Необходимо ввести целое число.", "Внимание!",
                        MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                        return;
                    }

                    tableUpstream.Clear();
                    for (int i = tableUpstream.Columns.Count - 1; i >= 0; i--)
                    {
                        tableUpstream.Columns.RemoveAt(i);
                    }
                    for (int i = 0; i < n; i++)
                    {
                        tableUpstream.Columns.Add(new DataColumn(i.ToString(), typeof(string)));
                    }

                    DataRow rowUpstream0 = tableUpstream.NewRow();
                    DataRow rowUpstream1 = tableUpstream.NewRow();
                    for (int i = 0; i < n; i++)
                    {
                        rowUpstream0[i] = block3?.ElementAtOrDefault(i + 1) ?? string.Empty;
                    }
                    for (int i = n; i < n * 2; i++)
                    {
                        rowUpstream1[i - n] = block3?.ElementAtOrDefault(i + 1) ?? string.Empty;
                    }
                    tableUpstream.Rows.Add(rowUpstream0);
                    tableUpstream.Rows.Add(rowUpstream1);
                    dataGridView2.DataSource = tableUpstream;


                    textBox10.Text = block4?.ElementAtOrDefault(0) ?? string.Empty;
                    try
                    { n = GetInt(textBox10.Text, 0); }
                    catch
                    {
                        textBox10.BackColor = Color.Red;
                        MessageBox.Show("Необходимо ввести целое число.", "Внимание!",
                        MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                        return;
                    }
                    tableDownstream.Clear();
                    for (int i = tableDownstream.Columns.Count - 1; i >= 0; i--)
                    {
                        tableDownstream.Columns.RemoveAt(i);
                    }
                    for (int i = 0; i < n; i++)
                    {
                        tableDownstream.Columns.Add(new DataColumn(i.ToString(), typeof(string)));
                    }
                    DataRow rowDownstream0 = tableDownstream.NewRow();
                    DataRow rowDownstream1 = tableDownstream.NewRow();
                    for (int i = 0; i < n; i++)
                    {
                        rowDownstream0[i] = block4?.ElementAtOrDefault(i + 1) ?? string.Empty;
                    }
                    for (int i = n; i < n * 2; i++)
                    {
                        rowDownstream1[i - n] = block4?.ElementAtOrDefault(i + 1) ?? string.Empty;
                    }
                    tableDownstream.Rows.Add(rowDownstream0);
                    tableDownstream.Rows.Add(rowDownstream1);
                    dataGridView3.DataSource = tableDownstream;


                    tableRemainder.Clear();
                    for (int i = tableRemainder.Columns.Count - 1; i >= 0; i--)
                    {
                        tableRemainder.Columns.RemoveAt(i);
                    }
                    for (int i = 0; i < 12; i++)
                    {
                        if (i < 9)
                        {
                            tableRemainder.Columns.Add(new DataColumn("0" + (i + 1).ToString(), typeof(string)));
                        }
                        else
                        {
                            tableRemainder.Columns.Add(new DataColumn((i + 1).ToString(), typeof(string)));
                        }
                    }
                    DataRow rowRemainder = tableRemainder.NewRow();
                    for (int i = 0; i < 12; i++)
                    {
                        rowRemainder[i] = block5?.ElementAtOrDefault(i) ?? string.Empty;
                    }
                    tableRemainder.Rows.Add(rowRemainder);
                    dataGridView4.DataSource = tableRemainder;



                    tableSelections.Clear();
                    for (int i = tableSelections.Columns.Count - 1; i >= 0; i--)
                    {
                        tableSelections.Columns.RemoveAt(i);
                    }
                    for (int i = 0; i < 12; i++)
                    {
                        if (i < 9)
                        {
                            tableSelections.Columns.Add(new DataColumn("0" + (i + 1).ToString(), typeof(string)));
                        }
                        else
                        {
                            tableSelections.Columns.Add(new DataColumn((i + 1).ToString(), typeof(string)));
                        }
                    }
                    DataRow rowSelections = tableSelections.NewRow();
                    for (int i = 0; i < 12; i++)
                    {
                        rowSelections[i] = block6?.ElementAtOrDefault(i) ?? string.Empty;
                    }
                    tableSelections.Rows.Add(rowSelections);
                    dataGridView5.DataSource = tableSelections;

                    tableDischarges.Clear();
                    for (int i = tableDischarges.Columns.Count - 1; i >= 0; i--)
                    {
                        tableDischarges.Columns.RemoveAt(i);
                    }
                    for (int i = 0; i < 12; i++)
                    {
                        if (i < 9)
                        {
                            tableDischarges.Columns.Add(new DataColumn("0" + (i + 1).ToString(), typeof(string)));
                        }
                        else
                        {
                            tableDischarges.Columns.Add(new DataColumn((i + 1).ToString(), typeof(string)));
                        }
                    }
                    DataRow rowDischarges = tableDischarges.NewRow();
                    for (int i = 0; i < 12; i++)
                    {
                        rowDischarges[i] = block7?.ElementAtOrDefault(i) ?? string.Empty;
                    }
                    tableDischarges.Rows.Add(rowDischarges);
                    dataGridView6.DataSource = tableDischarges;
                }
                catch (Exception ex)
                {
                    textBox1.Text = "0";
                    textBox2.Text = "0";
                    textBox3.Text = "0";
                    //textBox4.Text = "0";
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                    textBox7.Text = "0";
                    textBox8.Text = "0";
                    textBox9.Text = "0";
                    textBox10.Text = "0";
                    textBox11.Text = "0";
                    textBox12.Text = "0";
                    textBox13.Text = "0";

                    MessageBox.Show("Неверный формат файла исходных данных " +
                        "/ файл исходных данных повреждён \n\n" + ex, "Внимание!",
                    MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                }
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // Проверяем, существует ли Form2
            if (Application.OpenForms["Form2"] != null)
            {
                // Если Form2 открыта, закрываем ее
                ((Form)Application.OpenForms["Form2"]).Close();
            }

            int MF = 0;
            int M1 = 0;
            int NF = 0;
            int JF = 0;
            //int MA = 1;
            int MB = 1;
            int MDA = 0;
            bool LA = false;
            double[] Q = new double[600];
            double[] VV = new double[20];
            double[] ZUU = new double[20];
            double[] QLL = new double[20];
            double[] ZLL = new double[20];
            double[] VD = new double[12];
            double[] QU = new double[12];
            double[] QR = new double[12];
            double[] DDQR = new double[600];
            double[] MDEF = new double[600];
            double VU = 0;
            double VR = 0;
            //double QR = 0;
            double QPF = 0;
            double DK = 0;
            double EFF = 0;
            double VMN = 0;
            double VI = 0;

            try
            { 
                MF = GetInt(textBox8.Text, 0);  //кол-во значений притока
                if (MF == 0) { ZeroMsg(textBox8, "Приток"); }
            }
            catch
            {
                textBox8.BackColor = Color.Red;
                MessageBox.Show("Необходимо ввести целое число.", "Внимание!",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }
            try
            {
                M1 = GetInt(textBox1.Text, 0) - 1;  //начальный месяц
                if (M1 < 0) { ZeroMsg(textBox1, "Общие данные"); }
                if (M1 > 11) { LimitMsg("12"); M1 = 11; textBox1.Text = "12"; }//Кол-во месяцев в году
            }
            catch
            {
                textBox1.BackColor = Color.Red;
                MessageBox.Show("Необходимо ввести целое число.", "Внимание!",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }
            //Debug.WriteLine("{0}", M1);
            try
            {
                NF = GetInt(textBox9.Text, 0);  //кол-во точек кривой вдхр
                if (NF == 0) { ZeroMsg(textBox9, "Параметры вдхр."); }
            }
            catch
            {
                textBox9.BackColor = Color.Red;
                MessageBox.Show("Необходимо ввести целое число.", "Внимание!",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }
            try
            {
                JF = GetInt(textBox10.Text, 0);  //кол-во точек кривой нб
                if (JF == 0) { ZeroMsg(textBox10, "Параметры НБ"); }
            }
            catch
            {
                textBox10.BackColor = Color.Red;
                MessageBox.Show("Необходимо ввести целое число.", "Внимание!",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }
            LA = false; //индивидуальная
            MB = MF;
            try
            { MDA = GetInt(textBox11.Text, 0); } //номер контрольного месяца
            catch
            {
                textBox11.BackColor = Color.Red;
                MessageBox.Show("Необходимо ввести целое число.", "Внимание!",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }

            if (radioButton2.Checked == true) { LA = true; } //груповая

            for (int i = 0; i < MF; i++)
            {
                try
                { Q[i] = GetDouble((string)dataGridView1.Rows[0].Cells[i].Value, 0d); }
                catch
                {
                    MessageBox.Show("Вкладка Приток:\nГде-то в таблице введено не число. Необходимо ввести число.", "Внимание!",
                    MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                    return;
                }
            }
            for (int i = 0; i < NF; i++)
            {
                try
                {
                    VV[i] = GetDouble((string)dataGridView2.Rows[0].Cells[i].Value, 0d);
                    ZUU[i] = GetDouble((string)dataGridView2.Rows[1].Cells[i].Value, 0d);
                }
                catch
                {
                    MessageBox.Show("Вкладка Параметры вдхр.:\nГде-то в таблице введено не число. Необходимо ввести число.", "Внимание!",
                    MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                    return;
                }
            }
            if (!CheckArrayOrder(VV, NF))
            {
                TableErr("Параметры вдхр.\nОбъемы");
                return;
            }

            for (int i = 0; i < JF; i++)
            {
                try
                {
                    QLL[i] = GetDouble((string)dataGridView3.Rows[0].Cells[i].Value, 0d);
                    ZLL[i] = GetDouble((string)dataGridView3.Rows[1].Cells[i].Value, 0d);
                }
                catch
                {
                    MessageBox.Show("Вкладка Батиграфия НБ:\nГде-то в таблице введено не число. Необходимо ввести число.", "Внимание!",
                    MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                    return;
                }
            }
            if (!CheckArrayOrder(QLL, JF))
            {
                TableErr("Параметры НБ.\nРасходы");
                return;
            }

            try
            {
                VU = GetDouble(textBox2.Text, 0d);
                if (VU == 0) { ZeroMsg(textBox2, "Общие данные"); }
            }
            catch
            {
                textBox2.BackColor = Color.Red;
                MessageBox.Show("Необходимо ввести число.", "Внимание!",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }
            try
            {
                VR = GetDouble(textBox3.Text, 0d);
                if (VR == 0) { ZeroMsg(textBox3, "Общие данные"); }
            }
            catch
            {
                textBox3.BackColor = Color.Red;
                MessageBox.Show("Необходимо ввести число.", "Внимание!",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }
            //QR = Convert.ToDouble(textBox4.Text);
            try
            {
                QPF = GetDouble(textBox5.Text, 0d);
                if (QPF == 0) { ZeroMsg(textBox5, "Общие данные"); }
            }
            catch
            {
                textBox5.BackColor = Color.Red;
                MessageBox.Show("Необходимо ввести число.", "Внимание!",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }
            try
            { DK = GetDouble(textBox6.Text, 0d); }
            catch
            {
                textBox6.BackColor = Color.Red;
                MessageBox.Show("Необходимо ввести число.", "Внимание!",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }
            try
            {
                EFF = GetDouble(textBox7.Text, 0d);
                if (EFF == 0) { ZeroMsg(textBox7, "Общие данные"); }
            }
            catch
            {
                textBox7.BackColor = Color.Red;
                MessageBox.Show("Необходимо ввести число.", "Внимание!",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }
            try
            {
                VMN = GetDouble(textBox12.Text, 0d);
            }
            catch
            {
                textBox12.BackColor = Color.Red;
                MessageBox.Show("Необходимо ввести число.", "Внимание!",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }
            try
            { VI = GetDouble(textBox13.Text, 0d); }
            catch
            {
                textBox13.BackColor = Color.Red;
                MessageBox.Show("Необходимо ввести число.", "Внимание!",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                return;
            }

            //VD = new double[12];
            //QU = new double[12];
            //QR = new double[12];
            for (int i = 0; i < 12; i++)
            {
                try
                { VD[i] = GetDouble((string)dataGridView4.Rows[0].Cells[i].Value, 0d); }
                catch
                {
                    MessageBox.Show("Вкладка Диспетчерские остатки:\nГде-то в таблице введено не число. Необходимо ввести число.", "Внимание!",
                    MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                    return;
                }
                //Debug.WriteLine("{0}, {1}",i, VD[i]);
                try
                { QU[i] = GetDouble((string)dataGridView5.Rows[0].Cells[i].Value, 0d); }
                catch
                {
                    MessageBox.Show("Вкладка Отбор из вдхр.:\nГде-то в таблице введено не число. Необходимо ввести число.", "Внимание!",
                    MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                    return;
                }
                //Debug.WriteLine("{0}, {1}", i, QU[i]);
                try
                { QR[i] = GetDouble((string)dataGridView6.Rows[0].Cells[i].Value, 0d); }
                catch
                {
                    MessageBox.Show("Вкладка Гарантированные расходы:\nГде-то в таблице введено не число. Необходимо ввести число.", "Внимание!",
                    MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                    return;
                }
                //Debug.WriteLine("{0}, {1}", i, QR[i]);
            }

            double[] DVM = new double[600];
            double QP1;
            double QS1;
            double DV1;
            double VM1 = 0;
            double VD1;
            double VD11;
            double[] MDK = new double[600];
            double[] QP = new double[600];
            double[] QS = new double[600];
            double[] ZU = new double[600];
            double[] ZL = new double[600];
            double[] PH = new double[600];
            double[] PN = new double[600];
            double PHL;
            double VM11;
            double ZU1;
            double QL1;
            double ZL1;
            double PH1;
            double PN1;
            double QRR;
            double DVI;

            double[] B_Q = new double[600];
            double[] B_QP = new double[600];
            double[] B_PH = new double[600];
            double[] B_PN = new double[600]; 

            //Debug.WriteLine("{0}", M1);
            int M = 0;
            int MD = M1 - 1; // В ридах M1 - 1
            //Debug.WriteLine("MD={0}", MD);
            if (MD < 0) { MD = 11; }
            if (MD > 11) { MD = 0; }
            double VDI = VD[MD];
            //Debug.WriteLine("VDI={0}", VDI);
            double[] DV = new double[600];
            double VM = VI;
            //Debug.WriteLine("VM={0}", VM);
            //Debug.WriteLine("M={0}, MF={1}", M, MF);

            while (M <= MF)
            {
                //Debug.WriteLine("MD={0}", MD);
                //Debug.WriteLine("VM={0}, VDI={1}", VM, VDI);
                if (VM <= VDI)
                {
                    QP1 = QR[MD];
                }
                else
                {
                    DVI = VM - VDI;
                    QRR = QR[MD];
                    QP1 = QRR + DVI / 2.63;
                }
                if (QP1 > QPF) QP1 = QPF;
                QS1 = 0;
                MD++;
                if (MD > 11) { MD = 0; }
                DV1 = (Q[M] - QP1 - QS1 - QU[MD]) * 2.63;
                //Debug.WriteLine("Start[{0}]. DV1={1}, Q[M]={2}, QP1={3}, QS1={4} QU[MD]={5}, MD={6}",
                //    M, DV1, Q[M], QP1, QS1, QU[MD], MD);
                VM1 = VM + DV1;
                //Debug.WriteLine("VM={0}, DV1={1}, VM1={2}", VM, DV1, VM1);
                VD1 = VD[MD];
                VD11 = VD1 - VMN;
                //Debug.WriteLine("VD[MD]={0}, MD={1}", VD1, MD);
                //Debug.WriteLine("IF VU={0}, VM1={1}, VD1={2}", VU, VM1, VD1);
                if (VM1 > VU | VM1 < VD11)
                {
                    if (VM1 > VU)
                    {
                        QP1 = QP1 + (VM1 - VU) / 2.63;
                        //Debug.WriteLine("VM1>VU[{0}]. VM1={1}, VU={2}, QP1={3}",M, VM1, VU, QP1);
                        if (QP1 <= QPF)
                        {
                            DV1 = (Q[M] - QP1 - QS1 - QU[MD]) * 2.63;
                            //Debug.WriteLine("VM1 > VU . QP1 <= QPF[{0}]. DV1={1}", M, DV);
                            VM1 = VM + DV1;
                        }
                        else
                        {
                            QS1 = QP1 - QPF;
                            QP1 = QPF;
                            //Debug.WriteLine("VM1>VU, QP1>QPF[{0}]", M);
                            VM1 = VU;
                        }
                    }
                    else
                    {
                        QP1 = QP1 + (VM1 - VD11) / 2.63;
                        //Debug.WriteLine("VM1<=VU[{0}]. VM1={1}, VD11={2}, QP1={3}", M, VM1, VD11, QP1);
                        DV1 = (Q[M] - QP1 - QS1 - QU[MD]) * 2.63;
                        //Debug.WriteLine("VM1 <= VU");
                        VM1 = VM + DV1;
                    }
                }
                MDK[M] = MD;
                QP[M] = QP1;
                QS[M] = QS1;
                DV[M] = VM1;
                //Debug.WriteLine("VM1={0}, VD1={1}, DV={2}",VM1, VD1, DV);
                VM11 = VM1 + VR;
                //Debug.WriteLine("BB");
                ZU1 = Lag11(VM11, NF, VV, ZUU);
                //Debug.WriteLine("BB[{0}]. VM1={1}, VR={2}, VM11={3}, ZU1={4}", M, VM1, VR, VM11, ZU1);
                QL1 = QP1 + QS1;
                //Debug.WriteLine("HB");
                ZL1 = Lag11(QL1, JF, QLL, ZLL);
                //Debug.WriteLine("HB[{0}]. QP1={1}, QS1={2}, QL1={3}, ZL1={4}", M, QP1, QS1, QL1, ZL1);
                PH1 = ZU1 - ZL1;
                ZU[M] = ZU1;
                ZL[M] = ZL1;
                PH[M] = PH1;
                if (LA == true)
                {
                    PHL = DK * QP1 * QP1;
                }
                else
                {
                    PHL = DK;
                }
                PN1 = QP1 * (PH1 - PHL) * 9.81 * EFF;
                PN[M] = PN1;
                VM = VM1;
                VDI = VD1;
                M++;
            }
            double VMK = VM1;
            double S = 0;
            for (int j = 0; j < MF; j++)
            {
                S += QS[j] * 2.63;
            }
            double QM = 0;
            for (int j = 0; j < MF; j++)
            {
                QM += Q[j];
            }
            double QMM = QM / MF;
            double QPM = 0;
            for (int j = 0; j < MF; j++)
            {
                QPM += QP[j];
            }
            double QPMM = QPM / MF;
            double EPK = QPMM / QMM;
            double EP = 0;
            double EP1;
            for (int j = 0; j < MF; j++)
            {
                EP1 = PN[j] * 720;
                EP = EP + EP1;
            }
            double EEP = (EP * 12 / MF) * (1 + (VMN - VMK) / (2.63 * MF * QMM));

            //DEF
            int ML = 0;
            double DQR;
            M = 0;
            //NY = (MF / 12 - 1) * 12;
            MD = M1 - 1;
            //Debug.WriteLine("MD= {0}", MD);
            if (MD < 0) { MD = 11; }
            if (MD > 11) { MD = 0; }
            //Debug.WriteLine("MD= {0}, MF= {1}", MD, MF);
            while (M <= MF)
            {
                //Debug.WriteLine("M= {0}, MD= {1}", M, MD);
                double QPI = QP[M];
                double QRI = QR[MD];
                //Debug.WriteLine("QPI= {0}, QRI= {1}", QPI, QRI);
                if (QPI < QRI)
                {
                    DQR = QRI - QPI;
                    DDQR[ML] = DQR;
                    MDEF[ML] = M + 1;
                    //Debug.WriteLine("ML= {0}, DDQR= {1}, MDEF= {2}", ML, DDQR[ML], MDEF[ML]);
                    ML++;
                }
                M++;
                MD++;
                if (MD > 11) { MD = 0; }
            }

            tableShortage.Clear();
            for (int i = tableShortage.Columns.Count - 1; i >= 0; i--)
            {
                tableShortage.Columns.RemoveAt(i);
            }
            DataRow rowM = tableShortage.NewRow();
            DataRow rowD = tableShortage.NewRow();
            for (int i = 0; i < ML; i++)
            {
                tableShortage.Columns.Add();
                rowM[i] = MDEF[i];
                rowD[i] = Math.Round(DDQR[i], 1);
            }
            tableShortage.Rows.Add(rowM);
            tableShortage.Rows.Add(rowD);
            //-DEF

            //MONTH
            double[] PC = new double[60];
            ML = 0;
            //M = Month(MDA, M1, ML);
            M = ML * 12 + MDA - 1;
            while (M < MF)
            {
                //M = Month(MDA, M1, ML);
                M = ML * 12 + MDA - 1;
                if (M < 0) { M = 0; }
                PC[ML] = PN[M];
                ML++;
            }
            tableControlMonth.Clear();
            for (int i = tableControlMonth.Columns.Count - 1; i >= 0; i--)
            {
                tableControlMonth.Columns.RemoveAt(i);
            }
            DataRow rowN = tableControlMonth.NewRow();
            rowM = tableControlMonth.NewRow();
            for (int i = 0; i < MF / 12; i++)
            {
                tableControlMonth.Columns.Add();
                rowM[i] = (i + 1) * MDA;
                rowN[i] = Math.Round(PC[i], 0).ToString("#,#", CultureInfo.CurrentCulture);
            }
            tableControlMonth.Rows.Add(rowM);
            tableControlMonth.Rows.Add(rowN);
            //-MONTH

            List<string> columnsNamesResult = new List<string>()
            { "#", "Месяц", "Приток, м³/с", "Расход ГЭС, м³/с", "Сбросы, м³/с", "Отм. ВБ, м",
                "Отм. НБ, м", "Напор, м", "Мощность, кВт", "Остат. объем, млн.м³"};

            tableResults.Clear();
            for (int i = tableResults.Columns.Count - 1; i >= 0; i--)
            {
                tableResults.Columns.RemoveAt(i);
            }

            foreach (string colName in columnsNamesResult)
            {
                tableResults.Columns.Add(new DataColumn(colName, typeof(double)));
            }
            for (int i = 0; i < MF; i++)
            {
                DataRow dr = tableResults.NewRow();
                dr[0] = i + 1;
                dr[1] = MDK[i] + 1;
                if (!double.IsNaN(Q[i])) { dr[2] = Math.Round(Q[i], 1); } else { ErrorMsg(); return; }
                if (!double.IsNaN(QP[i])) { dr[3] = Math.Round(QP[i], 1); } else { ErrorMsg(); return; }
                if (!double.IsNaN(QS[i])) { dr[4] = Math.Round(QS[i], 1); } else { ErrorMsg(); return; }
                if (!double.IsNaN(ZU[i])) { dr[5] = Math.Round(ZU[i], 1); } else { ErrorMsg(); return; }
                if (!double.IsNaN(ZL[i])) { dr[6] = Math.Round(ZL[i], 1); } else { ErrorMsg(); return; }
                if (!double.IsNaN(PH[i])) { dr[7] = Math.Round(PH[i], 2); } else { ErrorMsg(); return; }
                if (!double.IsNaN(PN[i])) { dr[8] = Math.Round(PN[i], 0); } else { ErrorMsg(); return; }
                if (!double.IsNaN(DV[i])) { dr[9] = Math.Round(DV[i], 1); } else { ErrorMsg(); return; }

                tableResults.Rows.Add(dr);
            }
            //dataGridView6.DataSource = tableResults;

            List<string> ColSecurity = new List<string>() { "Обеспеченность, %", "Расход бытовой, м³/с",
            "Расход ГЭС, м³/с", "Напор, м", "Мощность ГЭС, среднесуточная, кВт"};

            tableSecurity.Clear();
            for (int i = tableSecurity.Columns.Count - 1; i >= 0; i--)
            {
                tableSecurity.Columns.RemoveAt(i);
            }

            foreach (string str in ColSecurity)
            {
                tableSecurity.Columns.Add(new DataColumn(str, typeof(double)));
            }

            B_Q = Rank(MF, Q);
            B_QP = Rank(MF, QP);
            B_PH = Rank(MF, PH);
            B_PN = Rank(MF, PN);

            for (int i = 0; i < MF; i++)
            {
                DataRow dr = tableSecurity.NewRow();
                dr[0] = Math.Round(100 - ((double)i + 1) / ((double)MF + 1) * 100, 2);
                dr[1] = Math.Round(B_Q[i], 1);
                dr[2] = Math.Round(B_QP[i], 1);
                dr[3] = Math.Round(B_PH[i], 2);
                dr[4] = Math.Round(B_PN[i], 0);
                tableSecurity.Rows.Add(dr);
                //Debug.WriteLine("{0}, {1}, {2}, {3}, {4}", dr[0], dr[1], dr[2], dr[3], dr[4]);
            }

            List<string> columnsExtRemainder = new List<string>()
            { "#", "Месяц", "Дисп. - задан.", "Дисп. - расч."};

            tableExtRemainder.Clear();
            for (int i = tableExtRemainder.Columns.Count - 1; i >= 0; i--)
            {
                tableExtRemainder.Columns.RemoveAt(i);
            }

            foreach (string colName in columnsExtRemainder)
            {
                tableExtRemainder.Columns.Add(new DataColumn(colName, typeof(double)));
            }
            M = M1;
            if (M > 11) M = 0;
            for (int i = 0; i < MF; i++)
            {
                DataRow dr = tableExtRemainder.NewRow();
                dr[0] = i + 1;
                dr[1] = M + 1;
                dr[2] = VD[M];
                dr[3] = Math.Round(DV[i], 1);
                M++;
                if (M > 11) M = 0;

                tableExtRemainder.Rows.Add(dr);
            }


            Form2 form2 = new Form2(tableResults, tableSecurity,
                tableShortage, tableControlMonth,
                tableExtRemainder,
                EEP, S, QMM, EPK, MDA, QR, M1);
                //EEP, S, QMM, EPK, MDA, QPF);
            form2.Show();
        }

        private void ErrorMsg()
        {
            MessageBox.Show($"Расчет не выполнен.\nПроверьте корректность исходных данных.", "Внимание!",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
        }

        private int Month(int MDA, int M1, int ML)
        {
            int M;
            if (MDA >= M1)
            {
                M = (MDA - 1) - (M1 - 1) + 1 + ML * 12;
            }
            else
            {
                M = (MDA - 1) - (M1 - 1) + 1 + (ML + 1) * 12;
            }
            return M;
        }
        private double Lag11(double D, int N, double[] X, double[] Y)
        {
            double V = 0;
            int i1;
            double DX;
            double DYDX;
            for (int i = 1; i < N; i++)
            {
                DX = X[N - 1] - X[N - 2];
                DYDX = (Y[N - 1] - Y[N - 2]) / DX;
                V = (Y[N - 1] * (D - X[N - 2]) - Y[N - 2] * (D - X[N - 1])) / DX;
                //Debug.WriteLine("i={0}, i1={1}, X[i]={2}, D={3}, X[i1]={4}, Y[i]={5}," +
                //    " Y[i1]={6}, DX={7}, DYDX={8}, V={9}", N - 1, N - 2, X[N - 1], D, X[N - 2],
                //    Y[N - 1], Y[N - 2], DX, DYDX, V);
                //Debug.WriteLine("i={0}, D={1}, X[i]={2}, D-X[i]={3}", i, D, X[i], D - X[i]);
                if (D - X[i] <= 0)
                {
                    i1 = i - 1;
                    DX = X[i] - X[i1];
                    DYDX = (Y[i] - Y[i1]) / DX;
                    V = (Y[i] * (D - X[i1]) - Y[i1] * (D - X[i])) / DX;
                    //Debug.WriteLine("i={0}, i1={1}, X[i]={2}, D={3}, X[i1]={4}, Y[i]={5}," +
                    //    " Y[i1]={6}, DX={7}, DYDX={8}, V={9}", i, i1, X[i], D, X[i1],
                    //    Y[i], Y[i1], DX, DYDX, V);
                    break;
                }
            }
            return V;
        }

        private double[] Rank(int _MF, double[] _A)
        {
            int K = 0;
            int N = _MF;
            int L = 0;
            double[] A = new double[600];
            //double[] B = new double[400];
            double[] AR = new double[600];

            for (int i = 0; i < N; i++)
            {
                A[i] = _A[i];
            }

            while (N > 0)
            {
                double Amin = 1000000000;
                for (int i = 0; i < N; i++)
                {
                    if (A[i] < Amin)
                    {
                        Amin = A[i];
                        K = i;
                    }
                }
                //Debug.WriteLine("K={0}, Amin={1}", K, Amin);
                if (K != N)
                {
                    int N1 = N - 1;
                    for (int i = K; i <= N1; i++)
                    {
                        A[i] = A[i + 1];
                    }
                }
                AR[L] = Amin;
                //Debug.WriteLine("N={0}, L={1}, AR[L]={2}", N, L, AR[L]);
                L++;
                N--;
            }
            //ARmin = AR[1];

            //for (int i = 0; i < 20; i++)
            //{
            //    L = i * (_MF - 1) / 19;
            //    B[i] = AR[L];
            //    //Debug.WriteLine("L={0}, i={1}, MF={2}", L, i, _MF);
            //}
            return AR;
        }

        private double GetDouble(string str, double defaultValue)
        {
            double result;
            //Try parsing in the current culture
            if (!double.TryParse(str, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
                //Then try in US english
                !double.TryParse(str, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&
                //Then in neutral language
                !double.TryParse(str, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                result = defaultValue;
                throw new ArgumentException("Необходимо ввести число.");
            }

            return result;
        }

        private Int32 GetInt(string str, Int32 defaultValue)
        {
            Int32 result;
            //Try parsing in the current culture
            if (!int.TryParse(str, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
                //Then try in US english
                !int.TryParse(str, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&
                //Then in neutral language
                !int.TryParse(str, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                result = defaultValue;
                throw new ArgumentException("Необходимо ввести целое число.");
            }

            return result;
        }

        private void LimitMsg(string str)
        {
            MessageBox.Show($"Значение не должно превышать {str}.", "Внимание!",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
        }

        private void ZeroMsg(TextBox textBox, string tab)
        {
            textBox.BackColor = Color.Red;
            MessageBox.Show($"Вкладка {tab}. Значение не может быть равно нулю.", "Внимание!",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
        }

        private bool CheckArrayOrder(double[] A, int N)
        {
            for (int i = 0; i < N - 1; i++)
            {
                //Debug.WriteLine("A.L={0}, i={1}, A={2}, A+1={3}", N, i, A[i], A[i + 1]);
                if (A[i] >= A[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        private void TableErr(string str)
        {
            MessageBox.Show($"{str} необходимо задавать по возрастанию.", "Внимание!",
                MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
                e.Handled = true;
            }
        }
        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(sender, e);
                e.Handled = true;
            }
        }
        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3_Click(sender, e);
                e.Handled = true;
            }
        }

    }
}
