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
    public partial class DetailTable : Form
    {
        private int ID_HD { get; set; }
        private string user { get; set; }
        public DetailTable(int IDHD, string user)
        {
            this.user = user;
            ID_HD = IDHD;
            InitializeComponent();
            SETGUI();
        }
        private void SETGUI()
        {

            HOA_DON_BAN_HANG hd = BLL_HoaDon.Instance.getHOADONbyID(ID_HD);

            CultureInfo culture = new CultureInfo("vi-VN");
            List<BILLinfo> listbillinfo = BLL_BILLinfo.Instance.GetList(BLL_Ban.Instance.gettable(hd.Ma_Ban.Value));
            foreach (BILLinfo item in listbillinfo)
            {

                this.dtgDetail.Rows.Add(item.MatHang.ToString(), item.SoLuong.ToString());

            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            HOA_DON_BAN_HANG hd = BLL_HoaDon.Instance.getHOADONbyID(ID_HD);
            List<BILLinfo> listtach = new List<BILLinfo>();
            int dem = 0;
            List<BILLinfo> listbillInfo = BLL_BILLinfo.Instance.GetList(BLL_Ban.Instance.gettable((int)hd.Ma_Ban));
            for (int i = 0; i < dtgDetail.Rows.Count - 1; i++)
            {
                BILLinfo a = new BILLinfo();
                if (dtgDetail.Rows[i].Cells["ten"].Value != null)
                {
                    a.MatHang = dtgDetail.Rows[i].Cells["ten"].Value.ToString();

                    if (UC_NhanVien.isDigit(dtgDetail.Rows[i].Cells["SL"].Value.ToString()) && dtgDetail.Rows[i].Cells["ten"].Value != null)
                    {
                        if (Convert.ToInt32(dtgDetail.Rows[i].Cells["SL"].Value) < 0 || Convert.ToInt32(dtgDetail.Rows[i].Cells["SL"].Value) > listbillInfo[i].SoLuong)
                        {
                            MessageBox.Show("So luong cua mon  " + a.MatHang.ToString() + " khong phu hop");
                            ++dem;
                        }
                        else
                        {
                            a.SoLuong = Convert.ToInt32(dtgDetail.Rows[i].Cells["SL"].Value);
                            listtach.Add(a);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số lượng nhập không đúng");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi ");
                    return;
                }

            }
            if (dem == 0)
            {
                TableTach f = new TableTach((int)hd.Ma_Ban, listtach, user);
                f.ShowDialog();
                this.Dispose();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
