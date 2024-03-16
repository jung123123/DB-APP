namespace DB_APP
{
    partial class Admin
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
            this.btnReset = new System.Windows.Forms.Button();
            this.btnFpost = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.txtMname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMprice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMfnumber = new System.Windows.Forms.TextBox();
            this.btnMpost = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnFdelete = new System.Windows.Forms.Button();
            this.btnMdelete = new System.Windows.Forms.Button();
            this.btnFupdate = new System.Windows.Forms.Button();
            this.btnMupdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(115, 23);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "기본 값 초기화";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnFpost
            // 
            this.btnFpost.Location = new System.Drawing.Point(189, 47);
            this.btnFpost.Name = "btnFpost";
            this.btnFpost.Size = new System.Drawing.Size(75, 23);
            this.btnFpost.TabIndex = 1;
            this.btnFpost.Text = "추가";
            this.btnFpost.UseVisualStyleBackColor = true;
            this.btnFpost.Click += new System.EventHandler(this.btnFpost_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "코너 이름 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "메뉴 이름 :";
            // 
            // txtFname
            // 
            this.txtFname.Location = new System.Drawing.Point(83, 49);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(100, 21);
            this.txtFname.TabIndex = 4;
            // 
            // txtMname
            // 
            this.txtMname.Location = new System.Drawing.Point(83, 80);
            this.txtMname.Name = "txtMname";
            this.txtMname.Size = new System.Drawing.Size(100, 21);
            this.txtMname.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "메뉴 가격 : ";
            // 
            // txtMprice
            // 
            this.txtMprice.Location = new System.Drawing.Point(274, 80);
            this.txtMprice.Name = "txtMprice";
            this.txtMprice.Size = new System.Drawing.Size(100, 21);
            this.txtMprice.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(390, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "판매 코너 번호 :";
            // 
            // txtMfnumber
            // 
            this.txtMfnumber.Location = new System.Drawing.Point(489, 80);
            this.txtMfnumber.Name = "txtMfnumber";
            this.txtMfnumber.Size = new System.Drawing.Size(100, 21);
            this.txtMfnumber.TabIndex = 9;
            // 
            // btnMpost
            // 
            this.btnMpost.Location = new System.Drawing.Point(595, 78);
            this.btnMpost.Name = "btnMpost";
            this.btnMpost.Size = new System.Drawing.Size(75, 23);
            this.btnMpost.TabIndex = 10;
            this.btnMpost.Text = "추가";
            this.btnMpost.UseVisualStyleBackColor = true;
            this.btnMpost.Click += new System.EventHandler(this.btnMpost_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "코너";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(298, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "메뉴";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(14, 162);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(279, 208);
            this.listBox1.TabIndex = 14;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(300, 162);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(370, 208);
            this.listBox2.TabIndex = 15;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // btnFdelete
            // 
            this.btnFdelete.Location = new System.Drawing.Point(218, 376);
            this.btnFdelete.Name = "btnFdelete";
            this.btnFdelete.Size = new System.Drawing.Size(75, 23);
            this.btnFdelete.TabIndex = 16;
            this.btnFdelete.Text = "삭제";
            this.btnFdelete.UseVisualStyleBackColor = true;
            this.btnFdelete.Click += new System.EventHandler(this.btnFdelete_Click);
            // 
            // btnMdelete
            // 
            this.btnMdelete.Location = new System.Drawing.Point(595, 376);
            this.btnMdelete.Name = "btnMdelete";
            this.btnMdelete.Size = new System.Drawing.Size(75, 23);
            this.btnMdelete.TabIndex = 17;
            this.btnMdelete.Text = "삭제";
            this.btnMdelete.UseVisualStyleBackColor = true;
            this.btnMdelete.Click += new System.EventHandler(this.btnMdelete_Click);
            // 
            // btnFupdate
            // 
            this.btnFupdate.Location = new System.Drawing.Point(270, 47);
            this.btnFupdate.Name = "btnFupdate";
            this.btnFupdate.Size = new System.Drawing.Size(75, 23);
            this.btnFupdate.TabIndex = 18;
            this.btnFupdate.Text = "수정";
            this.btnFupdate.UseVisualStyleBackColor = true;
            this.btnFupdate.Click += new System.EventHandler(this.btnFupdate_Click);
            // 
            // btnMupdate
            // 
            this.btnMupdate.Location = new System.Drawing.Point(676, 78);
            this.btnMupdate.Name = "btnMupdate";
            this.btnMupdate.Size = new System.Drawing.Size(75, 23);
            this.btnMupdate.TabIndex = 19;
            this.btnMupdate.Text = "수정";
            this.btnMupdate.UseVisualStyleBackColor = true;
            this.btnMupdate.Click += new System.EventHandler(this.btnMupdate_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMupdate);
            this.Controls.Add(this.btnFupdate);
            this.Controls.Add(this.btnMdelete);
            this.Controls.Add(this.btnFdelete);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnMpost);
            this.Controls.Add(this.txtMfnumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMprice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMname);
            this.Controls.Add(this.txtFname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFpost);
            this.Controls.Add(this.btnReset);
            this.Name = "Admin";
            this.Text = "Admin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Admin_FormClosing);
            this.Load += new System.EventHandler(this.Admin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnFpost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.TextBox txtMname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMprice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMfnumber;
        private System.Windows.Forms.Button btnMpost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btnFdelete;
        private System.Windows.Forms.Button btnMdelete;
        private System.Windows.Forms.Button btnFupdate;
        private System.Windows.Forms.Button btnMupdate;
    }
}