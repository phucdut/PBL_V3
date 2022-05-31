namespace PBL_V3.View_Form
{
    partial class UC_HangHoa
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbLHH = new System.Windows.Forms.ComboBox();
            this.butEdit = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.butAdd = new System.Windows.Forms.Button();
            this.butTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGHH = new System.Windows.Forms.TextBox();
            this.txtTHH = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dtgvHH = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHH)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 640);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1063, 10);
            this.panel4.TabIndex = 12;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(10, 10);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1063, 640);
            this.panel5.TabIndex = 13;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.groupBox1);
            this.panel6.Controls.Add(this.pictureBox1);
            this.panel6.Location = new System.Drawing.Point(10, 10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1067, 215);
            this.panel6.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbbLHH);
            this.groupBox1.Controls.Add(this.butEdit);
            this.groupBox1.Controls.Add(this.butDel);
            this.groupBox1.Controls.Add(this.butAdd);
            this.groupBox1.Controls.Add(this.butTimKiem);
            this.groupBox1.Controls.Add(this.txtTimKiem);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtGHH);
            this.groupBox1.Controls.Add(this.txtTHH);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(212, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(838, 211);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin Hàng hóa";
            // 
            // cbbLHH
            // 
            this.cbbLHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLHH.FormattingEnabled = true;
            this.cbbLHH.Location = new System.Drawing.Point(600, 22);
            this.cbbLHH.Name = "cbbLHH";
            this.cbbLHH.Size = new System.Drawing.Size(232, 26);
            this.cbbLHH.TabIndex = 36;
            this.cbbLHH.SelectedIndexChanged += new System.EventHandler(this.cbbLHH_SelectedIndexChanged);
            // 
            // butEdit
            // 
            this.butEdit.Image = global::PBL_V3.Properties.Resources.save_24px;
            this.butEdit.Location = new System.Drawing.Point(308, 91);
            this.butEdit.Name = "butEdit";
            this.butEdit.Size = new System.Drawing.Size(49, 45);
            this.butEdit.TabIndex = 33;
            this.butEdit.UseVisualStyleBackColor = true;
            this.butEdit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // butDel
            // 
            this.butDel.Image = global::PBL_V3.Properties.Resources.Delete_24px;
            this.butDel.Location = new System.Drawing.Point(195, 91);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(51, 45);
            this.butDel.TabIndex = 34;
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // butAdd
            // 
            this.butAdd.Image = global::PBL_V3.Properties.Resources.add_30px;
            this.butAdd.Location = new System.Drawing.Point(81, 91);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(54, 45);
            this.butAdd.TabIndex = 35;
            this.butAdd.Text = "C";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butTimKiem
            // 
            this.butTimKiem.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.butTimKiem.FlatAppearance.BorderSize = 2;
            this.butTimKiem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butTimKiem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.butTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTimKiem.Location = new System.Drawing.Point(241, 22);
            this.butTimKiem.Name = "butTimKiem";
            this.butTimKiem.Size = new System.Drawing.Size(130, 37);
            this.butTimKiem.TabIndex = 31;
            this.butTimKiem.Text = "Tìm kiếm";
            this.butTimKiem.UseVisualStyleBackColor = true;
            this.butTimKiem.Click += new System.EventHandler(this.butTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(29, 30);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(186, 24);
            this.txtTimKiem.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(443, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Giá Hàng hóa:";
            // 
            // txtGHH
            // 
            this.txtGHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGHH.Location = new System.Drawing.Point(600, 132);
            this.txtGHH.Name = "txtGHH";
            this.txtGHH.Size = new System.Drawing.Size(232, 24);
            this.txtGHH.TabIndex = 29;
            // 
            // txtTHH
            // 
            this.txtTHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTHH.Location = new System.Drawing.Point(600, 73);
            this.txtTHH.Name = "txtTHH";
            this.txtTHH.Size = new System.Drawing.Size(232, 24);
            this.txtTHH.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(436, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "Loại Hàng hóa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(441, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Tên Hàng hóa:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PBL_V3.Properties.Resources.sđá;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 157);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.Controls.Add(this.dtgvHH);
            this.panel7.Location = new System.Drawing.Point(-7, 231);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1077, 406);
            this.panel7.TabIndex = 11;
            // 
            // dtgvHH
            // 
            this.dtgvHH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvHH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvHH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvHH.Location = new System.Drawing.Point(0, 0);
            this.dtgvHH.Name = "dtgvHH";
            this.dtgvHH.RowHeadersWidth = 51;
            this.dtgvHH.RowTemplate.Height = 24;
            this.dtgvHH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvHH.Size = new System.Drawing.Size(1077, 406);
            this.dtgvHH.TabIndex = 0;
            this.dtgvHH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvHH_CellClick);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1073, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 640);
            this.panel3.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1073, 10);
            this.panel2.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 650);
            this.panel1.TabIndex = 9;
            // 
            // UC_HangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UC_HangHoa";
            this.Size = new System.Drawing.Size(1083, 650);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView dtgvHH;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butEdit;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Button butTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGHH;
        private System.Windows.Forms.TextBox txtTHH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbLHH;
    }
}
