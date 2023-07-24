namespace EmailClient.Panels
{
    partial class InboxPanel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.InboxListView = new System.Windows.Forms.ListView();
            this.Sender = new System.Windows.Forms.ColumnHeader();
            this.Subject = new System.Windows.Forms.ColumnHeader();
            this.Date = new System.Windows.Forms.ColumnHeader();
            this.CheckButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.GetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InboxListView
            // 
            this.InboxListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Sender,
            this.Subject,
            this.Date});
            this.InboxListView.Location = new System.Drawing.Point(102, 81);
            this.InboxListView.Name = "InboxListView";
            this.InboxListView.Size = new System.Drawing.Size(493, 361);
            this.InboxListView.TabIndex = 0;
            this.InboxListView.UseCompatibleStateImageBehavior = false;
            this.InboxListView.SelectedIndexChanged += new System.EventHandler(this.InboxListView_SelectedIndexChanged);
            // 
            // Sender
            // 
            this.Sender.Text = "发送者";
            this.Sender.Width = 150;
            // 
            // Subject
            // 
            this.Subject.Text = "主题";
            this.Subject.Width = 150;
            // 
            // Date
            // 
            this.Date.Text = "时间";
            this.Date.Width = 150;
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(292, 478);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(112, 34);
            this.CheckButton.TabIndex = 1;
            this.CheckButton.Text = "查看";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(483, 478);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(112, 34);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "删除";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // GetButton
            // 
            this.GetButton.Location = new System.Drawing.Point(102, 478);
            this.GetButton.Name = "GetButton";
            this.GetButton.Size = new System.Drawing.Size(112, 34);
            this.GetButton.TabIndex = 3;
            this.GetButton.Text = "获取";
            this.GetButton.UseVisualStyleBackColor = true;
            this.GetButton.Click += new System.EventHandler(this.GetButton_Click);
            // 
            // InboxPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GetButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CheckButton);
            this.Controls.Add(this.InboxListView);
            this.Name = "InboxPanel";
            this.Size = new System.Drawing.Size(697, 546);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView InboxListView;
        private Button CheckButton;
        private Button DeleteButton;
        private ColumnHeader Sender;
        private ColumnHeader Subject;
        private ColumnHeader Date;
        private Button GetButton;
    }
}
