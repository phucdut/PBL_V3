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
    public partial class UC_HangHoa : UserControl
    {
        public UC_HangHoa()
        {
            InitializeComponent();
            Load_DL(-1);
            LoadCBB();
        }
        
        private void butAdd_Click(object sender, EventArgs e)
        {
            AddHangHoa f = new AddHangHoa("");
            f.D += new AddHangHoa.MyDel(Load_DL);
            f.Show();
        }
        public void Load_DL(int idLHH)
        {
            dtgvHH.Rows.Clear();
            List<HANG_HOA> list = new List<HANG_HOA>();
            list = BLL_HangHoa.Instance.GetList(idLHH);

            if (dtgvHH.Columns.Count == 0)
            {
                DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
                col1.HeaderText = "STT";
                dtgvHH.Columns.Add(col1);

                DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
                col2.HeaderText = "Tên hàng hóa";
                dtgvHH.Columns.Add(col2);

                DataGridViewColumn col3 = new DataGridViewTextBoxColumn();
                col3.HeaderText = "Giá";
                dtgvHH.Columns.Add(col3);

                DataGridViewColumn col4 = new DataGridViewTextBoxColumn();
                col4.HeaderText = "Loại hàng hóa";
                dtgvHH.Columns.Add(col4);
            }
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    DataGridViewRow row1 = new DataGridViewRow();
                    row1.CreateCells(dtgvHH);

                    row1.Cells[0].Value = (i + 1) + "";
                    row1.Cells[1].Value = list[i].Ten_Hang_Hoa;
                    row1.Cells[2].Value = list[i].Gia_Hang_Hoa;
                    row1.Cells[3].Value = list[i].LOAI_HANG_HOA.Ten_Loai_Hang_Hoa;

                    dtgvHH.Rows.Add(row1);
                }

                dtgvHH.Columns[0].Width = 70;
            }
            //lbTotal.Text = "Tổng số món: " + (dtgvGoods.Rows.Count - 1).ToString();
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
       
        internal static bool isDigit(string v)
        {
            var isNumeric = !string.IsNullOrEmpty(v) && v.All(Char.IsDigit);
            return isNumeric;
        }
        private void cbbLHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idLHH = (int)((CBBItem)cbbLHH.SelectedItem).Value;
            Load_DL(idLHH);
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            String Ten_HH = dtgvHH.SelectedRows[0].Cells[1].Value.ToString();
            AddHangHoa f = new AddHangHoa(Ten_HH);
            f.D += new AddHangHoa.MyDel(Load_DL);
            f.Show();
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            String Ten_HH = dtgvHH.SelectedRows[0].Cells[1].Value.ToString();
            HANG_HOA hanghoa = BLL_HangHoa.Instance.GetHHByName(Ten_HH);
            BLL_HangHoa.Instance.delete(hanghoa);
            Load_DL((int)((CBBItem)cbbLHH.SelectedItem).Value);
        }

        private void dtgvHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvHH.Rows[e.RowIndex];
                if (row.Cells[1].Value != null)
                {
                    //txtMHH.Text = row.Cells[0].Value.ToString();
                    txtTHH.Text = row.Cells[1].Value.ToString();
                    txtGHH.Text = row.Cells[2].Value.ToString();
                    cbbLHH.Text = row.Cells[3].Value.ToString();
                    //

                }
            }
        }

        

        private void butTimKiem_Click(object sender, EventArgs e)
        {
            string s = txtTimKiem.Text.ToString();
            dtgvHH.DataSource = BLL_HangHoa.Instance.GetHHByName(s);
        }
    }
}
