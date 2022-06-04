using PBL_V3.BLL;
using PBL_V3.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL_V3.View_Form
{
    public partial class Edit_HangHoa : Form
    {
        private String hh;
        public delegate void MyDel(int idLHH);
        private MyDel d;

        public MyDel D { get => d; set => d = value; }
        public Edit_HangHoa(String Ten_HH)
        {
            InitializeComponent();
            hh = Ten_HH;
            LoadCBB();
        }
        public void LoadCBB()
        {
            cbbLHH.Items.AddRange(BLL_CT_HangHoa.Instance.GetCBB().ToArray());
            int index = 0;
            if (hh != "")
            {
                HANG_HOA hanghoa = BLL_HangHoa.Instance.GetHHByName(hh);
                for (int i = 1; i < cbbLHH.Items.Count; i++)
                {
                    if (((CBBItem)cbbLHH.Items[i]).Value == hanghoa.Ma_Loai_Hang_Hoa)
                    {
                        index = i;
                        break;
                    }
                }
                txtTenHangHoa.Text = hh;
                txtGiaHangHoa.Text = hanghoa.Gia_Hang_Hoa.ToString();

                MemoryStream stream = new MemoryStream(hanghoa.Hinh_Anh.ToArray());
                Image image = Image.FromStream(stream);
                ptrGoods.Image = image;
            }

            cbbLHH.SelectedIndex = index;


        }

        private void btnPic_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            String file = openFileDialog1.FileName;
            if (string.IsNullOrEmpty(file)) return;

            Image myImage = Image.FromFile(file);
            ptrGoods.Image = myImage;
        }
        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenHangHoa.Text != "" && txtGiaHangHoa.Text != "" && cbbLHH.SelectedItem != null && ptrGoods.Image != null)
                {
                    MemoryStream stream = new MemoryStream();
                    ptrGoods.Image.Save(stream, ImageFormat.Jpeg);
                    HANG_HOA merchandise = new HANG_HOA
                    {
                        Ma_Loai_Hang_Hoa = (int)((CBBItem)cbbLHH.SelectedItem).Value,
                       // Ma_Hang_Hoa = int.Parse(txtmhh.Text),
                        Ten_Hang_Hoa = txtTenHangHoa.Text,
                        Hinh_Anh = stream.ToArray(),
                        Gia_Hang_Hoa = Convert.ToDecimal(txtGiaHangHoa.Text),
                        Tinh_Trang = 1
                    };
                    if (hh == "")
                    {
                        if (BLL_HangHoa.Instance.GetHHByName(txtTenHangHoa.Text) == null)
                        {
                            BLL_HangHoa.Instance.Add(merchandise);
                        }
                        else
                        {
                            if (MessageBox.Show("Hàng hóa đã tồn tại. Xác nhận thay đổi!", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                            {
                                BLL_HangHoa.Instance.update(merchandise, txtTenHangHoa.Text);
                            }
                        }
                    }
                    else
                    {
                        BLL_HangHoa.Instance.update(merchandise, hh);
                    }

                    MessageBox.Show("Thao tác thành công");
                    D(-1);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
            }
            catch
            {
                MessageBox.Show("Thao tác thất bại");
            }
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
