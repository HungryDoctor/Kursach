using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            label3.Visible = false;
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
            label3.Visible = false;
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
            label2.Visible = false;
            label3.Visible = true;
            label3.Text = "X";
            textBox3.Visible = true;
            label4.Visible = false;
            dataGridView2.Visible = false;
            opt = 3;

            label3.Location = new Point(this.label3.Location.X, dataGridView1.Location.X - label3.Size.Width - 3);
            label3.Location = new Point(this.label3.Location.Y, dataGridView1.Location.Y + (dataGridView1.Size.Height / 2) - 7);
            textBox3.Location = new Point(this.textBox3.Location.X, dataGridView1.Location.X - textBox3.Size.Width - label3.Size.Width - 6);
            textBox3.Location = new Point(this.textBox3.Location.Y, dataGridView1.Location.Y + (dataGridView1.Size.Height / 2) - 10);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = true;
            label3.Text = "/";
            textBox3.Visible = true;
            label4.Visible = false;
            dataGridView2.Visible = false;
            opt = 4;

            label3.Location = new Point(this.label3.Location.X, dataGridView1.Location.X - label3.Size.Width - 3);
            label3.Location = new Point(this.label3.Location.Y, dataGridView1.Location.Y + (dataGridView1.Size.Height / 2) - 7);
            textBox3.Location = new Point(this.textBox3.Location.X, dataGridView1.Location.X - textBox3.Size.Width - label3.Size.Width - 6);
            textBox3.Location = new Point(this.textBox3.Location.Y, dataGridView1.Location.Y + (dataGridView1.Size.Height / 2) - 10);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
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
                        dataGridView1.Rows[i].Cells[j].Value = 1 + i;
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
                radioButton4.Enabled = true;
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
                                dataGridView2.Rows[i].Cells[j].Value = Convert.ToDouble(textBox3.Text.ToString()) / values[i, j];
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
                        MessageBox.Show("Введите число на которое делится матрица");
                    }
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


    }
}
