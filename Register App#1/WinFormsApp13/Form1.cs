using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormsApp13
{
    public partial class Form1 : Form
    {
        string name, password, path;

        private void label3_Click(object sender, EventArgs e)
        {
            var s = new Form3();
            s.Show();
            this.Hide();
        }

        public Form1()
        {
            InitializeComponent();
            path = @"Material\user.txt";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            password = textBox2.Text;
            StreamReader SRU = new StreamReader(path);
            bool valid = false;
            while (!SRU.EndOfStream)
            {

                string line = SRU.ReadLine();
                string[] temp = line.Split(',');
                if (name == temp[2] && password == temp[3])
                {
                    valid = true;
                    break;
                }

            }
            SRU.Close();
            if(valid)
            {
                var s = new Form2();
                s.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Email/Password");
            }

        }
    }
}
