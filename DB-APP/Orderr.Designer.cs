namespace DB_APP
{
    partial class Orderr
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnPuls = new System.Windows.Forms.Button();
            this.btnMius = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "주문 목록";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(13, 55);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(460, 268);
            this.listBox1.TabIndex = 1;
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(14, 329);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(75, 23);
            this.btnMenu.TabIndex = 2;
            this.btnMenu.Text = "뒤로가기";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(398, 329);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(75, 23);
            this.btnBuy.TabIndex = 3;
            this.btnBuy.Text = "결제";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // btnPuls
            // 
            this.btnPuls.Location = new System.Drawing.Point(479, 101);
            this.btnPuls.Name = "btnPuls";
            this.btnPuls.Size = new System.Drawing.Size(75, 23);
            this.btnPuls.TabIndex = 4;
            this.btnPuls.Text = "+";
            this.btnPuls.UseVisualStyleBackColor = true;
            this.btnPuls.Click += new System.EventHandler(this.btnPuls_Click);
            // 
            // btnMius
            // 
            this.btnMius.Location = new System.Drawing.Point(560, 101);
            this.btnMius.Name = "btnMius";
            this.btnMius.Size = new System.Drawing.Size(75, 23);
            this.btnMius.TabIndex = 5;
            this.btnMius.Text = "-";
            this.btnMius.UseVisualStyleBackColor = true;
            this.btnMius.Click += new System.EventHandler(this.btnMius_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(479, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "수량 변경";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(479, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "메뉴 제거";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(479, 167);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "제거";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Orderr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMius);
            this.Controls.Add(this.btnPuls);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Name = "Orderr";
            this.Text = "Orderr";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Orderr_FormClosing);
            this.Load += new System.EventHandler(this.Orderr_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnPuls;
        private System.Windows.Forms.Button btnMius;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelete;
    }
}