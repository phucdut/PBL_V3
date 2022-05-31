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
    public partial class UC_KhachHang : UserControl
    {
        public UC_KhachHang()
        {
            InitializeComponent();
            LoadDL(BLL_KhachHang.Instance.GetList());
        }
        public void LoadDL(List<KHACH_HANG> list)
        {
            dtgvKH.Rows.Clear();

            if (dtgvKH.Rows.Count == 0)
            {
                DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
                col1.HeaderText = "STT";
                dtgvKH.Columns.Add(col1);

                DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
                col2.HeaderText = "Tên Khách Hàng";
                dtgvKH.Columns.Add(col2);

                DataGridViewColumn col3 = new DataGridViewTextBoxColumn();
                col3.HeaderText = "Địa chỉ";
                dtgvKH.Columns.Add(col3);

                DataGridViewColumn col4 = new DataGridViewTextBoxColumn();
                col4.HeaderText = "SĐT";
                dtgvKH.Columns.Add(col4);

                DataGridViewColumn col5 = new DataGridViewTextBoxColumn();
                col5.HeaderText = "Loại";
                dtgvKH.Columns.Add(col5);

                DataGridViewColumn col6 = new DataGridViewTextBoxColumn();
                col6.HeaderText = "Điểm tích lũy";
                dtgvKH.Columns.Add(col6);

            }

            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    DataGridViewRow row1 = new DataGridViewRow();
                    row1.CreateCells(dtgvKH);

                    row1.Cells[0].Value = (i + 1) + "";
                    row1.Cells[1].Value = list[i].Ten_Khach_Hang;
                    row1.Cells[2].Value = list[i].Dia_Chi;
                    row1.Cells[3].Value = list[i].SDT;
                    row1.Cells[4].Value = list[i].LOAI_KHACH_HANG.Ten_Loai_Khach_Hang;
                    row1.Cells[5].Value = list[i].Diem_Tich_Luy;
                    row1.Tag = list[i];

                    dtgvKH.Rows.Add(row1);
                }
            }

            //dtgvKH.Columns[0].Width = 70;
            //dtgvKH.Columns[1].Width = 170;
            //lbTotal.Text = "Tổng hồ sơ: " + (dtgvCustomer.Rows.Count - 1).ToString();
        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || txtSDT.Text.Length >= 11)
            {
                e.Handled = true;
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            List<KHACH_HANG> list = new List<KHACH_HANG>();
            foreach (DataGridViewRow item in dtgvKH.Rows)
            {
                if ((KHACH_HANG)item.Tag != null) list.Add((KHACH_HANG)item.Tag);
            }

            var search = (from x in list where x.SDT.Contains(txtSDT.Text) select x).ToList();

            LoadDL(search);
        }

        private void txtSDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                String key = "";
                if (txtSDT.Text.Length > 0) key = txtSDT.Text.Substring(0, txtSDT.Text.Length - 1);
                List<KHACH_HANG> list = BLL_KhachHang.Instance.GetList();

                var search = (from x in list where x.SDT.Contains(key) select x).ToList();

                LoadDL(search);
            }
        }

        private void butReset_Click(object sender, EventArgs e)
        {
            LoadDL(BLL_KhachHang.Instance.GetList());
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa thông tin các khách hàng đã chọn (" + dtgvKH.SelectedRows.Count.ToString() + " Khách hàng được chọn)!", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    foreach (DataGridViewRow item in dtgvKH.SelectedRows)
                    {
                        BLL_KhachHang.Instance.Delete((KHACH_HANG)item.Tag);
                    }
                    MessageBox.Show("Xóa thành công");

                    LoadDL(BLL_KhachHang.Instance.GetList());
                }
                catch
                {
                    MessageBox.Show("Gặp lỗi khi xóa");
                }
            }
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            KHACH_HANG kh = (KHACH_HANG)dtgvKH.SelectedRows[0].Tag;
            AddKhachHang f = new AddKhachHang(kh);
            f.D += LoadDL;
            f.Show();
        }

        private void dtgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvKH.Rows[e.RowIndex];
                if (row.Cells[1].Value != null)
                {
                    //txtMHH.Text = row.Cells[0].Value.ToString();
                    txtTKH.Text = row.Cells[1].Value.ToString();
                    txtDC.Text = row.Cells[2].Value.ToString();
                    txtSoDT.Text = row.Cells[3].Value.ToString();
                    txtLKH.Text = row.Cells[4].Value.ToString();
                    txtDTL.Text = row.Cells[5].Value.ToString();
                    //

                }
            }
        }

        private void butTimKiem_Click(object sender, EventArgs e)
        {
            //LoadDL(search);
        }
    }
}
