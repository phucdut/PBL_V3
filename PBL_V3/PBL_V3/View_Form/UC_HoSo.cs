using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL_V3.View_Form
{
    public partial class UC_HoSo : UserControl
    {
        private string User;
        public UC_HoSo(string Username)
        {
            InitializeComponent();
            this.Text = "Hồ sơ";
            User = Username;
            SetGUI();
        }
        void SetGUI()
        {

            NHAN_VIEN nv = BLL.BLL_NhanVien.Instance.Staff_ID_BLL(User);
            lbPhanQuyen.Text = nv.Ten_Nhan_Vien;
            txtDisPlayName.Text = nv.Ten_Nhan_Vien;
            txtMaNhanVien.Text = nv.Ma_Nhan_Vien;
            txtDiaChi.Text = nv.Dia_Chi;
            txtChucVu.Text = nv.Chuc_Vu;
            txtGioiTinh.Text = nv.Gioi_Tinh;
            txtSDT.Text = nv.SDT;
            txtTaiKhoan.Text = nv.Ten_Nhan_Vien;
            txtpass.Text = nv.Mat_Khau;
        }
        void changeInfo(String info)
        {
            lbPhanQuyen.Text = info;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_DoiMatKhau f = new Form_DoiMatKhau(User);
            f.D = changeInfo;
            f.ShowDialog();
        }
    }
}
