using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Kursach2_WF_
{
    public partial class Form2 : Form
    {
        int opt;
        string number;
        double[,] values;
        double[,] values2;
        double[,] svalues;
        public Form2(int opt, double[,] values, double[,] values2, double[,] svalues, string number)
        {
            InitializeComponent();
            this.opt = opt;
            this.number = number;
            this.values = values;
            this.values2 = values2;
            this.svalues = svalues;
        }
        public class files
        {
            public int option { get; set; }
            public string number { get; set; }
            public double[,] firstm { get; set; }
            public double[,] secondm { get; set; }
            public double[,] answer { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.Filter = "Json Files (*.json)|*.json";
            SaveFileDialog1.FileName = "default";
            SaveFileDialog1.DefaultExt = "json";
            SaveFileDialog1.CheckFileExists = true;

            var save = new files();
            save.option = opt;
            save.number = number;

            if (values != null)
            {
                save.firstm = new double[values.Length / values.Rank, values.Rank];
                for (int i = 0; i < values.Length / values.Rank; i++)
                    for (int j = 0; j < values.Rank; j++)
                    {
                        save.firstm[i, j] = values[i, j];
                    }
            }
            if (svalues != null)
            {
                save.secondm = new double[svalues.Length / svalues.Rank, svalues.Rank];
                for (int i = 0; i < svalues.Length / svalues.Rank; i++)
                    for (int j = 0; j < svalues.Rank; j++)
                    {
                        save.secondm[i, j] = svalues[i, j];
                    }
            }
            if (values2 != null)
            {
                save.answer = new double[values2.Length / values2.Rank, values2.Rank];
                for (int i = 0; i < values2.Length / values2.Rank; i++)
                    for (int j = 0; j < values2.Rank; j++)
                    {
                        save.answer[i, j] = values2[i, j];
                    }
            }

            SaveFileDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.Filter = "Json Files (*.json)|*.json";
            SaveFileDialog1.FileName = "default";
            SaveFileDialog1.DefaultExt = "json";
            SaveFileDialog1.CheckFileExists = true;

            var save = new files();
            save.option = opt;
            save.number = number;

            if (values != null)
            {
                save.firstm = new double[values.Length / values.Rank, values.Rank];
                for (int i = 0; i < values.Length / values.Rank; i++)
                    for (int j = 0; j < values.Rank; j++)
                    {
                        save.firstm[i, j] = values[i, j];
                    }
            }
            if (svalues != null)
            {
                save.secondm = new double[svalues.Length / svalues.Rank, svalues.Rank];
                for (int i = 0; i < svalues.Length / svalues.Rank; i++)
                    for (int j = 0; j < svalues.Rank; j++)
                    {
                        save.secondm[i, j] = svalues[i, j];
                    }
            }
            SaveFileDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.Filter = "Json Files (*.json)|*.json";
            SaveFileDialog1.FileName = "default";
            SaveFileDialog1.DefaultExt = "json";
            SaveFileDialog1.CheckFileExists = true;

            var save = new files();
            save.option = opt;

            if (values2 != null)
            {
                save.answer = new double[values2.Length / values2.Rank, values2.Rank];
                for (int i = 0; i < values2.Length / values2.Rank; i++)
                    for (int j = 0; j < values2.Rank; j++)
                    {
                        save.answer[i, j] = values2[i, j];
                    }
            }
            SaveFileDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.ShowDialog();
        }
    }
}
