namespace EmailClient.Panels
{
    partial class OutboxPanel
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
            this.DeleteButton = new System.Windows.Forms.Button();
            this.CheckButton = new System.Windows.Forms.Button();
            this.OutboxListView = new System.Windows.Forms.ListView();
            this.Receiver = new System.Windows.Forms.ColumnHeader();
            this.Subject = new System.Windows.Forms.ColumnHeader();
            this.Date = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(419, 470);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(112, 34);
            this.DeleteButton.TabIndex = 5;
            this.DeleteButton.Text = "删除";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(167, 470);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(112, 34);
            this.CheckButton.TabIndex = 4;
            this.CheckButton.Text = "查看";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // OutboxListView
            // 
            this.OutboxListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Receiver,
            this.Subject,
            this.Date});
            this.OutboxListView.Location = new System.Drawing.Point(102, 81);
            this.OutboxListView.Name = "OutboxListView";
            this.OutboxListView.Size = new System.Drawing.Size(493, 361);
            this.OutboxListView.TabIndex = 6;
            this.OutboxListView.UseCompatibleStateImageBehavior = false;
            this.OutboxListView.SelectedIndexChanged += new System.EventHandler(this.OutboxListView_SelectedIndexChanged_1);
            // 
            // Receiver
            // 
            this.Receiver.Text = "接收者";
            this.Receiver.Width = 150;
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
            // OutboxPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OutboxListView);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CheckButton);
            this.Name = "OutboxPanel";
            this.Size = new System.Drawing.Size(697, 546);
            this.ResumeLayout(false);

        }

        #endregion

        private Button DeleteButton;
        private Button CheckButton;
        private ListView OutboxListView;
        private ColumnHeader Receiver;
        private ColumnHeader Subject;
        private ColumnHeader Date;
    }
}
