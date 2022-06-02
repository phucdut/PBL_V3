using PBL_V3.BLL;
using PBL_V3.Entity;
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
    public partial class TableTach : Form
    {
        private int idban { get; set; }
        private int newIDBAN { get; set; }
        private List<BILLinfo> listhh { get; set; }
        private string user { get; set; }
        public TableTach(int id, List<BILLinfo> list, string user)
        {
            this.user = user;
            listhh = list;
            idban = id;
            InitializeComponent();
            LoadTable();
        }
        public void LoadTable()
        {
            flpTable.Controls.Clear();
            List<BAN> tableList = BLL_Ban.Instance.GetTable();



            foreach (BAN item in tableList)
            {
                Button btn = new Button() { Width = 68, Height = 68, BackColor = Color.Gray, ForeColor = Color.White };
                if (item.Tinh_Trang == false) btn.BackColor = Color.Red;
                btn.Text = item.Ten_Ban;
                btn.Tag = item;
                btn.Click += Btn_Click;



                flpTable.Controls.Add(btn);
            }



        }
        private void Btn_Click(object sender, EventArgs e)
        {
            BAN table = (sender as Button).Tag as BAN;
            if (table.Ma_Ban == idban)
            {
                MessageBox.Show("Khong hop le");
            }
            if (table.Ma_Ban_Chuyen_Den != null)
            {
                MessageBox.Show("Xin lỗi, bàn này đang được gộp!!!");
            }
            else
            {
                newIDBAN = table.Ma_Ban;
            }



        }



        private void btnLuu_Click(object sender, EventArgs e)
        { /// tach ban
            if (listhh != null)
            {
                List<BILLinfo> listBillInfo = BLL_BILLinfo.Instance.GetList(BLL_Ban.Instance.gettable(idban));



                for (int i = 0; i < listBillInfo.Count; i++)
                {
                    listBillInfo[i].SoLuong = listBillInfo[i].SoLuong - listhh[i].SoLuong;



                    if (listBillInfo[i].SoLuong <= 0)
                    {
                        BLL_CT_HoaDon.Instance.delete(BLL_HoaDon.Instance.GetIdByTable(idban), listBillInfo[i].MatHang, listBillInfo[i].SoLuong);



                    }
                    else BLL_CT_HoaDon.Instance.update(BLL_HoaDon.Instance.GetIdByTable(idban), listBillInfo[i].MatHang, listBillInfo[i].SoLuong);
                }



                if (BLL_BILLinfo.Instance.GetList(BLL_Ban.Instance.gettable(idban)).Count <= 0)
                {
                    BLL_Ban.Instance.update(idban, true);
                    BLL_HoaDon.Instance.delete(BLL_HoaDon.Instance.GetIdByTable(idban));
                }
            }
            /// Chuyen ban
            else
            {
                listhh = BLL_BILLinfo.Instance.GetList(BLL_Ban.Instance.gettable(idban));
                string message = "Giữ lại bàn cũ?";
                string title = " ";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    BAN ban = BLL_Ban.Instance.gettable(idban);
                    BLL_Ban.Instance.updateID_chuyen(idban, newIDBAN);
                    List<BAN> listban = BLL_Ban.Instance.GetTable();
                    foreach (BAN item in listban)
                    {
                        if (item.Ma_Ban_Chuyen_Den == idban)
                            BLL_Ban.Instance.updateID_chuyen(item.Ma_Ban, newIDBAN);
                    }
                }
                else
                {
                    BLL_Ban.Instance.update(idban, true);
                }

                for (int i = 0; i < listhh.Count; i++)
                {
                    BLL_CT_HoaDon.Instance.delete(BLL_HoaDon.Instance.GetIdByTable(idban), listhh[i].MatHang, listhh[i].SoLuong);
                }
                BLL_HoaDon.Instance.delete(BLL_HoaDon.Instance.GetIdByTable(idban));
            }
            if (BLL_HoaDon.Instance.checkHoaDon(newIDBAN) == false)
            {
                BLL_HoaDon.Instance.InsertHOADON(newIDBAN, null, user);
                BLL_Ban.Instance.update(newIDBAN, false);
            }
            int idbill = BLL_HoaDon.Instance.GetIdByTable(newIDBAN);
            List<BILLinfo> listbillinfo = BLL_BILLinfo.Instance.GetList(BLL_Ban.Instance.gettable(newIDBAN));
            int k = 0;
            foreach (BILLinfo item in listhh)
            {
                if (item.SoLuong > 0)
                {
                    foreach (BILLinfo i in listbillinfo)
                    {
                        k = 0;
                        if (item.MatHang == i.MatHang)
                        {
                            BLL_CT_HoaDon.Instance.update(idbill, item.MatHang, item.SoLuong + i.SoLuong);
                            k = 1;
                            break;
                        }
                    }
                    if (k == 0)
                        BLL_CT_HoaDon.Instance.insert(idbill, item.MatHang, item.SoLuong);
                }
            }
            this.Dispose();
        }



        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
