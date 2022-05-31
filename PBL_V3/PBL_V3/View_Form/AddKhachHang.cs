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
    public partial class AddKhachHang : Form
    {
        private KHACH_HANG kh;
        public MyDel D { get => d; set => d = value; }

        public delegate void MyDel(List<KHACH_HANG> list);
        private MyDel d;

        public AddKhachHang(KHACH_HANG khachhang)
        {
            InitializeComponent();
            kh = khachhang;
            setGUI();
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void setGUI()
        {
            txtTKH.Text = kh.Ten_Khach_Hang;
            txtDC.Text = kh.Dia_Chi;
            txtSDT.Text = kh.SDT;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận lưu thông tin", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (txtTKH.Text != kh.Ten_Khach_Hang || txtDC.Text != kh.Dia_Chi || txtSDT.Text != kh.SDT)
                {
                    if (BLL_KhachHang.Instance.checkSDT(txtSDT.Text) == false || BLL_KhachHang.Instance.GetKHByInfo(txtSDT.Text).Ma_Khach_Hang == kh.Ma_Khach_Hang)
                    {
                        kh.Ten_Khach_Hang = txtTKH.Text;
                        kh.Dia_Chi = txtDC.Text;
                        kh.SDT = txtSDT.Text;

                        BLL_KhachHang.Instance.UpdateKH(kh);
                    }
                    else
                    {
                        if (MessageBox.Show("Số điện thoại đã tồn tại, Xác nhận cộng dồn điểm tích lũy?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            int dtl = Convert.ToInt32(kh.Diem_Tich_Luy);
                            KHACH_HANG khachhang = BLL_KhachHang.Instance.GetKHByInfo(txtSDT.Text);
                            int idBill = BLL_HoaDon.Instance.getIDByKH(kh);

                            BLL_HoaDon.Instance.UpdateKH(idBill, khachhang);
                            BLL_KhachHang.Instance.Delete(kh);
                            BLL_KhachHang.Instance.updateDTL(khachhang, dtl);
                        }
                    }

                    List<KHACH_HANG> list = BLL_KhachHang.Instance.GetList();
                    D(list);
                }
                this.Close();
            }
        }
    }
}
