namespace 排赛程
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.NotSeed = new System.Windows.Forms.TextBox();
            this.Seed = new System.Windows.Forms.TextBox();
            this.GroupNumber = new System.Windows.Forms.ComboBox();
            this.Create = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.notSeedNum = new System.Windows.Forms.Label();
            this.seedNum = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label1.Location = new System.Drawing.Point(2, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(266, 48);
            label1.TabIndex = 1;
            label1.Text = "在下方输入非种子选手名单（以换行符隔开）";
            label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label2.Location = new System.Drawing.Point(274, 15);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(246, 48);
            label2.TabIndex = 2;
            label2.Text = "在下方输入种子选手名单（以换行符隔开）";
            label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label3.Location = new System.Drawing.Point(59, 398);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(172, 25);
            label3.TabIndex = 4;
            label3.Text = "选择小组的数量";
            label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NotSeed
            // 
            this.NotSeed.AcceptsReturn = true;
            this.NotSeed.AcceptsTab = true;
            this.NotSeed.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.NotSeed.AllowDrop = true;
            this.NotSeed.Location = new System.Drawing.Point(13, 75);
            this.NotSeed.Multiline = true;
            this.NotSeed.Name = "NotSeed";
            this.NotSeed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.NotSeed.Size = new System.Drawing.Size(245, 278);
            this.NotSeed.TabIndex = 0;
            this.NotSeed.TextChanged += new System.EventHandler(this.NotSeed_TextChanged);
            // 
            // Seed
            // 
            this.Seed.AcceptsReturn = true;
            this.Seed.AcceptsTab = true;
            this.Seed.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.Seed.AllowDrop = true;
            this.Seed.Location = new System.Drawing.Point(278, 75);
            this.Seed.Multiline = true;
            this.Seed.Name = "Seed";
            this.Seed.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Seed.Size = new System.Drawing.Size(245, 278);
            this.Seed.TabIndex = 3;
            this.Seed.TextChanged += new System.EventHandler(this.Seed_TextChanged);
            // 
            // GroupNumber
            // 
            this.GroupNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupNumber.FormattingEnabled = true;
            this.GroupNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GroupNumber.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "24",
            "32"});
            this.GroupNumber.Location = new System.Drawing.Point(87, 429);
            this.GroupNumber.Name = "GroupNumber";
            this.GroupNumber.Size = new System.Drawing.Size(103, 23);
            this.GroupNumber.TabIndex = 5;
            this.GroupNumber.SelectedIndexChanged += new System.EventHandler(this.GroupNumber_SelectedIndexChanged);
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(334, 398);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(134, 41);
            this.Create.TabIndex = 6;
            this.Create.Text = "生成分组及对阵";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(232, 454);
            this.label4.MinimumSize = new System.Drawing.Size(160, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(303, 38);
            this.label4.TabIndex = 7;
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label4.Visible = false;
            // 
            // notSeedNum
            // 
            this.notSeedNum.AutoSize = true;
            this.notSeedNum.Location = new System.Drawing.Point(13, 360);
            this.notSeedNum.Name = "notSeedNum";
            this.notSeedNum.Size = new System.Drawing.Size(84, 15);
            this.notSeedNum.TabIndex = 8;
            this.notSeedNum.Text = "共 0 人/队";
            // 
            // seedNum
            // 
            this.seedNum.AutoSize = true;
            this.seedNum.Location = new System.Drawing.Point(275, 360);
            this.seedNum.Name = "seedNum";
            this.seedNum.Size = new System.Drawing.Size(84, 15);
            this.seedNum.TabIndex = 9;
            this.seedNum.Text = "共 0 人/队";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 501);
            this.Controls.Add(this.seedNum);
            this.Controls.Add(this.notSeedNum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.GroupNumber);
            this.Controls.Add(label3);
            this.Controls.Add(this.Seed);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.NotSeed);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(565, 548);
            this.MinimumSize = new System.Drawing.Size(565, 548);
            this.Name = "Form1";
            this.Text = "排赛程";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NotSeed;
        private System.Windows.Forms.TextBox Seed;
        private System.Windows.Forms.ComboBox GroupNumber;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label notSeedNum;
        private System.Windows.Forms.Label seedNum;
    }
}

