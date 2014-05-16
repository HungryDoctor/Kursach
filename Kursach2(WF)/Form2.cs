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
using System.IO;

namespace Kursach2_WF_
{
    public partial class Form2 : Form
    {
        private int opt;
        private string number;
        private string[,] values;
        private string[,] svalues;
        private string[,] values2;
        private bool aim;
        private bool loadall;

        public Form2(int opt, string[,] values, string[,] values2, string[,] svalues, string number)
        {
            InitializeComponent();
            this.opt = opt;
            this.number = number;
            this.values = values;
            this.values2 = values2;
            this.svalues = svalues;

            if (values2 == null)
            {
                button3.Enabled = false;
            }
        }
        public class files
        {
            public int option { get; set; }
            public string number { get; set; }
            public string[,] firstm { get; set; }
            public string[,] secondm { get; set; }
            public string[,] answer { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.Filter = "Json Files (*.json)|*.json";
            SaveFileDialog1.FileName = "default";
            SaveFileDialog1.DefaultExt = "json";

            var save = new files();
            save.option = opt;
            save.number = number;
            save.firstm = values;
            save.secondm = svalues;
            save.answer = values2;

            string output = JsonConvert.SerializeObject(save, Formatting.Indented);
            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(SaveFileDialog1.FileName))
                        sw.WriteLine(output);
                }
                catch
                {
                    MessageBox.Show("Не удалось записать файл.\n Возможно он открыт в другой программе");
                }
            }
            aim = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.Filter = "Json Files (*.json)|*.json";
            SaveFileDialog1.FileName = "default";
            SaveFileDialog1.DefaultExt = "json";

            var save = new files();
            save.option = opt;
            save.number = number;
            save.firstm = values;
            save.secondm = svalues;

            string output = JsonConvert.SerializeObject(save, Formatting.Indented);
            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(SaveFileDialog1.FileName))
                        sw.WriteLine(output);
                }
                catch
                {
                    MessageBox.Show("Не удалось записать файл.\n Возможно он открыт в другой программе");
                }
            }
            aim = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.Filter = "Json Files (*.json)|*.json";
            SaveFileDialog1.FileName = "default";
            SaveFileDialog1.DefaultExt = "json";

            var save = new files();
            save.option = opt;
            save.answer = values2;

            string output = JsonConvert.SerializeObject(save, Formatting.Indented);
            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(SaveFileDialog1.FileName))
                        sw.WriteLine(output);
                }
                catch
                {
                    MessageBox.Show("Не удалось записать файл.\n Возможно он открыт в другой программе");
                }
            }
            aim = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "Json Files (*.json)|*.json";
            OpenFileDialog1.FileName = "default.json";
            OpenFileDialog1.DefaultExt = "json";

            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    files open = JsonConvert.DeserializeObject<files>(File.ReadAllText(OpenFileDialog1.FileName));

                    opt = open.option;
                    number = open.number;
                    values = open.firstm;
                    svalues = open.secondm;
                    values2 = open.answer;
                    aim = true;
                    loadall = true;
                }
                catch
                {
                    MessageBox.Show("Не удалось считать файл " + OpenFileDialog1.FileName + "\nВозможно файл поврежден");

                    aim = false;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "Json Files (*.json)|*.json";
            OpenFileDialog1.FileName = "default.json";
            OpenFileDialog1.DefaultExt = "json";

            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    files open = JsonConvert.DeserializeObject<files>(File.ReadAllText(OpenFileDialog1.FileName));
                    opt = open.option;
                    number = open.number;
                    values = open.firstm;
                    svalues = open.secondm;
                    aim = true;
                    loadall = false;
                }
                catch
                {
                    MessageBox.Show("Не удалось считать файл " + OpenFileDialog1.FileName + "\nВозможно файл поврежден");

                    aim = false;
                }
            }
        }
        public int retopt
        {
            get { return opt; }
        }
        public string retnumber
        {
            get { return number; }
        }
        public string[,] retvalues
        {
            get { return values; }
        }
        public string[,] retsvalues
        {
            get { return svalues; }
        }
        public string[,] retvalues2
        {
            get { return values2; }
        }
        public bool retaim
        {
            get { return aim; }
        }
        public bool retloadall
        {
            get { return loadall; }
        }
    }
}
