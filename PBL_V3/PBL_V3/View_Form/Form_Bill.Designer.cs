namespace PBL_V3.View_Form
{
    partial class Form_Bill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lsvbill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.txbthoigian = new System.Windows.Forms.TextBox();
            this.txbNV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbKH = new System.Windows.Forms.TextBox();
            this.txbBan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txbThanhtien = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txbchietkhau = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbTongcong = new System.Windows.Forms.TextBox();
            this.lbBill = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvbill
            // 
            this.lsvbill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvbill.HideSelection = false;
            this.lsvbill.Location = new System.Drawing.Point(22, 202);
            this.lsvbill.Name = "lsvbill";
            this.lsvbill.Size = new System.Drawing.Size(441, 365);
            this.lsvbill.TabIndex = 13;
            this.lsvbill.UseCompatibleStateImageBehavior = false;
            this.lsvbill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên đồ uống";
            this.columnHeader1.Width = 122;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "SL";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 71;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đ. giá";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 106;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "T.Tiền";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 137;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(102, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 29);
            this.label1.TabIndex = 11;
            this.label1.Text = "HÓA ĐƠN BÁN HÀNG";
            // 
            // txbthoigian
            // 
            this.txbthoigian.Location = new System.Drawing.Point(71, 77);
            this.txbthoigian.Name = "txbthoigian";
            this.txbthoigian.ReadOnly = true;
            this.txbthoigian.Size = new System.Drawing.Size(199, 22);
            this.txbthoigian.TabIndex = 9;
            // 
            // txbNV
            // 
            this.txbNV.Location = new System.Drawing.Point(209, 40);
            this.txbNV.Name = "txbNV";
            this.txbNV.ReadOnly = true;
            this.txbNV.Size = new System.Drawing.Size(100, 22);
            this.txbNV.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(162, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "NV:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "KH:";
            // 
            // txbKH
            // 
            this.txbKH.Location = new System.Drawing.Point(46, 40);
            this.txbKH.Name = "txbKH";
            this.txbKH.ReadOnly = true;
            this.txbKH.Size = new System.Drawing.Size(100, 22);
            this.txbKH.TabIndex = 5;
            // 
            // txbBan
            // 
            this.txbBan.Location = new System.Drawing.Point(209, 7);
            this.txbBan.Name = "txbBan";
            this.txbBan.ReadOnly = true;
            this.txbBan.Size = new System.Drawing.Size(100, 22);
            this.txbBan.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(155, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Bàn:";
            // 
            // txbID
            // 
            this.txbID.Location = new System.Drawing.Point(46, 7);
            this.txbID.Name = "txbID";
            this.txbID.ReadOnly = true;
            this.txbID.Size = new System.Drawing.Size(100, 22);
            this.txbID.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "ID:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbthoigian);
            this.panel1.Controls.Add(this.txbNV);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txbKH);
            this.panel1.Controls.Add(this.txbBan);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txbID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(71, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 102);
            this.panel1.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(79, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tổng cộng:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txbThanhtien);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txbchietkhau);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txbTongcong);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(60, 573);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(329, 124);
            this.panel2.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(78, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(180, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "Cảm ơn và hẹn gặp lại!";
            // 
            // txbThanhtien
            // 
            this.txbThanhtien.Location = new System.Drawing.Point(175, 68);
            this.txbThanhtien.Name = "txbThanhtien";
            this.txbThanhtien.ReadOnly = true;
            this.txbThanhtien.Size = new System.Drawing.Size(135, 22);
            this.txbThanhtien.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(79, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Thành tiền:";
            // 
            // txbchietkhau
            // 
            this.txbchietkhau.Location = new System.Drawing.Point(175, 39);
            this.txbchietkhau.Name = "txbchietkhau";
            this.txbchietkhau.ReadOnly = true;
            this.txbchietkhau.Size = new System.Drawing.Size(135, 22);
            this.txbchietkhau.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(79, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Thuế VAT:";
            // 
            // txbTongcong
            // 
            this.txbTongcong.Location = new System.Drawing.Point(175, 9);
            this.txbTongcong.Name = "txbTongcong";
            this.txbTongcong.ReadOnly = true;
            this.txbTongcong.Size = new System.Drawing.Size(135, 22);
            this.txbTongcong.TabIndex = 1;
            // 
            // lbBill
            // 
            this.lbBill.AutoSize = true;
            this.lbBill.Location = new System.Drawing.Point(204, 58);
            this.lbBill.Name = "lbBill";
            this.lbBill.Size = new System.Drawing.Size(51, 16);
            this.lbBill.TabIndex = 15;
            this.lbBill.Text = "label10";
            // 
            // Form_Bill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 726);
            this.Controls.Add(this.lsvbill);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lbBill);
            this.Name = "Form_Bill";
            this.Text = "Form_Bill";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form_Bill_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.ListView lsvbill;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbthoigian;
        private System.Windows.Forms.TextBox txbNV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbKH;
        private System.Windows.Forms.TextBox txbBan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbThanhtien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbchietkhau;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbTongcong;
        private System.Windows.Forms.Label lbBill;
    }
}