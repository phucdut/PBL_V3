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
    public partial class FormTable : Form
    {
        public Action<BAN> getTable;
        private string user;
        public FormTable(string username)
        {
            InitializeComponent();
            LoadTable();
            user = username;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (table.Ma_Ban_Chuyen_Den != null)
            {
                MessageBox.Show("Xin lỗi,Bàn này đang được gộp!!!");
            }
            else
            {
                FormBanHang f = new FormBanHang(user);
                getTable.Invoke(table);
            }
        }

        private void flpTable_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
