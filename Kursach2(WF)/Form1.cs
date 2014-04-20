using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
//using System.Threading;

namespace Kursach2_WF_
{
    public partial class Form1 : Form
    {
        int opt = 0;
        int M;
        int N;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bool is64bit = System.Environment.Is64BitOperatingSystem;
            string netkey = "SOFTWARE\\Microsoft\\.NetFramework";
            string install = "", version = "";
            RegistryKey net = null, latestverkey = null;

            if (is64bit == true)
            {
                net = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(netkey);
            }
            else
            {
                net = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(netkey);
            }
            if (net != null)
            {
                install = net.GetValue("InstallRoot").ToString();
                version = string.Format("v{0}.{1}.{2}\\", Environment.Version.Major, Environment.Version.Minor, Environment.Version.Build);
                if (is64bit == true)
                {
                    latestverkey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(System.IO.Path.Combine(netkey, version) + "SKUs\\.NETFramework,Version=v4.5.1");
                }
                else
                {
                    latestverkey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(System.IO.Path.Combine(netkey, version) + "SKUs\\.NETFramework,Version=v4.5.1");
                }
            }
            else
            {
                MessageBox.Show(".NetFramework не установлен");
            }
            if (latestverkey == null)
            {
                MessageBox.Show(".NetFramework 4.5.1 не установлен");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '-' && (sender as TextBox).Text.Length > 0)
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            if (tb != null)
            {
                e.Control.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
            }
        }
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '-' && (sender as TextBox).Text.Length > 0)
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            textBox3.Visible = false;
            textBox3.Text = "";
            label4.Visible = false;
            dataGridView2.Visible = false;
            opt = 1;

            label2.Location = new Point(this.label2.Location.X, dataGridView1.Location.X + dataGridView1.Size.Width + 5);
            label2.Location = new Point(this.label2.Location.Y, dataGridView1.Location.Y - 10);
            label2.Text = "T";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            textBox3.Visible = false;
            textBox3.Text = "";
            label4.Visible = false;
            dataGridView2.Visible = false;
            opt = 2;

            label2.Location = new Point(this.label2.Location.X, dataGridView1.Location.X + dataGridView1.Size.Width + 5);
            label2.Location = new Point(this.label2.Location.Y, dataGridView1.Location.Y - 10);
            label2.Text = "-1";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            label2.Text = "X";
            textBox3.Visible = true;
            label4.Visible = false;
            dataGridView2.Visible = false;
            opt = 3;

            label2.Location = new Point(this.label2.Location.X, dataGridView1.Location.X - label2.Size.Width - 3);
            label2.Location = new Point(this.label2.Location.Y, dataGridView1.Location.Y + (dataGridView1.Size.Height / 2) - 7);
            textBox3.Location = new Point(this.textBox3.Location.X, dataGridView1.Location.X - textBox3.Size.Width - label2.Size.Width - 6);
            textBox3.Location = new Point(this.textBox3.Location.Y, dataGridView1.Location.Y + (dataGridView1.Size.Height / 2) - 10);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
            textBox3.Visible = true;
            label4.Visible = false;
            dataGridView2.Visible = false;
            opt = 5;

            textBox3.Location = new Point(this.textBox3.Location.X, dataGridView1.Location.X + dataGridView1.Size.Width + 5);
            textBox3.Location = new Point(this.textBox3.Location.Y, dataGridView1.Location.Y - 15);

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            label2.Text = "det";
            textBox3.Visible = false;
            label4.Visible = false;
            dataGridView2.Visible = false;
            opt = 6;

            label2.Location = new Point(this.label2.Location.X, dataGridView1.Location.X - label2.Size.Width - 3);
            label2.Location = new Point(this.label2.Location.Y, dataGridView1.Location.Y + (dataGridView1.Size.Height / 2) - 7);
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            radioButton5.Enabled = false;
            radioButton6.Enabled = false;
            radioButton7.Enabled = false;
            label4.Visible = false;
            button2.Enabled = false;
            button3.Enabled = false;
            dataGridView2.Visible = false;
            dataGridView1.Visible = true;

            M = Convert.ToInt32(textBox1.Text);
            N = Convert.ToInt32(textBox2.Text);

            if ((Convert.ToInt32(textBox1.Text) > 0) && (Convert.ToInt32(textBox2.Text) > 0))
            {
                dataGridView1.RowCount = M;
                dataGridView1.ColumnCount = N;
                int i = 0, j = 0;

                for (i = 0; i < M; i++)
                {
                    for (j = 0; j < N; j++)
                    {
                        dataGridView1.Columns[j].Width = 25;
                        dataGridView1.Rows[i].Height = 20;
                        dataGridView1.Rows[i].Cells[j].Value = i*j+1;
                    }
                }

                int x, y;
                x = dataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 1;
                y = dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + 1;
                if (x > 201 + System.Windows.Forms.SystemInformation.VerticalScrollBarWidth) x = 202 + System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
                if (y > 161 + System.Windows.Forms.SystemInformation.HorizontalScrollBarHeight) y = 162 + System.Windows.Forms.SystemInformation.HorizontalScrollBarHeight;
                dataGridView1.Location = new Point(this.dataGridView1.Location.X, textBox1.Location.X);
                dataGridView1.Location = new Point(this.dataGridView1.Location.Y, (400 - y) / 2);
                dataGridView1.Size = new System.Drawing.Size(x, y);

                radioButton1.Enabled = true;
                if (M == N)
                {
                    radioButton2.Enabled = true;
                }
                radioButton3.Enabled = true;
                radioButton4.Enabled = false;
                radioButton5.Enabled = true;
                radioButton6.Enabled = true;
                radioButton7.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;

                if (radioButton1.Checked == true)
                {
                    radioButton1.Checked = false;
                    radioButton1.Checked = true;
                }
                if (radioButton2.Checked == true)
                {
                    radioButton2.Checked = false;
                    radioButton2.Checked = true;
                }
                if (radioButton3.Checked == true)
                {
                    radioButton3.Checked = false;
                    radioButton3.Checked = true;
                }
                if (radioButton4.Checked == true)
                {
                    radioButton4.Checked = false;
                    radioButton4.Checked = true;
                }
                if (radioButton5.Checked == true)
                {
                    radioButton5.Checked = false;
                    radioButton5.Checked = true;
                }
                if (radioButton6.Checked == true)
                {
                    radioButton6.Checked = false;
                    radioButton6.Checked = true;
                }
                if (radioButton7.Checked == true)
                {
                    radioButton7.Checked = false;
                    radioButton7.Checked = true;
                }
            }
            else
            {
                MessageBox.Show("Размеры не могут быть равны 0");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool notfin = false;
            double[,] values = new double[dataGridView1.Rows.Count, dataGridView1.Columns.Count];

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value == null || dataGridView1.Rows[i].Cells[j].Value.ToString() == "-" || dataGridView1.Rows[i].Cells[j].Value.ToString() == "," || dataGridView1.Rows[i].Cells[j].Value.ToString() == "-,")
                    {
                        notfin = true;
                        break;
                    }
                    else
                    {
                        values[i, j] = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }
                }
                if (notfin == true)
                {
                    break;
                }
            }
            if (notfin == true)
            {
                MessageBox.Show("Заполните матрицу");
            }
            else
            {
                if (opt == 1)
                {
                    label4.Visible = true;
                    label4.Text = "=";

                    int i = 0, j = 0;
                    dataGridView2.Visible = true;
                    dataGridView2.RowCount = dataGridView1.Columns.Count;
                    dataGridView2.ColumnCount = dataGridView1.Rows.Count;

                    for (i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        for (j = 0; j < dataGridView2.Columns.Count; j++)
                        {
                            dataGridView2.Columns[j].Width = 25;
                            dataGridView2.Rows[i].Height = 20;
                            dataGridView2.Rows[i].Cells[j].Value = values[j, i];
                        }
                    }

                    int x, y;
                    x = dataGridView2.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 1;
                    y = dataGridView2.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + 1;
                    if (x > 201 + System.Windows.Forms.SystemInformation.VerticalScrollBarWidth) x = 202 + System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
                    if (y > 161 + System.Windows.Forms.SystemInformation.HorizontalScrollBarHeight) y = 162 + System.Windows.Forms.SystemInformation.HorizontalScrollBarHeight;
                    label4.Location = new Point(this.label4.Location.X, dataGridView1.Location.X + dataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 10);
                    label4.Location = new Point(this.label4.Location.Y, dataGridView1.Location.Y + (dataGridView1.Size.Height / 2) - 7);
                    dataGridView2.Location = new Point(this.dataGridView2.Location.X, label4.Location.X + label4.Size.Width + 10);
                    dataGridView2.Location = new Point(this.dataGridView2.Location.Y, (400 - y) / 2);
                    dataGridView2.Size = new System.Drawing.Size(x, y);

                }
                else if (opt == 2)
                {
                    int n = dataGridView1.Rows.Count;
                    double[,] values2 = new double[dataGridView1.Rows.Count, dataGridView1.Columns.Count];
                    double det = utils.InverseDeterm(n, values);

                    if (det != 0)
                    {
                        label4.Visible = true;
                        label4.Text = "=";

                        int i, j;
                        int x, y;
                        dataGridView2.Visible = true;
                        dataGridView2.RowCount = dataGridView1.Rows.Count;
                        dataGridView2.ColumnCount = dataGridView1.Columns.Count;


                        values2 = utils.Inverse(n, values);

                        i = 0;
                        j = 0;
                        for (i = 0; i < dataGridView2.Rows.Count; i++)
                        {
                            for (j = 0; j < dataGridView2.Columns.Count; j++)
                            {
                                dataGridView2.Columns[j].Width = 25;
                                dataGridView2.Rows[i].Height = 20;
                                dataGridView2.Rows[i].Cells[j].Value = values2[i, j];
                            }
                        }

                        x = dataGridView2.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 1;
                        y = dataGridView2.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + 1;
                        if (x > 201 + System.Windows.Forms.SystemInformation.VerticalScrollBarWidth) x = 202 + System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
                        if (y > 161 + System.Windows.Forms.SystemInformation.HorizontalScrollBarHeight) y = 162 + System.Windows.Forms.SystemInformation.HorizontalScrollBarHeight;
                        label4.Location = new Point(this.label4.Location.X, dataGridView1.Location.X + dataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 10);
                        label4.Location = new Point(this.label4.Location.Y, dataGridView1.Location.Y + (dataGridView1.Size.Height / 2) - 7);
                        dataGridView2.Location = new Point(this.dataGridView2.Location.X, label4.Location.X + label4.Size.Width + 10);
                        dataGridView2.Location = new Point(this.dataGridView2.Location.Y, (400 - y) / 2);
                        dataGridView2.Size = new System.Drawing.Size(x, y);
                    }
                    else
                    {
                        MessageBox.Show("У даной матрицы определитель 0. Невозможно найти матрицу с определителем 0");
                    }
                }
                else if (opt == 3)
                {
                    if (textBox3.Text != "" && textBox3.Text != "-" && textBox3.Text != "-," && textBox3.Text != ",")
                    {
                        label4.Visible = true;
                        label4.Text = "=";

                        int i, j;
                        dataGridView2.Visible = true;
                        dataGridView2.RowCount = dataGridView1.Rows.Count;
                        dataGridView2.ColumnCount = dataGridView1.Columns.Count;

                        for (i = 0; i < dataGridView2.Rows.Count; i++)
                        {
                            for (j = 0; j < dataGridView2.Columns.Count; j++)
                            {
                                dataGridView2.Columns[j].Width = 25;
                                dataGridView2.Rows[i].Height = 20;
                                dataGridView2.Rows[i].Cells[j].Value = Convert.ToDouble(textBox3.Text.ToString()) * values[i, j];
                            }
                        }

                        int x, y;

                        x = dataGridView2.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 1;
                        y = dataGridView2.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + 1;
                        if (x > 201 + System.Windows.Forms.SystemInformation.VerticalScrollBarWidth) x = 202 + System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
                        if (y > 161 + System.Windows.Forms.SystemInformation.HorizontalScrollBarHeight) y = 162 + System.Windows.Forms.SystemInformation.HorizontalScrollBarHeight;
                        label4.Location = new Point(this.label4.Location.X, dataGridView1.Location.X + dataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 10);
                        label4.Location = new Point(this.label4.Location.Y, dataGridView1.Location.Y + (dataGridView1.Size.Height / 2) - 7);
                        dataGridView2.Location = new Point(this.dataGridView2.Location.X, label4.Location.X + label4.Size.Width + 10);
                        dataGridView2.Location = new Point(this.dataGridView2.Location.Y, (400 - y) / 2);
                        dataGridView2.Size = new System.Drawing.Size(x, y);
                    }
                    else
                    {
                        MessageBox.Show("Введите число на которое умножается матрица");
                    }
                }
                else if (opt == 4)
                {

                }
                else if (opt == 5)
                {

                }
                else if (opt == 6)
                {

                }
                else if (opt == 7)
                {

                }
                else
                {
                    MessageBox.Show("Выберите действие");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            dataGridView2.Visible = false;
            textBox3.Text = "";

            int i = 0, j = 0;
            for (i = 0; i < M; i++)
            {
                for (j = 0; j < N; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = null;
                }
            }
        }
    }


    public class utils
    {
        public static double InverseDeterm(int n, double[,] values)
        {
            int i, j, j1, j2;
            double det = 0;
            double[,] values2 = new double[n - 1, n - 1];

            if (n == 1)
            {
                det = values[0, 0];
            }
            else if (n == 2)
            {
                det = values[0, 0] * values[1, 1] - values[1, 0] * values[0, 1];
            }
            else
            {
                det = 0;
                for (j1 = 0; j1 < n; j1++)
                {
                    for (i = 1; i < n; i++)
                    {
                        j2 = 0;
                        for (j = 0; j < n; j++)
                        {
                            if (j == j1)
                                continue;
                            values2[i - 1, j2] = values[i, j];
                            j2++;
                        }
                    }
                    det += Math.Pow(-1.0, j1 + 2.0) * values[0, j1] * InverseDeterm(n - 1, values2);
                }
            }
            return (det);
        }

        public static double[,] Inverse(int n, double[,] values)
        {
            int i, j, ii, jj, i1, j1;
            double det;
            double[,] values2 = new double[n - 1, n - 1];
            double[,] values3 = new double[n, n];

            for (j = 0; j < n; j++)
            {
                for (i = 0; i < n; i++)
                {
                    i1 = 0;
                    for (ii = 0; ii < n; ii++)
                    {
                        if (ii == i)
                            continue;
                        j1 = 0;
                        for (jj = 0; jj < n; jj++)
                        {
                            if (jj == j)
                                continue;
                            values2[i1, j1] = values[ii, jj];
                            j1++;
                        }
                        i1++;
                    }
                    det = InverseDeterm(n - 1, values2);
                    values3[i, j] = Math.Pow(-1.0, i + j + 2.0) * det;
                }
            }
            det = InverseDeterm(n,values);
            double temp;

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < i; j++)
                {
                    temp = values3[i, j];
                    values3[i, j] = values3[j, i];
                    values3[j, i] = temp;
                }
            }
            return values3;
        }
    }
}
