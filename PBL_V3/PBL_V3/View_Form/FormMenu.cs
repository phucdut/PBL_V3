using PBL_V3.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL_V3.View_Form
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            LoadMenu();
        }
        private void btnAddGoods_Click(object sender, EventArgs e)
        {
            AddHangHoa f = new AddHangHoa("");
            f.Show();
        }
        void LoadMenu()
        {
            flpMenu.Controls.Clear();
            List<HANG_HOA> list = BLL_HangHoa.Instance.GetList();

            foreach (HANG_HOA item in list)
            {
                PictureBox pic = new PictureBox { Width = 100, Height = 100 };
                MemoryStream stream = new MemoryStream(item.Hinh_Anh.ToArray());
                Image image = Image.FromStream(stream);
                pic.Image = image;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                Bitmap bitmap = new Bitmap(pic.Image);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawString(item.Ten_Hang_Hoa, new Font("Tahoma", 30), Brushes.White, bitmap.Width - 250, +250);
                g.DrawString(item.Gia_Hang_Hoa.ToString(), new Font("Tahoma", 40), Brushes.White, bitmap.Width - 220, bitmap.Height - 90);
                pic.Image = (Image)bitmap;

                flpMenu.Controls.Add(pic);
            }
        }
    }
}
