using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NguyenThanhThuc_2121110112_QLSV
{
    public partial class Form1 : Form
    {
        private const string Username = "thanhthuc";
        private const string Password = "123";
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String userName = textBox1.Text;
            String password = textBox2.Text;
            if (userName == Username && password == Password)
            {
                MessageBox.Show("Đăng nhập thành công");
                Form2 form2 = new Form2();
                form2.ShowDialog(this);
                this.Hide();
            }
            else
            {
                MessageBox.Show("tên tài khoản hoặc mật khẩu k đúng vui lòng nhập lại");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
