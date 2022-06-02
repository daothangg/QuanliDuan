using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace mobile
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            menu formmenu = new menu();
            formmenu.Show();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string tk = txttaikhoan.Text;
            string mk = txtmatkhau.Text;
            string query = @"SELECT COUNT (*) AS SoLuong   FROM TaiKhoan WHERE username ='" + tk + "' and pass='" + mk + "'";
            KetNoi cn = new KetNoi();
            DataSet ds = cn.laydulieu(query, "TaiKhoan");
            if ((int)ds.Tables["TaiKhoan"].Rows[0].ItemArray[0] == 1)
            {
                MessageBox.Show("Đăng Nhập Thành công");
                menu frm = new menu();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("đăng nhập sai");
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
