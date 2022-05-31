using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Windows.Themes;
using PBL_V3.View_Form;



namespace PBL_V3
{
    public partial class FormAdmin : Form
    {
        //private Button currentButton;
        private Random random;
        //private int tempIndex;
        private Form activeForm;

        private string Username;

        public FormAdmin(string username)
        {
            InitializeComponent();
            Username = username;
            SetGUI();
            random = new Random();
        }

        //private Color SelectThemeColor()
        //{
        //    int index = random.Next(ThemeColor.ColorList.Count);
        //    while (tempIndex == index)
        //    {
        //        index = random.Next(ThemeColor.ColorList.Count);
        //    }
        //    tempIndex = index;
        //    string color = ThemeColor.ColorList[index];
        //    return ColorTranslator.FromHtml(color);
        //}
        //private void ActivateButton(object btnSender)
        //{
        //    if (btnSender != null)
        //    {
        //        if (currentButton != (Button)btnSender)
        //        {
        //            DisableButton();
        //            Color color = SelectThemeColor();
        //            currentButton = (Button)btnSender;
        //            currentButton.BackColor = color;
        //            currentButton.ForeColor = Color.White;
        //            currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //            panel2.BackColor = color;
        //            panel3.BackColor = ThemeColor.ChangeColorBrigthness(color, -0.3);
        //        }
        //    }
        //}

        public static String subString(String text)
        {
            int i = text.LastIndexOf(" ");
            if (i == -1)
            {
                return text.Substring(0);
            }
            else return text.Substring(i);
        }

        //private void DisableButton()
        //{
        //    foreach (Control previousBtn in panel1.Controls)
        //    {
        //        if (previousBtn.GetType() == typeof(Button))
        //        {
        //            previousBtn.BackColor = Color.FromArgb(51, 51, 76);
        //            previousBtn.ForeColor = Color.Gainsboro;
        //            previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        //        }
        //    }
        //}

        private void OpenChildForm(Form chilForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            //ActivateButton(btnSender);
            activeForm = chilForm;
            chilForm.TopLevel = false;
            chilForm.FormBorderStyle = FormBorderStyle.None;
            chilForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(chilForm);
            this.panelDesktopPane.Tag = chilForm;
            chilForm.BringToFront();
            chilForm.Show();
            label1.Text = chilForm.Text;
        }
        private void addUC(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelDesktopPane.Controls.Clear();
            panelDesktopPane.Controls.Add(c);

        }

        private void Thanhlucchon(Control tlc)
        {
            TLC.Top = tlc.Top;
            TLC.Height = tlc.Height;
        }
        private void Form11_Load(object sender, EventArgs e)
        {

        }
        void SetGUI()
        {

            //NHAN_VIEN nv = BLL.BLLNhanVien.Instance.Staff_ID_BLL(Username);
            //lbPhanQuyen.Text = subString(nv.Ten_Nhan_Vien);

        }


        private void FormAdmin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnTC_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            Thanhlucchon(btnNV);
            UC_NhanVien td = new UC_NhanVien(Username);
            addUC(td);
        }
        private void btnHH_Click_1(object sender, EventArgs e)
        {
            Thanhlucchon(btnHH);
            UC_HangHoa td = new UC_HangHoa();
            addUC(td);
        }
        private void btnKH_Click(object sender, EventArgs e)
        {
            Thanhlucchon(btnKH);
            UC_KhachHang td = new UC_KhachHang();
            addUC(td);
        }

        private void btnDT_Click(object sender, EventArgs e)
        {
            Thanhlucchon(btnDT);
            UC_DoanhThu td = new UC_DoanhThu();
            addUC(td);
        }

        private void btnHS_Click(object sender, EventArgs e)
        {
            Thanhlucchon(btnHS);
            UC_HoSo td = new UC_HoSo(Username);
            addUC(td);
        }

        private void btn_Ban_Click(object sender, EventArgs e)
        {
            Thanhlucchon(btn_Ban);
            UC_Ban td = new UC_Ban();
            addUC(td);
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
