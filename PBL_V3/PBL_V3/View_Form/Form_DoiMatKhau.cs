using PBL_V3.BLL;
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
    public partial class Form_DoiMatKhau : Form
    {
        private string User;
        public delegate void changeInfo(String name);
        private changeInfo d;

        public changeInfo D { get => d; set => d = value; }
        public Form_DoiMatKhau(string user)
        {
            InitializeComponent();
            User = user;
            SetGUI();
        }

        private void Tai_khoan_Load(object sender, EventArgs e)
        {

        }
        private void SetGUI()
        {
            NHAN_VIEN nv = BLL.BLL_NhanVien.Instance.Staff_ID_BLL(User);
            txtChucVu.Text = nv.Chuc_Vu;
            txtUserName.Text = nv.Ma_Nhan_Vien;
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_DoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool check = BLL_TaiKhoan.Instance.BLL_DangNhap(txtUserName.Text, txtPassWord.Text, 0);
            if (check == true)
            {
                if (txtNewPass.Text != null && txtNewPass.Text == txtRePass.Text)
                {
                    BLL_NhanVien.Instance.ChangeInf_BLL(txtUserName.Text, txtChucVu.Text, txtNewPass.Text);
                    MessageBox.Show("Đổi mật khẩu thành công.");
                    d(FormAdmin.subString(txtChucVu.Text));
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Mật khẩu không khớp. Vui lòng nhập lại!",
                     "Sai thông tin đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("Mã nhân viên hoặc mật khẩu không đúng. Vui lòng nhập lại!",
                     "Sai thông tin đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
