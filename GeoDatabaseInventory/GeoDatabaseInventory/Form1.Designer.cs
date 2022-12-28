namespace GeoDatabaseInventory
{
    partial class InventoryMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryMain));
            this.txtTitle = new System.Windows.Forms.Label();
            this.GeoType = new System.Windows.Forms.Label();
            this.PathLabel = new System.Windows.Forms.Label();
            this.rdbPersonal = new System.Windows.Forms.RadioButton();
            this.rdbFile = new System.Windows.Forms.RadioButton();
            this.txtGeoDatabasePath = new System.Windows.Forms.TextBox();
            this.rdbSHP = new System.Windows.Forms.RadioButton();
            this.btnFCLoad = new System.Windows.Forms.Button();
            this.cmbFC = new System.Windows.Forms.ComboBox();
            this.txtFC = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.TextBox();
            this.CHLBOX = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_mapFile = new System.Windows.Forms.Button();
            this.FeatureAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.AutoSize = true;
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(166, 9);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(277, 29);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "Geo-database Counter";
            // 
            // GeoType
            // 
            this.GeoType.AutoSize = true;
            this.GeoType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeoType.Location = new System.Drawing.Point(12, 78);
            this.GeoType.Name = "GeoType";
            this.GeoType.Size = new System.Drawing.Size(197, 20);
            this.GeoType.TabIndex = 1;
            this.GeoType.Text = "Select GeoDatabase Type";
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PathLabel.Location = new System.Drawing.Point(12, 126);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(165, 20);
            this.PathLabel.TabIndex = 2;
            this.PathLabel.Text = "Path of GeoDatabase";
            // 
            // rdbPersonal
            // 
            this.rdbPersonal.AutoSize = true;
            this.rdbPersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPersonal.Location = new System.Drawing.Point(232, 78);
            this.rdbPersonal.Name = "rdbPersonal";
            this.rdbPersonal.Size = new System.Drawing.Size(112, 20);
            this.rdbPersonal.TabIndex = 4;
            this.rdbPersonal.TabStop = true;
            this.rdbPersonal.Text = "Personal GDB";
            this.rdbPersonal.UseVisualStyleBackColor = true;
            // 
            // rdbFile
            // 
            this.rdbFile.AutoSize = true;
            this.rdbFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbFile.Location = new System.Drawing.Point(363, 79);
            this.rdbFile.Name = "rdbFile";
            this.rdbFile.Size = new System.Drawing.Size(80, 20);
            this.rdbFile.TabIndex = 5;
            this.rdbFile.TabStop = true;
            this.rdbFile.Text = "File GDB";
            this.rdbFile.UseVisualStyleBackColor = true;
            // 
            // txtGeoDatabasePath
            // 
            this.txtGeoDatabasePath.Location = new System.Drawing.Point(183, 125);
            this.txtGeoDatabasePath.Name = "txtGeoDatabasePath";
            this.txtGeoDatabasePath.Size = new System.Drawing.Size(276, 20);
            this.txtGeoDatabasePath.TabIndex = 6;
            // 
            // rdbSHP
            // 
            this.rdbSHP.AutoSize = true;
            this.rdbSHP.Location = new System.Drawing.Point(467, 81);
            this.rdbSHP.Name = "rdbSHP";
            this.rdbSHP.Size = new System.Drawing.Size(75, 17);
            this.rdbSHP.TabIndex = 11;
            this.rdbSHP.TabStop = true;
            this.rdbSHP.Text = "Shape File";
            this.rdbSHP.UseVisualStyleBackColor = true;
            // 
            // btnFCLoad
            // 
            this.btnFCLoad.Location = new System.Drawing.Point(467, 168);
            this.btnFCLoad.Name = "btnFCLoad";
            this.btnFCLoad.Size = new System.Drawing.Size(106, 41);
            this.btnFCLoad.TabIndex = 12;
            this.btnFCLoad.Text = "Load Feature Classes";
            this.btnFCLoad.UseVisualStyleBackColor = true;
            this.btnFCLoad.Click += new System.EventHandler(this.btnFCLoad_Click);
            // 
            // cmbFC
            // 
            this.cmbFC.Enabled = false;
            this.cmbFC.FormattingEnabled = true;
            this.cmbFC.Location = new System.Drawing.Point(183, 176);
            this.cmbFC.Name = "cmbFC";
            this.cmbFC.Size = new System.Drawing.Size(276, 21);
            this.cmbFC.TabIndex = 13;
            this.cmbFC.SelectedIndexChanged += new System.EventHandler(this.cmbFC_SelectedIndexChanged);
            // 
            // txtFC
            // 
            this.txtFC.AutoSize = true;
            this.txtFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFC.Location = new System.Drawing.Point(12, 177);
            this.txtFC.Name = "txtFC";
            this.txtFC.Size = new System.Drawing.Size(157, 20);
            this.txtFC.TabIndex = 14;
            this.txtFC.Text = "Select Feature Class";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(504, 217);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(19, 20);
            this.lblCount.TabIndex = 16;
            this.lblCount.Text = "0";
            this.lblCount.Click += new System.EventHandler(this.lblCount_Click);
            // 
            // btnFile
            // 
            this.btnFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFile.ForeColor = System.Drawing.Color.Black;
            this.btnFile.Location = new System.Drawing.Point(467, 125);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(106, 23);
            this.btnFile.TabIndex = 17;
            this.btnFile.Text = "Browse";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(183, 350);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(102, 23);
            this.btnGenerateReport.TabIndex = 20;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblProgress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblProgress.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblProgress.Location = new System.Drawing.Point(0, 389);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblProgress.Size = new System.Drawing.Size(584, 16);
            this.lblProgress.TabIndex = 21;
            // 
            // CHLBOX
            // 
            this.CHLBOX.FormattingEnabled = true;
            this.CHLBOX.Location = new System.Drawing.Point(183, 217);
            this.CHLBOX.Name = "CHLBOX";
            this.CHLBOX.Size = new System.Drawing.Size(276, 109);
            this.CHLBOX.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Select Fields";
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(395, 350);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(64, 23);
            this.btnExit.TabIndex = 24;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(480, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Features";
            // 
            // btn_mapFile
            // 
            this.btn_mapFile.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_mapFile.Location = new System.Drawing.Point(304, 350);
            this.btn_mapFile.Name = "btn_mapFile";
            this.btn_mapFile.Size = new System.Drawing.Size(64, 23);
            this.btn_mapFile.TabIndex = 26;
            this.btn_mapFile.Text = "map File";
            this.btn_mapFile.UseVisualStyleBackColor = true;
            this.btn_mapFile.Click += new System.EventHandler(this.btn_mapFile_Click);
            // 
            // FeatureAdd
            // 
            this.FeatureAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.FeatureAdd.ForeColor = System.Drawing.Color.Black;
            this.FeatureAdd.Location = new System.Drawing.Point(467, 284);
            this.FeatureAdd.Name = "FeatureAdd";
            this.FeatureAdd.Size = new System.Drawing.Size(106, 42);
            this.FeatureAdd.TabIndex = 27;
            this.FeatureAdd.Text = "Add Feature To Report";
            this.FeatureAdd.UseVisualStyleBackColor = true;
            this.FeatureAdd.Click += new System.EventHandler(this.FeatureAdd_Click);
            // 
            // InventoryMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(583, 405);
            this.Controls.Add(this.FeatureAdd);
            this.Controls.Add(this.btn_mapFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CHLBOX);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtFC);
            this.Controls.Add(this.cmbFC);
            this.Controls.Add(this.btnFCLoad);
            this.Controls.Add(this.rdbSHP);
            this.Controls.Add(this.txtGeoDatabasePath);
            this.Controls.Add(this.rdbFile);
            this.Controls.Add(this.rdbPersonal);
            this.Controls.Add(this.PathLabel);
            this.Controls.Add(this.GeoType);
            this.Controls.Add(this.txtTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InventoryMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Geo-Summary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.Label GeoType;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.RadioButton rdbPersonal;
        private System.Windows.Forms.RadioButton rdbFile;
        private System.Windows.Forms.TextBox txtGeoDatabasePath;
        private System.Windows.Forms.RadioButton rdbSHP;
        private System.Windows.Forms.Button btnFCLoad;
        private System.Windows.Forms.ComboBox cmbFC;
        private System.Windows.Forms.Label txtFC;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.TextBox lblProgress;
        private System.Windows.Forms.CheckedListBox CHLBOX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_mapFile;
        private System.Windows.Forms.Button FeatureAdd;
    }
}

