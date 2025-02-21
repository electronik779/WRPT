using Microsoft.VisualBasic.Devices;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace WRPT
{
    public partial class Form2 : Form
    {
        public Form2(DataTable tableResults, DataTable tableSecurity,
            DataTable tableShortage, DataTable tableControlMonth,
            double EEP, double S, double QMM, double EPK, int MDA)
        {
            InitializeComponent();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            saveFileDialog1.Filter = "CSV файлы (*.csv)|*.csv";
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.AddExtension = true;

            dataGridView1.DataSource = tableResults;
            dataGridView2.DataSource = tableSecurity;
            dataGridView3.DataSource = tableShortage;
            dataGridView4.DataSource = tableControlMonth;

            int ResultCount = tableResults.Rows.Count;
            int SecurityCount = tableSecurity.Rows.Count;

            int[] x = new int[] { 0, 0, 0 };
            int[] y = new int[] { 2, 3, 4 };
            string[] list = new string[] { "Приток", "Расход ГЭС", "Сбросы" };
            string[] list2 = new string[] { "Месяц", "м³/с" };
            BuildChart(chart1, tableResults, "column", list, "left", 3, x, y, 
                1, ResultCount, 1, false, list2);
            x = new int[] { 0 };
            y = new int[] { 5 };
            list = new string[] { "Уровень ВБ" };
            list2 = new string[] { "Месяц", "м" };
            BuildChart(chart2, tableResults, "line", list, "left", 1, x, y, 
                1, ResultCount, 1, true, list2);
            x = new int[] { 0 };
            y = new int[] { 6 };
            list = new string[] { "Уровень НБ, м" };
            list2 = new string[] { "Месяц", "м" };
            BuildChart(chart3, tableResults, "column", list, "left", 1, x, y, 
                1, ResultCount, 1, true, list2);
            x = new int[] { 0 };
            y = new int[] { 7 };
            list = new string[] { "Напор" };
            list2 = new string[] { "Месяц", "м" };
            BuildChart(chart4, tableResults, "column", list, "left", 1, x, y, 
                1, ResultCount, 1, true, list2);
            x = new int[] { 0 };
            y = new int[] { 8 };
            list = new string[] { "Мощность" };
            list2 = new string[] { "Месяц", "кВт" };
            BuildChart(chart5, tableResults, "column", list, "left", 1, x, y, 
                1, ResultCount, 1, false, list2);
            x = new int[] { 0 };
            y = new int[] { 1 };
            list = new string[] { "Приток" };
            list2 = new string[] { "Обеспеченность, %", "м³/с" };
            BuildChart(chart6, tableSecurity, "line", list, "right", 1, x, y, 
                0, 100, 20, false, list2);
            x = new int[] { 0 };
            y = new int[] { 2 };
            list = new string[] { "Расход ГЭС" };
            list2 = new string[] { "Обеспеченность, %", "м³/с" };
            BuildChart(chart7, tableSecurity, "line", list, "right", 1, x, y,
                0, 100, 20, false, list2);
            x = new int[] { 0 };
            y = new int[] { 3 };
            list = new string[] { "Напор" };
            list2 = new string[] { "Обеспеченность, %", "м" };
            BuildChart(chart8, tableSecurity, "line", list, "right", 1, x, y,
                0, 100, 20, true, list2);
            x = new int[] { 0 };
            y = new int[] { 4 };
            list = new string[] { "Мощность" };
            list2 = new string[] { "Обеспеченность, %", "кВт" };
            BuildChart(chart9, tableSecurity, "line", list, "right", 1, x, y,
                0, 100, 20, false, list2);

            label2.Text = (Math.Round(EEP, 0)).ToString("#,#", CultureInfo.CurrentCulture);
            label4.Text = (Math.Round(S, 0)).ToString("#,#", CultureInfo.CurrentCulture);
            label5.Text = (Math.Round(QMM, 1)).ToString("#,#", CultureInfo.CurrentCulture);
            label7.Text = (Math.Round(EPK, 3)).ToString();
            label11.Text = $"(месяц {MDA.ToString()})";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
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
            dataGridView4.ColumnHeadersVisible = false;
            dataGridView4.AllowUserToOrderColumns = false;
        }

        private void BuildChart(Chart ch, DataTable data,
            string type, string[] list, string pos, int n, int[] x, int[] y, 
            int Xmin, int Xmax, int step, bool isLimit, string[] axis)
        //название диаграммы,
        //название таблицы данных,
        //тип графика: column - столбчетая, остальное - линия,
        //список названий линий,
        //легенда слева - left иначе справа,
        //количество линий,
        //номер столбца DataTable с координатами X,
        //номер столбца DataTable с координатами Y,
        //минимальное значение оси X,
        //максимальное значение оси X,
        //шаг подписей оси X,
        //ограничивать min - max оси Y
        //список названий осей - первая X, вторая Y.
        {
            // Создаем новый объект диаграммы
            ch.ChartAreas.Clear();
            ch.Series.Clear();

            ch.ChartAreas.Add(new ChartArea("ChartArea"));
            ch.ChartAreas[0].AxisX.Minimum = Xmin;
            ch.ChartAreas[0].AxisX.Maximum = Xmax;
            ch.ChartAreas[0].AxisX.Interval = step;
            ch.Legends[0].DockedToChartArea = "ChartArea";
            ch.Legends[0].IsDockedInsideChartArea = true;

            if (pos == "left")
            {
                ch.Legends[0].Docking = Docking.Left;
            }

            ch.Legends.Add(new Legend("Legend"));

            if (axis[0] != null)
            {
                ch.ChartAreas[0].AxisX.Title = axis[0];
            }
            if (axis[1] != null)
            {
                ch.ChartAreas[0].AxisY.Title = axis[1];
            }

            for (int seriesNum = 0; seriesNum < n; seriesNum++)
            {
                if (isLimit)
                {
                    int MaxY = Convert.ToInt32(data.Rows[0][y[seriesNum]]);
                    int MinY = Convert.ToInt32(data.Rows[0][y[seriesNum]]);
                    //Debug.WriteLine("{0}, {1}, {2}", seriesNum, MinY, MaxY);
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        double Fig1 = Math.Floor(Convert.ToDouble(data.Rows[i][y[seriesNum]]));
                        double Fig2 = Math.Ceiling(Convert.ToDouble(data.Rows[i][y[seriesNum]]));
                        if (Fig1 < MinY)
                        { MinY = Convert.ToInt32(Fig1); }

                        if (Fig2 > MaxY)
                        { MaxY = Convert.ToInt32(Fig2); }
                    }

                    //Debug.WriteLine("{0}, {1}", MinY, MaxY);
                    ch.ChartAreas[0].AxisY.Minimum = MinY;
                    ch.ChartAreas[0].AxisY.Maximum = MaxY;
                }

                // Добавляем серию
                Series series = new Series
                {
                    //ChartType = SeriesChartType.Line,
                    //Color = GetSeriesColor(seriesNum),
                    BorderWidth = 2,
                    Name = list[seriesNum]
                };

                // Цикл по строкам DataTable
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    series.ChartType = SeriesChartType.Line;
                    if (type == "column")
                    {
                        series.ChartType = SeriesChartType.Column;
                    }
                    // Добавить точки для серии диаграммы
                    series.Points.AddXY(data.Rows[i][x[seriesNum]], data.Rows[i][y[seriesNum]]);
                }

                ch.Series.Add(series);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // получаем выбранный файл
                string filename = saveFileDialog1.FileName;
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                using (StreamWriter writer = new StreamWriter(filename, true,
                    System.Text.Encoding.GetEncoding(1251)))
                {
                    List<string> columnsNames = new List<string>()
                   { "#", "Месяц", "Приток, м3/с", "Расход ГЭС, м3/с", "Сбросы, м3/с", "Отм. ВБ, м",
                   "Отм. НБ, м", "Напор, м", "Мощность, кВт", "Избыт. объем, млн.м3"};
                    writer.WriteLine(string.Join(";", columnsNames));

                    //Debug.WriteLine("{0}", dataGridView1.RowCount);
                    //Debug.WriteLine("{0}", dataGridView1.ColumnCount);
                    for (int j = 0; j < dataGridView1.RowCount; j++)
                    {
                        List<string> list = new List<string>();
                        for (int i = 0; i < dataGridView1.ColumnCount; i++)
                        {
                            double tmp;
                            tmp = Convert.ToDouble(dataGridView1.Rows[j].Cells[i].Value);
                            //Debug.WriteLine("{0}, {1}, {2}", j, i, tmp);
                            list.Add (tmp.ToString());
                        }
                        writer.WriteLine(string.Join(';', list));
                    }

                    columnsNames = new List<string>()
                   { "Обеспеченность, %", "Приток, м3/с", "Расход ГЭС, м3/с",
                        "Напор, м", "Мощность, кВт"};
                    writer.WriteLine(string.Join(";", columnsNames));

                    for (int j = 0; j < dataGridView2.RowCount; j++)
                    {
                        List<string> list = new List<string>();
                        for (int i = 0; i < dataGridView2.ColumnCount; i++)
                        {
                            double tmp;
                            tmp = Convert.ToDouble(dataGridView2.Rows[j].Cells[i].Value);
                            list.Add(tmp.ToString());
                        }
                        writer.WriteLine(string.Join(';', list));
                    }

                    columnsNames = new List<string>()
                    { "Среднегодовая выработка, кВт ч"};
                    columnsNames.Add(label2.Text);
                    writer.WriteLine(string.Join(";", columnsNames));

                    columnsNames = new List<string>()
                    { "Суммарный объем сбросов, млн.м3"};
                    columnsNames.Add(label4.Text);
                    writer.WriteLine(string.Join(";", columnsNames));

                    columnsNames = new List<string>()
                    { "Средний расход, м3/с"};
                    columnsNames.Add(label5.Text);
                    writer.WriteLine(string.Join(";", columnsNames));

                    columnsNames = new List<string>()
                    { "Коэффициент использования стока"};
                    columnsNames.Add(label7.Text);
                    writer.WriteLine(string.Join(";", columnsNames));

                    writer.WriteLine(string.Join(";", "Дефициты по заданным расходам"));
                    List<string> ShortageM = new List<string>();
                    List<string> ShortageD = new List<string>();
                    ShortageM.Add("Месяц");
                    ShortageD.Add("Дефицит, м3/с");
                    for (int i = 0; i < dataGridView3.ColumnCount;i++)
                    {
                        double tmp;
                        tmp = Convert.ToDouble(dataGridView3.Rows[0].Cells[i].Value);
                        ShortageM.Add(Convert.ToString(tmp));
                        tmp = Convert.ToDouble(dataGridView3.Rows[1].Cells[i].Value);
                        ShortageD.Add(Convert.ToString(tmp));
                    }
                    writer.WriteLine(string.Join(";", ShortageM));
                    writer.WriteLine(string.Join(";", ShortageD));

                    writer.WriteLine(string.Join(";", "Мощность контрольного месяца"));
                    List<string> ControlMonthM = new List<string>();
                    List<string> ControlMonthN = new List<string>();
                    ControlMonthM.Add("Месяц");
                    ControlMonthN.Add("Мощность, кВт");
                    for (int i = 0; i < dataGridView4.ColumnCount; i++)
                    {
                        double tmp;
                        tmp = Convert.ToDouble(dataGridView4.Rows[0].Cells[i].Value);
                        ControlMonthM.Add(Convert.ToString(tmp));
                        tmp = Convert.ToDouble(dataGridView4.Rows[1].Cells[i].Value);
                        ControlMonthN.Add(Convert.ToString(tmp));
                    }
                    writer.WriteLine(string.Join(";", ControlMonthM));
                    writer.WriteLine(string.Join(";", ControlMonthN));
                }
            }
        }
    }
}
