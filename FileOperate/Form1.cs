using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileOperate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = @"C:\Users\Administrator.2013-20140803BK\Desktop\kindle推送测试.txt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = File.ReadAllText(textBox1.Text, Encoding.Default);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(textBox1.Text, textBox2.Text, Encoding.Default);
                MessageBox.Show("保存成功");
            }
            catch (Exception)
            {
                MessageBox.Show("保存失败");
                throw;
            }
        }
    }
}
