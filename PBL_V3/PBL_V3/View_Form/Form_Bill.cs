using PBL_V3.BLL;
using PBL_V3.Entity;
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

namespace PBL_V3.View_Form
{
    public partial class Form_Bill : Form
    {
        private int ID_BAN { get; set; }
        private int type { get; set; }
        private String info { get; set; }
        public Form_Bill(int IDHOADON, int type, String infoKH)
        {
            this.type = type;
            ID_BAN = IDHOADON;
            info = infoKH;
            InitializeComponent();
            SetGUI();
        }
        private void SetGUI()
        {
            if (type == 0)
                lbBill.Text = "Tạm Thanh Toán";
            else lbBill.Text = "Thanh Toán";

            HOA_DON_BAN_HANG hd = BLL_HoaDon.Instance.getHOADONbyID(ID_BAN);

            txbID.Text = ID_BAN.ToString();
            txbBan.Text = BLL_Ban.Instance.GetnameTable(hd.Ma_Ban);
            NHAN_VIEN nv = BLL_NhanVien.Instance.Staff_ID_BLL(hd.Ma_Nhan_Vien);
            txbNV.Text = nv.SDT;
            txbthoigian.Text = DateTime.Now.ToString();
            txbKH.Text = info;

            CultureInfo culture = new CultureInfo("vi-VN");
            List<BILLinfo> listbillinfo = BLL_BILLinfo.Instance.GetList(BLL_Ban.Instance.gettable(hd.Ma_Ban));
            double tongcong = 0;

            foreach (BILLinfo item in listbillinfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.MatHang);
                lsvItem.SubItems.Add(item.SoLuong.ToString());
                lsvItem.SubItems.Add(item.DonGia.ToString("c", culture));
                lsvItem.SubItems.Add(item.TongTien.ToString("c", culture));
                tongcong += item.TongTien;
                HANG_HOA hh = new HANG_HOA
                {
                    Ten_Hang_Hoa = item.MatHang,
                    Gia_Hang_Hoa = Convert.ToInt32(item.DonGia),
                };
                lsvItem.Tag = hh;

                lsvbill.Items.Add(lsvItem);
            }
            txbTongcong.Text = tongcong.ToString();
            txbchietkhau.Text = "0";
            if (info != "")
            {
                KHACH_HANG kh = BLL_KhachHang.Instance.GetKHByInfo(info);
                if (kh != null)
                {
                    if (kh.Ma_Loai_Khach_Hang == 1 && kh.Diem_Tich_Luy > 20)
                    {
                        txbchietkhau.Text = ((tongcong * 5) / 100).ToString();
                    }
                    else if (kh.Ma_Loai_Khach_Hang == 2)
                    {
                        txbchietkhau.Text = ((tongcong * 10) / 100).ToString();
                    }
                }
            }

            txbThanhtien.Text = (tongcong - Convert.ToDouble(txbchietkhau.Text)).ToString();
            int? idkh = BLL_KhachHang.Instance.getIDbyInfo(info);
            if (type == 1)
            {
                if (idkh == null)
                {
                    BLL_HoaDon.Instance.Thanhtoan(ID_BAN, Convert.ToInt32(txbThanhtien.Text), null, Convert.ToInt32(txbchietkhau.Text));
                }
                else
                {
                    BLL_HoaDon.Instance.Thanhtoan(ID_BAN, Convert.ToInt32(txbThanhtien.Text), idkh, Convert.ToInt32(txbchietkhau.Text));
                }
            }

        }
    
        private void Form_Bill_Load(object sender, EventArgs e)
        {

        }
    }
}
