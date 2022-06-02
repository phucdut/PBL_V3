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

namespace PBL_V3
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }
        int i;
        private void hienmk_Click(object sender, EventArgs e)
        {
            i++;
            if (i % 2 == 0)
            {
                txtPass.UseSystemPasswordChar = true;
            }
            else
            {
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void butOK_Click(object sender, EventArgs e)
        {

            if (txtPass.Text != "" && txtName.Text != "")
            {
                string username = txtName.Text;
                string password = txtPass.Text;
                if (BLL.BLL_TaiKhoan.Instance.BLL_DangNhap(username, password, 1))
                {
                    FormBanHang td = new FormBanHang(BLL_NhanVien.Instance.getID_BLL(username));
                    this.Hide();
                    td.ShowDialog();
                    this.Show();
                    //NHAN_VIEN nv = BLL.BLL_NhanVien.Instance.Staff_ID_BLL(username);
                    //if (nv.Chuc_Vu == "Quản lý")
                    //{
                    //    FormAdmin f = new FormAdmin(BLL_NhanVien.Instance.getID_BLL(username));
                    //    this.Hide();
                    //    f.ShowDialog();
                    //    this.Show();
                    //}
                    //if (nv.Chuc_Vu == "Nhân Viên")
                    //{
                    //    FormBanHang td = new FormBanHang(BLL_NhanVien.Instance.getID_BLL(username));
                    //    this.Hide();
                    //    td.ShowDialog();
                    //    this.Show();
                    //}
                }
                else
                {
                    MessageBox.Show("Mã nhân viên hoặc mật khẩu không đúng. Vui lòng nhập lại!",
                    "Sai thông tin đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!",
                     "Sai thông tin đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
        }

        private void FormDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dlr == DialogResult.No) e.Cancel = true;
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
