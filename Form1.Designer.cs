
namespace 工具
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SendRequestBtn = new System.Windows.Forms.Button();
            this.OpenConfigBtn = new System.Windows.Forms.Button();
            this.dateshow = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.showDetailBtn = new System.Windows.Forms.Button();
            this.SwitchMode = new System.Windows.Forms.Button();
            this.configPathLabel = new System.Windows.Forms.Label();
            this.configPathtxt = new System.Windows.Forms.TextBox();
            this.CheckstatusLabel = new System.Windows.Forms.Label();
            this.AutoSave = new System.Windows.Forms.CheckBox();
            this.Result_dgv = new System.Windows.Forms.DataGridView();
            this.addConfigBtn = new System.Windows.Forms.Button();
            this.EngineTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.appKeyTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Config_dgv = new System.Windows.Forms.DataGridView();
            this.Configchecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chooseToolCbx = new System.Windows.Forms.ComboBox();
            this.chooseEnviromentCbx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Result_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Config_dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SendRequestBtn
            // 
            this.SendRequestBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SendRequestBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SendRequestBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SendRequestBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.SendRequestBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.SendRequestBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.SendRequestBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendRequestBtn.Location = new System.Drawing.Point(69, 12);
            this.SendRequestBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SendRequestBtn.Name = "SendRequestBtn";
            this.SendRequestBtn.Size = new System.Drawing.Size(107, 46);
            this.SendRequestBtn.TabIndex = 0;
            this.SendRequestBtn.Text = "查询";
            this.SendRequestBtn.UseVisualStyleBackColor = false;
            this.SendRequestBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // OpenConfigBtn
            // 
            this.OpenConfigBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OpenConfigBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.OpenConfigBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OpenConfigBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.OpenConfigBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.OpenConfigBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.OpenConfigBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenConfigBtn.Location = new System.Drawing.Point(663, 12);
            this.OpenConfigBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OpenConfigBtn.Name = "OpenConfigBtn";
            this.OpenConfigBtn.Size = new System.Drawing.Size(107, 46);
            this.OpenConfigBtn.TabIndex = 1;
            this.OpenConfigBtn.Text = "打开配置文件";
            this.OpenConfigBtn.UseVisualStyleBackColor = false;
            this.OpenConfigBtn.Click += new System.EventHandler(this.OpenConfigBtn_Click);
            // 
            // dateshow
            // 
            this.dateshow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateshow.AutoSize = true;
            this.dateshow.Location = new System.Drawing.Point(26, 9);
            this.dateshow.Name = "dateshow";
            this.dateshow.Size = new System.Drawing.Size(59, 12);
            this.dateshow.TabIndex = 2;
            this.dateshow.Text = "查询时间:";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // showDetailBtn
            // 
            this.showDetailBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.showDetailBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.showDetailBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.showDetailBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.showDetailBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.showDetailBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.showDetailBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showDetailBtn.Location = new System.Drawing.Point(267, 12);
            this.showDetailBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showDetailBtn.Name = "showDetailBtn";
            this.showDetailBtn.Size = new System.Drawing.Size(107, 46);
            this.showDetailBtn.TabIndex = 11;
            this.showDetailBtn.Text = "显示详细";
            this.showDetailBtn.UseVisualStyleBackColor = false;
            this.showDetailBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // SwitchMode
            // 
            this.SwitchMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SwitchMode.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SwitchMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SwitchMode.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.SwitchMode.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.SwitchMode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.SwitchMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SwitchMode.Location = new System.Drawing.Point(465, 12);
            this.SwitchMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SwitchMode.Name = "SwitchMode";
            this.SwitchMode.Size = new System.Drawing.Size(107, 46);
            this.SwitchMode.TabIndex = 13;
            this.SwitchMode.Text = "全选/全不选";
            this.SwitchMode.UseVisualStyleBackColor = false;
            this.SwitchMode.Click += new System.EventHandler(this.SwitchMode_Click);
            // 
            // configPathLabel
            // 
            this.configPathLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.configPathLabel.Location = new System.Drawing.Point(56, 25);
            this.configPathLabel.Name = "configPathLabel";
            this.configPathLabel.Size = new System.Drawing.Size(112, 29);
            this.configPathLabel.TabIndex = 14;
            this.configPathLabel.Text = "当前配置文件路径:";
            this.configPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // configPathtxt
            // 
            this.configPathtxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.configPathtxt.Location = new System.Drawing.Point(174, 30);
            this.configPathtxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.configPathtxt.Name = "configPathtxt";
            this.configPathtxt.Size = new System.Drawing.Size(508, 21);
            this.configPathtxt.TabIndex = 15;
            // 
            // CheckstatusLabel
            // 
            this.CheckstatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckstatusLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F);
            this.CheckstatusLabel.ForeColor = System.Drawing.Color.LightCoral;
            this.CheckstatusLabel.Location = new System.Drawing.Point(767, 21);
            this.CheckstatusLabel.Name = "CheckstatusLabel";
            this.CheckstatusLabel.Size = new System.Drawing.Size(123, 30);
            this.CheckstatusLabel.TabIndex = 20;
            this.CheckstatusLabel.Text = "查询成功！";
            this.CheckstatusLabel.Visible = false;
            // 
            // AutoSave
            // 
            this.AutoSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AutoSave.AutoSize = true;
            this.AutoSave.Checked = true;
            this.AutoSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoSave.Location = new System.Drawing.Point(686, 9);
            this.AutoSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AutoSave.Name = "AutoSave";
            this.AutoSave.Size = new System.Drawing.Size(96, 16);
            this.AutoSave.TabIndex = 21;
            this.AutoSave.Text = "是否自动保存";
            this.AutoSave.UseVisualStyleBackColor = true;
            // 
            // Result_dgv
            // 
            this.Result_dgv.AllowUserToAddRows = false;
            this.Result_dgv.AllowUserToOrderColumns = true;
            this.Result_dgv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Result_dgv.BackgroundColor = System.Drawing.Color.White;
            this.Result_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Result_dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.Result_dgv.Location = new System.Drawing.Point(28, 460);
            this.Result_dgv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Result_dgv.Name = "Result_dgv";
            this.Result_dgv.RowTemplate.Height = 25;
            this.Result_dgv.Size = new System.Drawing.Size(834, 256);
            this.Result_dgv.TabIndex = 22;
            this.Result_dgv.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // addConfigBtn
            // 
            this.addConfigBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addConfigBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addConfigBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.addConfigBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.addConfigBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.addConfigBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addConfigBtn.Location = new System.Drawing.Point(567, 74);
            this.addConfigBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addConfigBtn.Name = "addConfigBtn";
            this.addConfigBtn.Size = new System.Drawing.Size(99, 42);
            this.addConfigBtn.TabIndex = 27;
            this.addConfigBtn.Text = "添加查询";
            this.addConfigBtn.UseVisualStyleBackColor = true;
            this.addConfigBtn.Click += new System.EventHandler(this.addConfigBtn_Click);
            // 
            // EngineTxt
            // 
            this.EngineTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EngineTxt.Location = new System.Drawing.Point(356, 96);
            this.EngineTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EngineTxt.Name = "EngineTxt";
            this.EngineTxt.Size = new System.Drawing.Size(164, 21);
            this.EngineTxt.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "Unity版本：";
            // 
            // appKeyTxt
            // 
            this.appKeyTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.appKeyTxt.Location = new System.Drawing.Point(85, 97);
            this.appKeyTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.appKeyTxt.Name = "appKeyTxt";
            this.appKeyTxt.Size = new System.Drawing.Size(164, 21);
            this.appKeyTxt.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "appKey：";
            // 
            // Config_dgv
            // 
            this.Config_dgv.AllowUserToAddRows = false;
            this.Config_dgv.AllowUserToOrderColumns = true;
            this.Config_dgv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Config_dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Config_dgv.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Config_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Config_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Configchecked});
            this.Config_dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.Config_dgv.Location = new System.Drawing.Point(28, 66);
            this.Config_dgv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Config_dgv.Name = "Config_dgv";
            this.Config_dgv.RowTemplate.Height = 25;
            this.Config_dgv.Size = new System.Drawing.Size(831, 245);
            this.Config_dgv.TabIndex = 28;
            this.Config_dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Config_dgv_CellContentClick);
            this.Config_dgv.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Config_dgv_RowsAdded);
            this.Config_dgv.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.Config_dgv_UserDeletedRow);
            // 
            // Configchecked
            // 
            this.Configchecked.FalseValue = "False";
            this.Configchecked.HeaderText = "是否勾选";
            this.Configchecked.MinimumWidth = 10;
            this.Configchecked.Name = "Configchecked";
            this.Configchecked.TrueValue = "True";
            this.Configchecked.Width = 60;
            // 
            // chooseToolCbx
            // 
            this.chooseToolCbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chooseToolCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chooseToolCbx.FormattingEnabled = true;
            this.chooseToolCbx.Items.AddRange(new object[] {
            "安装包分析工具",
            "规则检查工具"});
            this.chooseToolCbx.Location = new System.Drawing.Point(85, 69);
            this.chooseToolCbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chooseToolCbx.Name = "chooseToolCbx";
            this.chooseToolCbx.Size = new System.Drawing.Size(164, 20);
            this.chooseToolCbx.TabIndex = 29;
            // 
            // chooseEnviromentCbx
            // 
            this.chooseEnviromentCbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chooseEnviromentCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chooseEnviromentCbx.FormattingEnabled = true;
            this.chooseEnviromentCbx.Items.AddRange(new object[] {
            "1.测试环境",
            "2.正式环境",
            "3.外网环境"});
            this.chooseEnviromentCbx.Location = new System.Drawing.Point(356, 70);
            this.chooseEnviromentCbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chooseEnviromentCbx.Name = "chooseEnviromentCbx";
            this.chooseEnviromentCbx.Size = new System.Drawing.Size(164, 20);
            this.chooseEnviromentCbx.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "选择工具：";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "选择环境：";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(706, 72);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 42);
            this.button1.TabIndex = 33;
            this.button1.Text = "修改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.showDetailBtn);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.OpenConfigBtn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.SendRequestBtn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.SwitchMode);
            this.panel1.Controls.Add(this.chooseEnviromentCbx);
            this.panel1.Controls.Add(this.chooseToolCbx);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.appKeyTxt);
            this.panel1.Controls.Add(this.addConfigBtn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.EngineTxt);
            this.panel1.Location = new System.Drawing.Point(28, 334);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 121);
            this.panel1.TabIndex = 34;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(911, 742);
            this.Controls.Add(this.Config_dgv);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Result_dgv);
            this.Controls.Add(this.AutoSave);
            this.Controls.Add(this.CheckstatusLabel);
            this.Controls.Add(this.configPathtxt);
            this.Controls.Add(this.configPathLabel);
            this.Controls.Add(this.dateshow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DLL批量检查工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Result_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Config_dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendRequestBtn;
        private System.Windows.Forms.Button OpenConfigBtn;
        private System.Windows.Forms.Label dateshow;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button showDetailBtn;
        private System.Windows.Forms.Button SwitchMode;
        private System.Windows.Forms.Label configPathLabel;
        private System.Windows.Forms.TextBox configPathtxt;
        private System.Windows.Forms.Label CheckstatusLabel;
        private System.Windows.Forms.CheckBox AutoSave;
        private System.Windows.Forms.DataGridView Result_dgv;
        private System.Windows.Forms.Button addConfigBtn;
        private System.Windows.Forms.TextBox EngineTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox appKeyTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Config_dgv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox chooseEnviromentCbx;
        private System.Windows.Forms.ComboBox chooseToolCbx;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Configchecked;
        private System.Windows.Forms.Panel panel1;
    }
}

