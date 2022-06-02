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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void nhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien formNhanVien = new NhanVien();
            formNhanVien.Show();
            this.Hide();
        }

        private void thốngKêThuCHiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeThuChi frm = new ThongKeThuChi();
            frm.Show();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SanPham formSanPham = new SanPham();
            formSanPham.Show();
            this.Hide();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDon formHoaDon = new HoaDon();
            formHoaDon.Show();
            this.Hide();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login formlogin = new login();
            formlogin.Show();
            this.Hide();
        }

        private void báoCáoThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoThongKe frm = new BaoCaoThongKe();
            frm.Show();
        }

        private void thốngKêNhậpXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeNhapXuat frm = new ThongKeNhapXuat();
            frm.Show();
        }
    }
}
