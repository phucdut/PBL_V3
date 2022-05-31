using PBL_V3.BLL;
using PBL_V3.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL_V3.View_Form
{
    public partial class UC_NhanVien : UserControl
    {
        public delegate void changeInfo(String name);
        private string User;
        private changeInfo d;
        public changeInfo D { get => d; set => d = value; }
        public UC_NhanVien(string Username)
        {
            InitializeComponent();
            User = Username;
            this.Text = "Nhân viên";
            LoadStaff(-1, 1);
            // dtgvNV.DataSource = BLLNhanVien.Instance.getStaff();
            setCBB();
        }
        public void LoadStaff(int m, int n)
        {
            dtgvNV.Rows.Clear();
            dtgvNV.Columns.Clear();
            //n
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.DataPropertyName = "Mã NV";
            dtgvNV.Columns.Add(col1);



            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.DataPropertyName = "Tên NV";
            dtgvNV.Columns.Add(col2);



            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.DataPropertyName = "Giới Tính";
            dtgvNV.Columns.Add(col3);


            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.DataPropertyName = "Chức vụ";
            dtgvNV.Columns.Add(col4);


            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.DataPropertyName = "PhoneNumber";
            dtgvNV.Columns.Add(col5);



            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col6.DataPropertyName = "Địa chỉ";
            dtgvNV.Columns.Add(col6);


            //DataGridViewTextBoxColumn col7 = new DataGridViewTextBoxColumn();
            //col7.DataPropertyName = "Tình trạng";
            //dtgvNV.Columns.Add(col7);


            //dtgvNV.Columns.Add(col1);
            //dtgvNV.Columns.Add(col2);
            //dtgvNV.Columns.Add(col3);
            //dtgvNV.Columns.Add(col4);
            //dtgvNV.Columns.Add(col5);
            //dtgvNV.Columns.Add(col6);
            //dtgvNV.Columns.Add(col7);


            List<NHAN_VIEN> staffList = BLL.BLL_NhanVien.Instance.getStaff();
            if (staffList.Count > 0)
            {
                for (int i = 0; i < staffList.Count; i++)
                {
                    NHAN_VIEN nv = null;
                    if (m < staffList[i].Tinh_Trang && staffList[i].Tinh_Trang < n)
                    {
                        nv = BLL_NhanVien.Instance.Staff_ID_BLL(staffList[i].Ma_Nhan_Vien);
                        DataGridViewRow row1 = new DataGridViewRow();
                        row1.CreateCells(dtgvNV);
                        row1.Cells[0].Value = staffList[i].Ma_Nhan_Vien;
                        row1.Cells[1].Value = staffList[i].Ten_Nhan_Vien;
                        row1.Cells[2].Value = staffList[i].Gioi_Tinh;
                        row1.Cells[3].Value = staffList[i].Chuc_Vu;
                        row1.Cells[4].Value = staffList[i].SDT;
                        row1.Cells[5].Value = staffList[i].Dia_Chi;
                        dtgvNV.Rows.Add(row1);
                    }
                }
            }
        }
        private void setCBB()
        {
            var list = new List<CBBItem>();
            list.Add(new CBBItem() { Text = "Đang Làm Việc" });
            list.Add(new CBBItem() { Text = "Đã Thôi Việc" });
            list.Add(new CBBItem() { Text = "Tất Cả" });
            cbbTT.DataSource = list;
        }
        internal static bool isDigit(string v)
        {
            var isNumeric = !string.IsNullOrEmpty(v) && v.All(Char.IsDigit);
            return isNumeric;
        }
        private Boolean CheckSDT(String PhoneNumber)
        {
            int k = 0;
            List<NHAN_VIEN> list = BLL.BLL_NhanVien.Instance.getStaff();
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].SDT == PhoneNumber)
                    {
                        k++;
                    }
                }
                if (k == 0) return true;
                else
                {
                    return false;
                }
            }
            else return false;
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            if (txtMNV.Text != "" && txtTNV.Text != "" && isDigit(txtSDT.Text) && txtSDT.Text.Length < 11)
            {
                String MaNV = txtMNV.Text;
                String TenNV = txtTNV.Text;
                String PhoneNumber = txtSDT.Text;
                String GioiTinh = txtGioiTinh.Text;
                String ChucVu = txtChucVu.Text;
                String DiaChi = txtDiaChi.Text;
                Boolean phanquyen;
                phanquyen = false;
                NHAN_VIEN nv = new NHAN_VIEN
                {
                    Ma_Nhan_Vien = MaNV,
                    Ten_Nhan_Vien = TenNV,
                    Gioi_Tinh = GioiTinh,
                    Chuc_Vu = ChucVu,
                    Phan_Quyen = phanquyen,
                    Dia_Chi = DiaChi,
                    SDT = PhoneNumber,
                    Mat_Khau = passWord("1"),
                    Tinh_Trang = 0
                };
                if (BLL_NhanVien.Instance.AddStaff_BLL(nv))
                {
                    MessageBox.Show("Thành Công");
                }
                else { MessageBox.Show("Lỗi"); }
                LoadStaff(-1, 1);
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Lại");
            }
        }
        public static String passWord(String password)
        {
            byte[] tempt = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(tempt);
            string hashpass = "";
            foreach (byte item in hashData)
            {
                hashpass += item;
            }
            return hashpass;
        }
        private void dtgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvNV.Rows[e.RowIndex];
                if (row.Cells[1].Value != null)
                {
                    txtMNV.Text = row.Cells[0].Value.ToString();
                    txtTNV.Text = row.Cells[1].Value.ToString();
                    txtGioiTinh.Text = row.Cells[2].Value.ToString();
                    txtChucVu.Text = row.Cells[3].Value.ToString();
                    txtSDT.Text = row.Cells[4].Value.ToString();
                    txtDiaChi.Text = row.Cells[5].Value.ToString();
                    
                }
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            NHAN_VIEN nv = new NHAN_VIEN();
            nv.Ten_Nhan_Vien = txtTNV.Text;
            nv.Gioi_Tinh = txtGioiTinh.Text;
            nv.Dia_Chi = txtDiaChi.Text;
            nv.Chuc_Vu = txtChucVu.Text;
            if (isDigit(txtSDT.Text) && txtSDT.Text.Length < 11)
            {
                nv.SDT = txtSDT.Text;
            }
            else
            {
                MessageBox.Show("Số Điện Thoại Không hợp lệ");
                return;
            }
            nv.Phan_Quyen = false;
            nv.Tinh_Trang = 0;
            if (dtgvNV.SelectedCells.Count > 0)
            {
                string id = Convert.ToString(dtgvNV.SelectedRows[0].Cells[0].Value);
                NHAN_VIEN before = BLL.BLL_NhanVien.Instance.Staff_ID_BLL(id);
                nv.Ma_Nhan_Vien = before.Ma_Nhan_Vien;
                nv.Mat_Khau = before.Mat_Khau;
                if (txtSDT.Text == before.SDT || CheckSDT(txtSDT.Text))
                {
                    if (BLL.BLL_NhanVien.Instance.EditStaff_BLL(nv))
                    {
                        MessageBox.Show("Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi");
                    }
                }
                else return;
            }
            if (Convert.ToString(dtgvNV.SelectedRows[0].Cells[0].Value) == User)
            {
                d(FormAdmin.subString(txtTNV.Text));
            }
            LoadStaff(-1, 1);
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            if (dtgvNV.SelectedCells.Count > 0)
            {
                string id = Convert.ToString(dtgvNV.SelectedRows[0].Cells[0].Value);
                if (id != User)
                {
                    NHAN_VIEN nv = BLL.BLL_NhanVien.Instance.Staff_ID_BLL(id);
                    NHAN_VIEN old = nv;
                    old.Tinh_Trang = -1;
                    if (BLL.BLL_NhanVien.Instance.EditStaff_BLL(old))
                    {
                        MessageBox.Show("Đã Xóa");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi!");
                    }
                }
                else
                {
                    MessageBox.Show("Không thể xóa!");
                }
            }
            LoadStaff(-1, 1);
        }

        private void ButReset_Click(object sender, EventArgs e)
        {
            if (dtgvNV.SelectedRows.Count > 0)
            {
                string id = Convert.ToString(dtgvNV.SelectedRows[0].Cells[0].Value);
                NHAN_VIEN nv = BLL_NhanVien.Instance.Staff_ID_BLL(id);
                bool check = BLL_TaiKhoan.Instance.BLL_DangNhap(nv.Ma_Nhan_Vien, "1", 1);
                if (check == true)
                    MessageBox.Show("Đã reset");
                else MessageBox.Show("Loi");
            }
            else
            {
                MessageBox.Show("Vui long cho nhan vien");
            }
        }

        private void cbbTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            String modeview = cbbTT.SelectedItem.ToString();
            if (modeview == "Đang Làm Việc")
            {
                LoadStaff(-1, 1);
            }
            if (modeview == "Đã Thôi Việc")
            {
                LoadStaff(-2, 0);
            }
            if (modeview == "Tất Cả")
            {
                LoadStaff(-2, 1);
            }
        }
    }
}
