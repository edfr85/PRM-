
namespace PRM_
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            this.KillTitmerBtn = new System.Windows.Forms.Button();
            this.AddRunListBtn = new System.Windows.Forms.Button();
            this.DelRunListBtn = new System.Windows.Forms.Button();
            this.DelKillListBtn = new System.Windows.Forms.Button();
            this.AddKillListBtn = new System.Windows.Forms.Button();
            this.LogTitle = new System.Windows.Forms.Button();
            this.RunTitle = new System.Windows.Forms.Button();
            this.KillTitle = new System.Windows.Forms.Button();
            this.lsvKill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lsvRun = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nIPRM = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsPRM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.중지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPRM.SuspendLayout();
            this.SuspendLayout();
            // 
            // KillTitmerBtn
            // 
            this.KillTitmerBtn.Location = new System.Drawing.Point(508, 372);
            this.KillTitmerBtn.Name = "KillTitmerBtn";
            this.KillTitmerBtn.Size = new System.Drawing.Size(332, 37);
            this.KillTitmerBtn.TabIndex = 19;
            this.KillTitmerBtn.Text = "중지";
            this.KillTitmerBtn.UseVisualStyleBackColor = true;
            this.KillTitmerBtn.Click += new System.EventHandler(this.KillTitmerBtn_Click);
            // 
            // AddRunListBtn
            // 
            this.AddRunListBtn.Location = new System.Drawing.Point(260, 372);
            this.AddRunListBtn.Name = "AddRunListBtn";
            this.AddRunListBtn.Size = new System.Drawing.Size(104, 37);
            this.AddRunListBtn.TabIndex = 18;
            this.AddRunListBtn.Text = "추가";
            this.AddRunListBtn.UseVisualStyleBackColor = true;
            this.AddRunListBtn.Click += new System.EventHandler(this.AddRunListBtn_Click);
            // 
            // DelRunListBtn
            // 
            this.DelRunListBtn.Location = new System.Drawing.Point(370, 372);
            this.DelRunListBtn.Name = "DelRunListBtn";
            this.DelRunListBtn.Size = new System.Drawing.Size(104, 37);
            this.DelRunListBtn.TabIndex = 17;
            this.DelRunListBtn.Text = "삭제";
            this.DelRunListBtn.UseVisualStyleBackColor = true;
            this.DelRunListBtn.Click += new System.EventHandler(this.DelRunListBtn_Click);
            // 
            // DelKillListBtn
            // 
            this.DelKillListBtn.Location = new System.Drawing.Point(119, 372);
            this.DelKillListBtn.Name = "DelKillListBtn";
            this.DelKillListBtn.Size = new System.Drawing.Size(104, 37);
            this.DelKillListBtn.TabIndex = 16;
            this.DelKillListBtn.Text = "삭제";
            this.DelKillListBtn.UseVisualStyleBackColor = true;
            this.DelKillListBtn.Click += new System.EventHandler(this.DelKillListBtn_Click);
            // 
            // AddKillListBtn
            // 
            this.AddKillListBtn.Location = new System.Drawing.Point(12, 372);
            this.AddKillListBtn.Name = "AddKillListBtn";
            this.AddKillListBtn.Size = new System.Drawing.Size(104, 37);
            this.AddKillListBtn.TabIndex = 15;
            this.AddKillListBtn.Text = "추가";
            this.AddKillListBtn.UseVisualStyleBackColor = true;
            this.AddKillListBtn.Click += new System.EventHandler(this.AddKillListBtn_Click);
            // 
            // LogTitle
            // 
            this.LogTitle.Location = new System.Drawing.Point(508, 12);
            this.LogTitle.Name = "LogTitle";
            this.LogTitle.Size = new System.Drawing.Size(332, 37);
            this.LogTitle.TabIndex = 14;
            this.LogTitle.Text = "Log";
            this.LogTitle.UseVisualStyleBackColor = true;
            // 
            // RunTitle
            // 
            this.RunTitle.Location = new System.Drawing.Point(260, 12);
            this.RunTitle.Name = "RunTitle";
            this.RunTitle.Size = new System.Drawing.Size(211, 37);
            this.RunTitle.TabIndex = 13;
            this.RunTitle.Text = "Run Process";
            this.RunTitle.UseVisualStyleBackColor = true;
            // 
            // KillTitle
            // 
            this.KillTitle.Location = new System.Drawing.Point(12, 12);
            this.KillTitle.Name = "KillTitle";
            this.KillTitle.Size = new System.Drawing.Size(211, 37);
            this.KillTitle.TabIndex = 12;
            this.KillTitle.Text = "Kill Process";
            this.KillTitle.UseVisualStyleBackColor = true;
            // 
            // lsvKill
            // 
            this.lsvKill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lsvKill.HideSelection = false;
            this.lsvKill.Location = new System.Drawing.Point(12, 55);
            this.lsvKill.Name = "lsvKill";
            this.lsvKill.Size = new System.Drawing.Size(211, 311);
            this.lsvKill.TabIndex = 21;
            this.lsvKill.UseCompatibleStateImageBehavior = false;
            this.lsvKill.View = System.Windows.Forms.View.Details;
            this.lsvKill.SelectedIndexChanged += new System.EventHandler(this.lsvKill_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Process";
            this.columnHeader1.Width = 207;
            // 
            // lsvRun
            // 
            this.lsvRun.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lsvRun.HideSelection = false;
            this.lsvRun.Location = new System.Drawing.Point(259, 53);
            this.lsvRun.Name = "lsvRun";
            this.lsvRun.Size = new System.Drawing.Size(211, 311);
            this.lsvRun.TabIndex = 22;
            this.lsvRun.UseCompatibleStateImageBehavior = false;
            this.lsvRun.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Process";
            this.columnHeader2.Width = 207;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(508, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 313);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // nIPRM
            // 
            this.nIPRM.Text = "notifyIcon1";
            this.nIPRM.Visible = true;
            this.nIPRM.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PrmIcon_MouseClick);
            this.nIPRM.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PrmIcon_MouseDoubleClick);
            // 
            // cmsPRM
            // 
            this.cmsPRM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.열기ToolStripMenuItem,
            this.중지ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.cmsPRM.Name = "cmsPRM";
            this.cmsPRM.Size = new System.Drawing.Size(99, 70);
            // 
            // 열기ToolStripMenuItem
            // 
            this.열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            this.열기ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.열기ToolStripMenuItem.Text = "열기";
            // 
            // 중지ToolStripMenuItem
            // 
            this.중지ToolStripMenuItem.Name = "중지ToolStripMenuItem";
            this.중지ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.중지ToolStripMenuItem.Text = "중지";
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 417);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lsvRun);
            this.Controls.Add(this.lsvKill);
            this.Controls.Add(this.KillTitmerBtn);
            this.Controls.Add(this.AddRunListBtn);
            this.Controls.Add(this.DelRunListBtn);
            this.Controls.Add(this.DelKillListBtn);
            this.Controls.Add(this.AddKillListBtn);
            this.Controls.Add(this.LogTitle);
            this.Controls.Add(this.RunTitle);
            this.Controls.Add(this.KillTitle);
            this.Name = "FrmMain";
            this.Text = "PRM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cmsPRM.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button KillTitmerBtn;
        private System.Windows.Forms.Button AddRunListBtn;
        private System.Windows.Forms.Button DelRunListBtn;
        public System.Windows.Forms.Button DelKillListBtn;
        private System.Windows.Forms.Button AddKillListBtn;
        private System.Windows.Forms.Button LogTitle;
        private System.Windows.Forms.Button RunTitle;
        private System.Windows.Forms.Button KillTitle;
        private System.Windows.Forms.ListView lsvKill;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lsvRun;
        public System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NotifyIcon nIPRM;
        private System.Windows.Forms.ContextMenuStrip cmsPRM;
        private System.Windows.Forms.ToolStripMenuItem 열기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 중지ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
    }
}

