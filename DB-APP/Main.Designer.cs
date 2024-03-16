namespace DB_APP
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.메뉴MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.관리자GToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.종료XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNumer = new System.Windows.Forms.Button();
            this.plMain = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.plMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.메뉴MToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 메뉴MToolStripMenuItem
            // 
            this.메뉴MToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.관리자GToolStripMenuItem,
            this.toolStripSeparator1,
            this.종료XToolStripMenuItem});
            this.메뉴MToolStripMenuItem.Name = "메뉴MToolStripMenuItem";
            this.메뉴MToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.메뉴MToolStripMenuItem.Text = "메뉴(&M)";
            // 
            // 관리자GToolStripMenuItem
            // 
            this.관리자GToolStripMenuItem.Name = "관리자GToolStripMenuItem";
            this.관리자GToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.관리자GToolStripMenuItem.Text = "관리자(&G)";
            this.관리자GToolStripMenuItem.Click += new System.EventHandler(this.관리자GToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(123, 6);
            // 
            // 종료XToolStripMenuItem
            // 
            this.종료XToolStripMenuItem.Name = "종료XToolStripMenuItem";
            this.종료XToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.종료XToolStripMenuItem.Text = "종료(&X)";
            this.종료XToolStripMenuItem.Click += new System.EventHandler(this.종료XToolStripMenuItem_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 34);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(428, 256);
            this.listBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "번호표";
            // 
            // btnNumer
            // 
            this.btnNumer.Location = new System.Drawing.Point(14, 296);
            this.btnNumer.Name = "btnNumer";
            this.btnNumer.Size = new System.Drawing.Size(121, 36);
            this.btnNumer.TabIndex = 2;
            this.btnNumer.Text = "번호표 뽑기";
            this.btnNumer.UseVisualStyleBackColor = true;
            this.btnNumer.Click += new System.EventHandler(this.btnNumer_Click);
            // 
            // plMain
            // 
            this.plMain.Controls.Add(this.btnNumer);
            this.plMain.Controls.Add(this.label1);
            this.plMain.Controls.Add(this.listBox1);
            this.plMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMain.Location = new System.Drawing.Point(0, 24);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(800, 426);
            this.plMain.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.plMain);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.plMain.ResumeLayout(false);
            this.plMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 메뉴MToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 관리자GToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 종료XToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNumer;
        private System.Windows.Forms.Panel plMain;
    }
}

