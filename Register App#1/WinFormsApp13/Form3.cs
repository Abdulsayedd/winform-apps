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
    public partial class Form3 : Form
    {
        string fileName;
        string path = @"E:\CODES\C#\WinFormsApp13\WinFormsApp13\bin\Debug\netcoreapp3.1\Material\user.txt";
        bool cc = false;
        string[] arr = new string[100];
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//Register
        {
            if(!checkBox1.Checked)
            {
                MessageBox.Show("Terms are not accepted!");
                return; 
            }
            if (textBox6.Text != textBox7.Text)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                MessageBox.Show("Wrong Password!");
                return;
            }
            if(!cc)
            {
                MessageBox.Show("Choose Picture!!");
                return;
            }
            int linesno = countlines();
            arr[0] = (linesno + 1).ToString();
            arr[1] = textBox1.Text + " " +textBox2.Text;
            arr[2] = textBox4.Text;
            arr[3] = textBox6.Text;
            if (radioButton1.Checked) arr[5] = "Male";
            else if (radioButton2.Checked) arr[5] = "Female";
            else if (radioButton3.Checked) arr[5] = "Other"; // Mentally ill 
            arr[6] = comboBox1.Text;
            arr[7] = textBox5.Text;
            arr[8] = textBox3.Text;
            arr[9] = "yes";
            string add = "\n";
            for(int i = 0; i < 9; i++)
            {
                add += arr[i]+',';
            }
            add += arr[9];
            StreamWriter SW = new StreamWriter(path, true);
            SW.Write(add);
            SW.Close();
            MessageBox.Show("Registered!");
            var s = new Form1();
            s.Show();
            this.Hide();
        }
        public int countlines()
        {
            int m = 0;
            StreamReader SRU = new StreamReader(path);
            while(!SRU.EndOfStream)
            {
                SRU.ReadLine();
                m++;
            }
            SRU.Close();
            return m;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cc = true;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            fileName = dlg.FileName;
            pictureBox1.Image = Image.FromFile(fileName);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            arr[4] = fileName;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
