using PBL_V3.BLL;
using PBL_V3.Entity;
using PBL_V3.View_Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL_V3
{
    public partial class FormBanHang : Form
    {
        private HANG_HOA hangHoa;
        private HANG_HOA hangHoa1;
        private BAN ban;
        
        private string user;
        public FormBanHang(string username)
        {
            InitializeComponent();
            user = username;
            SetGUI();
        }
        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelForm.Controls.Add(childForm);
            panelForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butThanhToan_Click(object sender, EventArgs e)
        {
            Form_Bill tt = new Form_Bill();
            tt.ShowDialog();
            this.Show();
        }

        private void butTamThanhToan_Click(object sender, EventArgs e)
        {
            Form_Bill tt = new Form_Bill();
            tt.ShowDialog();
            this.Show();
        }
        void SetGUI()
        {
            List<LOAI_HANG_HOA> list = BLL_CT_HangHoa.Instance.GetLHH_BLL();
            LOAI_HANG_HOA hh = new LOAI_HANG_HOA
            {
                Ma_Loai_Hang_Hoa = -1,
                Ten_Loai_Hang_Hoa = "Tất cả"
            };
            
            NHAN_VIEN nv = BLL.BLL_NhanVien.Instance.Staff_ID_BLL(user);
            label5.Text = subString(nv.Ten_Nhan_Vien);
        }
        public void LoadCBB()
        {
            cbbLHH.Items.Add(new CBBItem
            {
                Text = "Tất cả",
                Value = -1,
            });
            cbbLHH.Items.AddRange(BLL_CT_HangHoa.Instance.GetCBB().ToArray());
            cbbLHH.SelectedIndex = 0;
        }
        public static String subString(String text)
        {
            int i = text.LastIndexOf(" ");
            if (i == -1)
            {
                return text.Substring(0);
            }
            else return text.Substring(i);
        }
        void changeInfo(String info)
        {
            label5.Text = info;
        }
        void ShowBill(BAN table)
        {
            this.ban = table;
            dtgvOrder.Items.Clear();
            CultureInfo culture = new CultureInfo("vi-VN");
            List<BILLinfo> listBillInfo = BLL_BILLinfo.Instance.GetList(ban);
            double thanhTien = 0;
            foreach (BILLinfo item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.MatHang);
                lsvItem.SubItems.Add(item.SoLuong.ToString());
                lsvItem.SubItems.Add(item.DonGia.ToString("c", culture));
                lsvItem.SubItems.Add(item.TongTien.ToString("c", culture));
                thanhTien += item.TongTien;

                HANG_HOA hh = new HANG_HOA
                {
                    Ten_Hang_Hoa = item.MatHang,
                    Gia_Hang_Hoa = Convert.ToInt32(item.DonGia),
                };
                lsvItem.Tag = hh;

                dtgvOrder.Items.Add(lsvItem);
            }

            txtTongTien.Text = thanhTien.ToString("c", culture);
            txtThanhTien.Text = (thanhTien - thanhTien * (int)cbbGG.Value).ToString();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            FormTable f = new FormTable(user);
            f.getTable = ShowBill;
            OpenChildForm(f);
        }
    }
}
