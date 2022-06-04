using PBL_V3.BLL;
using PBL_V3.DAL;
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
        
        private BAN ban;
        
        private string user;
        public FormBanHang(string username)
        {
            InitializeComponent();
            user = username;
            btnTable_Click(new object(), new EventArgs());
            SetGUI();
        }
        private Form activeForm = null;
        private HANG_HOA hangHoa;
        private HANG_HOA hangHoa1;

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        
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
            PanelChildForm.Controls.Add(childForm);
            PanelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        void SetGUI()
        {
            List<LOAI_HANG_HOA> list = BLL_CT_HangHoa.Instance.GetLHH_BLL();
            LOAI_HANG_HOA hh = new LOAI_HANG_HOA
            {
                Ma_Loai_Hang_Hoa = -1,
                Ten_Loai_Hang_Hoa = "Tất cả"
            };
            listBox1.Items.Add(hh);
            foreach (LOAI_HANG_HOA item in list)
            {
                listBox1.Items.Add(item);
            }
            listBox1.DisplayMember = "Ten_LHH";
            NHAN_VIEN nv = BLL.BLL_NhanVien.Instance.Staff_ID_BLL(user);
            label5.Text = subString(nv.Ten_Nhan_Vien);

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
            lsvTemp.Items.Clear();
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

                lsvTemp.Items.Add(lsvItem);
            }

            txtTienhang.Text = thanhTien.ToString("c", culture);
            txtThanhTien.Text = (thanhTien - thanhTien * (int)nmrDiscount.Value).ToString();
        }


        

        #region Event

        
        private void btnTable_Click(object sender, EventArgs e)
        {
            FormTable f = new FormTable(user);
            f.getTable = ShowBill;
            OpenChildForm(f);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormMenu());
        }

        private void listLHH_MouseClick(object sender, MouseEventArgs e)
        {
            LOAI_HANG_HOA lhh = (LOAI_HANG_HOA)listBox1.SelectedItem;
            if (lhh == null)
            {
                return;
            }
            List<HANG_HOA> list = BLL_HangHoa.Instance.GetList(lhh.Ma_Loai_Hang_Hoa);
            lsvHH.Items.Clear();

            foreach (HANG_HOA item in list)
            {
                ListViewItem lsvItem = new ListViewItem(item.Ten_Hang_Hoa);

                lsvItem.SubItems.Add(item.Gia_Hang_Hoa.ToString());
                lsvItem.Tag = item;

                lsvHH.Items.Add(lsvItem);
            }
        }

        private void lsvHH_MouseClick(object sender, MouseEventArgs e)
        {
            hangHoa = (HANG_HOA)lsvHH.SelectedItems[0].Tag;
        }

        private void butThem_Click(object sender, EventArgs e)
        {
            if (hangHoa != null && ban != null)
            {
                if (BLL_HoaDon.Instance.checkHoaDon(ban.Ma_Ban) == false)
                {
                    BLL_HoaDon.Instance.InsertHOADON(ban.Ma_Ban, null, user);
                    BLL_Ban.Instance.update(ban.Ma_Ban, false);

                    btnTable_Click(new object(), new EventArgs());
                }

                int idBill = BLL_HoaDon.Instance.GetIdByTable(ban.Ma_Ban);
                foreach (ListViewItem item in lsvTemp.Items)
                {
                    if (item.SubItems[0].Text.Equals(hangHoa.Ten_Hang_Hoa))
                    {
                        int soLuong = Convert.ToInt32(item.SubItems[1].Text) + (int)nmrsoLuong.Value;
                        item.SubItems[1].Text = soLuong.ToString();
                        item.SubItems[3].Text = (hangHoa.Gia_Hang_Hoa * soLuong).ToString();
                        hangHoa = null;
                        nmrsoLuong.Value = 1;

                        BLL_CT_HoaDon.Instance.update(idBill, item.SubItems[0].Text, soLuong);
                        ShowBill(ban);
                        return;
                    }
                }

                ListViewItem lsvItem = new ListViewItem(hangHoa.Ten_Hang_Hoa);

                lsvItem.SubItems.Add(nmrsoLuong.Value.ToString());
                lsvItem.SubItems.Add(hangHoa.Gia_Hang_Hoa.ToString());
                lsvItem.SubItems.Add((Convert.ToDouble(hangHoa.Gia_Hang_Hoa.Value.ToString()) * (int)nmrsoLuong.Value).ToString());
                lsvItem.Tag = hangHoa;
                BLL_CT_HoaDon.Instance.insert(idBill, hangHoa.Ten_Hang_Hoa, (int)nmrsoLuong.Value);

                lsvTemp.Items.Add(lsvItem);
                hangHoa = null;
                nmrsoLuong.Value = 1;
                ShowBill(ban);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn món, chọn bàn");
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panelSotien.Show();
        }

        private void ghiChúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelSotien.Hide();
        }

        private void lsvTemp_MouseClick(object sender, MouseEventArgs e)
        {
            hangHoa1 = (HANG_HOA)lsvTemp.SelectedItems[0].Tag;
        }

        private void btnGiam_Click(object sender, EventArgs e)
        {
            if (hangHoa1 != null)
            {
                int idBill = BLL_HoaDon.Instance.GetIdByTable(ban.Ma_Ban);
                foreach (ListViewItem item in lsvTemp.Items)
                {
                    if (item.SubItems[0].Text.Equals(hangHoa1.Ten_Hang_Hoa))
                    {
                        int soLuong = Convert.ToInt32(item.SubItems[1].Text) - (int)nmrsoLuong.Value;
                        if (soLuong <= 0)
                        {
                            lsvTemp.Items.Remove(item);
                            hangHoa1 = null;
                            nmrsoLuong.Value = 1;
                            BLL_CT_HoaDon.Instance.delete(idBill, item.SubItems[0].Text, Convert.ToInt32(item.SubItems[1].Text));
                            if (lsvTemp.Items.Count == 0)
                            {
                                BLL_Ban.Instance.update(ban.Ma_Ban, true);
                                BLL_HoaDon.Instance.delete(idBill);
                            }
                            btnTable_Click(new object(), new EventArgs());

                            break;
                        }
                        item.SubItems[1].Text = soLuong.ToString();
                        item.SubItems[3].Text = (hangHoa1.Gia_Hang_Hoa * soLuong).ToString();
                        hangHoa1 = null;
                        nmrsoLuong.Value = 1;

                        BLL_CT_HoaDon.Instance.update(idBill, item.SubItems[0].Text, soLuong);
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (hangHoa1 != null)
            {
                foreach (ListViewItem item in lsvTemp.Items)
                {
                    if (item.SubItems[0].Text.Equals(hangHoa1.Ten_Hang_Hoa))
                    {
                        int idBill = BLL_HoaDon.Instance.GetIdByTable(ban.Ma_Ban);
                        lsvTemp.Items.Remove(item);
                        BLL_CT_HoaDon.Instance.delete(idBill, item.SubItems[0].Text, Convert.ToInt32(item.SubItems[1].Text));

                        if (lsvTemp.Items.Count == 0)
                        {
                            BLL_Ban.Instance.update(ban.Ma_Ban, true);
                            BLL_HoaDon.Instance.delete(idBill);
                        }

                        btnTable_Click(new object(), new EventArgs());

                        return;
                    }
                }
            }
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            LOAI_HANG_HOA lhh = (LOAI_HANG_HOA)listBox1.SelectedItem;
            List<HANG_HOA> list = null;
            if (listBox1.SelectedIndex < 1)
            {
                list = BLL_HangHoa.Instance.GetList(-1);
            }
            else
            {
                int a = lhh.Ma_Loai_Hang_Hoa;
                list = BLL_HangHoa.Instance.GetList(lhh.Ma_Loai_Hang_Hoa);
            }
            var search = (from x in list where x.Ten_Hang_Hoa.ToLower().Contains(txbSearch.Text) select x).ToList();
            lsvHH.Items.Clear();
            foreach (HANG_HOA x in search)
            {
                ListViewItem lsvItem = new ListViewItem(x.Ten_Hang_Hoa);
                lsvItem.SubItems.Add(x.Gia_Hang_Hoa.ToString());
                lsvItem.Tag = x;
                if (lsvHH.Items.Contains(lsvItem) == false)
                {
                    lsvHH.Items.Add(lsvItem);
                }
            }
        }
        


        private void btnThanhToan_Click(object sender, EventArgs e)
        {

            if (ban != null && BLL.BLL_HoaDon.Instance.checkHoaDon(ban.Ma_Ban))
            {


                if (txtPhoneCustomer.Text != "")
                {
                    int dtl = Convert.ToInt32(txtThanhTien.Text) / 10000;
                    KHACH_HANG kh = BLL_KhachHang.Instance.GetKHByInfo(txtPhoneCustomer.Text);
                    if (kh != null)
                    {
                        BLL_KhachHang.Instance.updateDTL(kh, dtl);
                    }
                    else
                    {
                        BLL_KhachHang.Instance.AddCustomer_BLL(txtPhoneCustomer.Text, dtl);
                    }
                }


                Form_Bill bill = new Form_Bill(BLL.BLL_HoaDon.Instance.GetIdByTable(ban.Ma_Ban), 1, txtPhoneCustomer.Text);
                txtPhoneCustomer.Text = "";
                btnTable_Click(new object(), new EventArgs());

                bill.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chua chon ban can thanh toan hoac ban khong co du lieu!!!");
            }
        }

        private void btnTamThanhToan_Click(object sender, EventArgs e)
        {
            if (ban != null && BLL.BLL_HoaDon.Instance.checkHoaDon(ban.Ma_Ban))
            {
                Form_Bill bill = new Form_Bill(BLL.BLL_HoaDon.Instance.GetIdByTable(ban.Ma_Ban), 0, txtPhoneCustomer.Text);

                bill.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chua chon ban can thanh toan hoac ban khong co du lieu!!!");
            }
        }

        private void btnTachBan_Click(object sender, EventArgs e)
        {
            if (ban != null && BLL.BLL_HoaDon.Instance.checkHoaDon(ban.Ma_Ban))
            {
                DetailTable f2 = new DetailTable(BLL_HoaDon.Instance.GetIdByTable(ban.Ma_Ban), user);

                f2.ShowDialog();
                btnTable_Click(new object(), new EventArgs());
            }
            else
            {
                MessageBox.Show("Vui long chon ban hoac ban chua duoc order!!!");
            }
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            if (ban != null && BLL.BLL_HoaDon.Instance.checkHoaDon(ban.Ma_Ban))
            {
                TableTach f2 = new TableTach(ban.Ma_Ban, null, user);
                f2.ShowDialog();
                btnTable_Click(new object(), new EventArgs());
            }
            else
            {
                MessageBox.Show("Vui  long chon ban!!!");
            }
        }

        //private void btnInCheBien_Click(object sender, EventArgs e)
        //{
        //    if (ban != null && BLL.BLL_HoaDon.Instance.checkHoaDon(ban.ID_BAN))
        //    {
        //        FormInchebien f2 = new FormInchebien(HOA_DON_BLL.Instance.GetIdByTable(ban.ID_BAN), user);
        //        f2.ShowDialog();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Chua chon ban can thanh toan hoac ban khong co du lieu!!!");
        //    }
        //}

        //private void btnAccount_Click(object sender, EventArgs e)
        //{
        //    FormStaff f = new FormStaff(user);
        //    f.D = changeInfo;
        //    f.ShowDialog();
        //}

        //private void btnKhachHang_Click(object sender, EventArgs e)
        //{
        //    FormCustomer f = new FormCustomer();
        //    f.Show();
        //}

        private void txtPhoneCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || txtPhoneCustomer.Text.Length >= 11)
            {
                e.Handled = true;
            }
        }
        #endregion

        private void butAdmin_Click(object sender, EventArgs e)
        {
            NHAN_VIEN nv = BLL_NhanVien.Instance.Staff_ID_BLL(user);
            if (nv.Chuc_Vu == "Quản lý")
            {
                if (panelAdmin.Visible == true)
                {
                    panelAdmin.Hide();
                }
                else
                {
                    panelAdmin.Show();
                }
            }
            else
            {
                MessageBox.Show("Không phải admin");
            }
        }

        private void btnTable_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.Show("Bàn", btnTable);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnQuanly_Click(object sender, EventArgs e)
        {
            FormAdmin f = new FormAdmin(user);
            f.ShowDialog();
        }

        private void btnHoSo_Click(object sender, EventArgs e)
        {
            Form_HoSo f = new Form_HoSo(user);
            f.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

