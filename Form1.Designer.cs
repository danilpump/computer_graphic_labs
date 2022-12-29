namespace computer_graphic_labs
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.binarizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.niblackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalhistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noiseModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noiseEmulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pSNRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sSIMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uniformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bilateralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.binarizationToolStripMenuItem,
            this.noiseModToolStripMenuItem,
            this.noiseEmulationToolStripMenuItem,
            this.pSNRToolStripMenuItem,
            this.sSIMToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(810, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(373, 326);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(424, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(373, 326);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // binarizationToolStripMenuItem
            // 
            this.binarizationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointToolStripMenuItem,
            this.niblackToolStripMenuItem,
            this.globalhistToolStripMenuItem});
            this.binarizationToolStripMenuItem.Name = "binarizationToolStripMenuItem";
            this.binarizationToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.binarizationToolStripMenuItem.Text = "Binarization";
            // 
            // pointToolStripMenuItem
            // 
            this.pointToolStripMenuItem.Name = "pointToolStripMenuItem";
            this.pointToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pointToolStripMenuItem.Text = "Point";
            this.pointToolStripMenuItem.Click += new System.EventHandler(this.pointToolStripMenuItem_Click);
            // 
            // niblackToolStripMenuItem
            // 
            this.niblackToolStripMenuItem.Name = "niblackToolStripMenuItem";
            this.niblackToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.niblackToolStripMenuItem.Text = "Niblack";
            this.niblackToolStripMenuItem.Click += new System.EventHandler(this.niblackToolStripMenuItem_Click);
            // 
            // globalhistToolStripMenuItem
            // 
            this.globalhistToolStripMenuItem.Name = "globalhistToolStripMenuItem";
            this.globalhistToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.globalhistToolStripMenuItem.Text = "Global (hist)";
            this.globalhistToolStripMenuItem.Click += new System.EventHandler(this.globalhistToolStripMenuItem_Click);
            // 
            // noiseModToolStripMenuItem
            // 
            this.noiseModToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gaussToolStripMenuItem,
            this.uniformToolStripMenuItem});
            this.noiseModToolStripMenuItem.Name = "noiseModToolStripMenuItem";
            this.noiseModToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.noiseModToolStripMenuItem.Text = "Noise simulation";
            // 
            // noiseEmulationToolStripMenuItem
            // 
            this.noiseEmulationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.medianToolStripMenuItem,
            this.bilateralToolStripMenuItem});
            this.noiseEmulationToolStripMenuItem.Name = "noiseEmulationToolStripMenuItem";
            this.noiseEmulationToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.noiseEmulationToolStripMenuItem.Text = "Noise elimination";
            // 
            // pSNRToolStripMenuItem
            // 
            this.pSNRToolStripMenuItem.Name = "pSNRToolStripMenuItem";
            this.pSNRToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.pSNRToolStripMenuItem.Text = "PSNR";
            this.pSNRToolStripMenuItem.Click += new System.EventHandler(this.pSNRToolStripMenuItem_Click);
            // 
            // sSIMToolStripMenuItem
            // 
            this.sSIMToolStripMenuItem.Name = "sSIMToolStripMenuItem";
            this.sSIMToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.sSIMToolStripMenuItem.Text = "SSIM";
            this.sSIMToolStripMenuItem.Click += new System.EventHandler(this.sSIMToolStripMenuItem_Click);
            // 
            // gaussToolStripMenuItem
            // 
            this.gaussToolStripMenuItem.Name = "gaussToolStripMenuItem";
            this.gaussToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gaussToolStripMenuItem.Text = "Gauss";
            this.gaussToolStripMenuItem.Click += new System.EventHandler(this.gaussToolStripMenuItem_Click);
            // 
            // uniformToolStripMenuItem
            // 
            this.uniformToolStripMenuItem.Name = "uniformToolStripMenuItem";
            this.uniformToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uniformToolStripMenuItem.Text = "Uniform";
            this.uniformToolStripMenuItem.Click += new System.EventHandler(this.uniformToolStripMenuItem_Click);
            // 
            // medianToolStripMenuItem
            // 
            this.medianToolStripMenuItem.Name = "medianToolStripMenuItem";
            this.medianToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.medianToolStripMenuItem.Text = "Median";
            this.medianToolStripMenuItem.Click += new System.EventHandler(this.medianToolStripMenuItem_Click);
            // 
            // bilateralToolStripMenuItem
            // 
            this.bilateralToolStripMenuItem.Name = "bilateralToolStripMenuItem";
            this.bilateralToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bilateralToolStripMenuItem.Text = "Bilateral";
            this.bilateralToolStripMenuItem.Click += new System.EventHandler(this.bilateralToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 368);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem binarizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem niblackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem globalhistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noiseModToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uniformToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noiseEmulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bilateralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pSNRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sSIMToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

