using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mobile
{
    public partial class SanPham : Form
    {
        public SanPham()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            menu formmenu = new menu();
            formmenu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msp = txtMaSanPham.Text;
            string tsp = txtTenSanPham.Text;
            string lsp = txtLoai.Text;
            string tonkho = txtSoTonKho.Text;
            string gianhap = txtGiaNhap.Text;
            string giaban = txtGiaBan.Text;

            string query = "INSERT INTO SanPham (masanpham, tensanpham, loai, sotonkho, gianhap, giaban) VALUES ('" + msp + "', N'" + tsp + "', N'" + lsp + "', '" + tonkho + "', '" + gianhap + "', '" + giaban + "')";
            KetNoi cn = new KetNoi();
            bool kt = cn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Thêm mới thành công!");
                getData();
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại!");
            }
        }
        public void getData()
        {
            // Lấy dữ liệu, hiển thị lên GridView
            string query = "EXEC Cap_Nhat_Hang_Ton_Kho; SELECT * FROM SanPham";
            DataSet ds = new DataSet();
            KetNoi cn = new KetNoi();
            ds = cn.laydulieu(query, "SanPham");

            dgvSanPham.DataSource = ds.Tables["SanPham"];
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                // Đọc dữ liệu
                txtMaSanPham.Text = dgvSanPham.Rows[row].Cells["masanpham"].Value.ToString();
                txtTenSanPham.Text = dgvSanPham.Rows[row].Cells["tensanpham"].Value.ToString();
                txtLoai.Text = dgvSanPham.Rows[row].Cells["loai"].Value.ToString();
                txtSoTonKho.Text = dgvSanPham.Rows[row].Cells["sotonkho"].Value.ToString();
                txtGiaNhap.Text = dgvSanPham.Rows[row].Cells["gianhap"].Value.ToString();
                txtGiaBan.Text = dgvSanPham.Rows[row].Cells["giaban"].Value.ToString();
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            string msp = txtMaSanPham.Text;
            string tsp = txtTenSanPham.Text;
            string lsp = txtLoai.Text;
            string tonkho = txtSoTonKho.Text;
            string gianhap = txtGiaNhap.Text;
            string giaban = txtGiaBan.Text;

            string query = "UPDATE SanPham SET tensanpham = N'" + tsp + "', loai = N'" + lsp + "', sotonkho = '" + tonkho + "', gianhap = '" + gianhap + "', giaban = '" + giaban + "' WHERE masanpham like N'%" + msp + "%'";
            KetNoi kn = new KetNoi();
            bool kt = kn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Sửa thành công!");
                getData();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string msp = txtMaSanPham.Text;
            string query = "DELETE SanPham WHERE masanpham = '" + msp + "'";
            KetNoi kn = new KetNoi();
            bool kt = kn.thucthi(query);
            if (kt == true)
            {
                MessageBox.Show("Xóa thành công!");
                getData();

            }
            else
            {
                MessageBox.Show("Xóa thất bại!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string msp = txtMaSanPham.Text;
            string query = "SELECT * FROM SanPham WHERE masanpham like N'%" + msp + "%'";
            DataSet ds = new DataSet();
            KetNoi cn = new KetNoi();
            ds = cn.laydulieu(query, "SanPham");

            dgvSanPham.DataSource = ds.Tables["SanPham"];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CTHoaDon formcthoadon = new CTHoaDon();
            formcthoadon.Show();
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            getData();
        }
    }
}
