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
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }

       
        public void getData()
        {
            // Lấy dữ liệu, hiển thị lên GridView
            string query = "EXEC CapNhatTenNVVaoHoaDon; EXEC TongHoaDon_TienCoc_CanThanhToan; SELECT * FROM HoaDon";
            DataSet ds = new DataSet();
            KetNoi cn = new KetNoi();
            ds = cn.laydulieu(query, "HoaDon");

            dgvHoaDon.DataSource = ds.Tables["HoaDon"];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string mhd = txtMaHoaDon.Text;
            string ngm = txtNgayMuaHang.Text;
            string ngg = txtNgayGiaoHang.Text;
            string mnv = txtMaNhanVien.Text;
            string tnv = txtTenNhanVien.Text;
            string tkh = txtTenKhachHang.Text;
            string sdt = txtSDT.Text;
            string dc = txtDiaChi.Text;
            string ship = txtPhiGiaoHang.Text;
            string tong = txtTongHoaDon.Text;
            string coc = txtCoc.Text;
            string thanhtoan = txtCanThanhToan.Text;

            string query = "INSERT INTO HoaDon (mahoadon, ngaymuahang, ngaygiaohang, manhanvien, tenkhachhang, sdtkh, diachikh, phigiaohang) VALUES ('" + mhd + "', '" + ngm + "', '" + ngg + "', '" + mnv + "', N'" + tkh + "', '" + sdt + "', N'" + dc + "', '" + ship + "')";
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

        private void button3_Click(object sender, EventArgs e)
        {
            string mhd = txtMaHoaDon.Text;
            string ngm = txtNgayMuaHang.Text;
            string ngg = txtNgayGiaoHang.Text;
            string mnv = txtMaNhanVien.Text;
            string tnv = txtTenNhanVien.Text;
            string tkh = txtTenKhachHang.Text;
            string sdt = txtSDT.Text;
            string dc = txtDiaChi.Text;
            string ship = txtPhiGiaoHang.Text;
            string tong = txtTongHoaDon.Text;
            string coc = txtCoc.Text;
            string thanhtoan = txtCanThanhToan.Text;

            string query = "UPDATE HoaDon SET ngaymuahang = '" + ngm + "', ngaygiaohang = '" + ngg + "', manhanvien = '" + mnv + "', tenkhachhang = N'" + tkh + "', sdtkh = '" + sdt + "', diachikh = N'" + dc + "', phigiaohang = '" + ship + "' WHERE mahoadon like N'%" + mhd + "%'";
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

        private void HoaDon_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mhd = txtMaHoaDon.Text;
            string query = "DELETE HoaDon WHERE mahoadon = '" + mhd + "'";
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
            string mhd = txtMaHoaDon.Text;
            string query = "EXEC TongHoaDon_TienCoc_CanThanhToann; SELECT * FROM HoaDon WHERE mahoadon like N'%" + mhd + "%'";
            DataSet ds = new DataSet();
            KetNoi cn = new KetNoi();
            ds = cn.laydulieu(query, "HoaDon");

            dgvHoaDon.DataSource = ds.Tables["HoaDon"];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wk = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet sht = null;
            sht = wk.Sheets["Sheet1"];
            sht = wk.ActiveSheet;
            app.Visible = true;
            sht.Cells[1, 1] = "HOÁ ĐƠN BÁN HÀNG";
            sht.Cells[2, 2] = "Mã hoá đơn";
            sht.Cells[2, 3] = "Ngày mua hàng";
            sht.Cells[2, 4] = "Ngày giao hàng";
            sht.Cells[2, 5] = "Mã nhân viên";
            sht.Cells[2, 6] = "Tên nhân viên";
            sht.Cells[2, 7] = "Tên khách hàng";
            sht.Cells[2, 8] = "Số điện thoại khách hàng";
            sht.Cells[2, 9] = "Địa chỉ khách hàng";
            sht.Cells[2, 10] = "Phí giao hàng";
            sht.Cells[2, 11] = "Tổng hoá đơn(Đã tính phí giao hàng)";
            sht.Cells[2, 12] = "Tiền cọc";
            sht.Cells[2, 13] = "Cần thanh toán(Đã trừ cọc)";


            for (int i = 0; i < dgvHoaDon.RowCount - 1; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    sht.Cells[i + 3, 1] = i + 1;
                    sht.Cells[i + 3, j + 2] = dgvHoaDon.Rows[i].Cells[j].Value;
                }
            }
            
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                // Đọc dữ liệu
                txtMaHoaDon.Text = dgvHoaDon.Rows[row].Cells["mahoadon"].Value.ToString();
                txtNgayMuaHang.Text = dgvHoaDon.Rows[row].Cells["ngaymuahang"].Value.ToString();
                txtNgayGiaoHang.Text = dgvHoaDon.Rows[row].Cells["ngaygiaohang"].Value.ToString();
                txtMaNhanVien.Text = dgvHoaDon.Rows[row].Cells["manhanvien"].Value.ToString();
                txtTenNhanVien.Text = dgvHoaDon.Rows[row].Cells["tennhanvien"].Value.ToString();
                txtTenKhachHang.Text = dgvHoaDon.Rows[row].Cells["tenkhachhang"].Value.ToString();
                txtSDT.Text = dgvHoaDon.Rows[row].Cells["sdtkh"].Value.ToString();
                txtDiaChi.Text = dgvHoaDon.Rows[row].Cells["diachikh"].Value.ToString();
                txtPhiGiaoHang.Text = dgvHoaDon.Rows[row].Cells["phigiaohang"].Value.ToString();
                txtTongHoaDon.Text = dgvHoaDon.Rows[row].Cells["tonghoadon"].Value.ToString();
                txtCoc.Text = dgvHoaDon.Rows[row].Cells["tiencoc"].Value.ToString();
                txtCanThanhToan.Text = dgvHoaDon.Rows[row].Cells["canthanhtoan"].Value.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CTHoaDon formchithoadon = new CTHoaDon();
            formchithoadon.Show();
        }
    }
}
