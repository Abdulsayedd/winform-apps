using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WinFormsApp13
{
    public partial class Form2 : Form
    {
        string path,line,bpath,cat,all="";
        bool av;
        int idx = 0,PicNo,l,r;
        string[] temp;
        public Form2()
        {
            InitializeComponent();
            path = @"Material\books.txt";
        }


        private void Form2_Load(object sender, EventArgs e)
        {
          
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radiobuttonchange();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radiobuttonchange();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            radiobuttonchange();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            radiobuttonchange();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(!av)
            {
                MessageBox.Show("Book is not available!");
                return;
            }
            idx--;
            StreamReader SRU = new StreamReader(path);
            string[] books = new string[14];
            for (int i = 0; i <=13; i++)
            {
                books[i] = SRU.ReadLine();
            }
            SRU.Close();
            int mm = 0;
            for (int i = 1; i <=9; i++)
            {
                books[idx] = books[idx].Remove(books[idx].Length - 1);
            }
            books[idx] +="Booked";
            string alll = "";
            for(int i = 0; i<=13;i++)
            {
                alll += books[i]+'\n';
            }
            File.WriteAllText(path, String.Empty);
            StreamWriter SW = new StreamWriter(path, true);
            SW.WriteLine(alll);
            SW.Close();
            idx++;
            MessageBox.Show("Booked!");
            press();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radiobuttoncheck();
            if (idx == r) return;
            idx++;
            press();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            radiobuttoncheck();
            if (idx == l)return;
            idx--;
            press();
        }
        public void chngpic()
        {
            pictureBox1.Image = Image.FromFile(@"E:\CODES\C#\WinFormsApp13\WinFormsApp13\bin\Debug\netcoreapp3.1\Material\"+bpath);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public void press()
        {
            all = "";
            StreamReader SRU = new StreamReader(path);
            bool valid = false;
            int c = 1;
            while (c!=idx+1)
            {
                line = SRU.ReadLine();
                temp = line.Split(',');
                PicNo = int.Parse(temp[0]);
                bpath = temp[1];
                cat = temp[2];
                av = temp[3] == "Available";
                c++;
            }
            SRU.Close();
            if (av) label1.Text = "Available";
            else label1.Text = "Booked";
            chngpic();
        }
        public void radiobuttoncheck()
        {
            if (radioButton1.Checked)
            {
                l = 1; r = 4;
            }
            else if (radioButton2.Checked)
            {
                l = 5; r = 7;
            }
            else if (radioButton3.Checked)
            {
                l = 8; r = 10;
            }
            else if (radioButton4.Checked)
            {
                l = 11; r = 14;
            }
        }
        public void radiobuttonchange()
        {
            if (radioButton1.Checked)
            {
                idx = 1;
            }
            else if (radioButton2.Checked)
            {
                idx = 5;
            }
            else if (radioButton3.Checked)
            {
                idx = 8;
            }
            else if (radioButton4.Checked)
            {
                idx = 11;
            }
            press();
        }
    }
}
