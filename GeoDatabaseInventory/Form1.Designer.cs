namespace GeoDatabaseInventory
{
    partial class Inventory
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnFile = new System.Windows.Forms.Button();
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
            this.txtGeoDatabasePath.Location = new System.Drawing.Point(222, 125);
            this.txtGeoDatabasePath.Name = "txtGeoDatabasePath";
            this.txtGeoDatabasePath.Size = new System.Drawing.Size(201, 20);
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
            this.btnFCLoad.Location = new System.Drawing.Point(429, 176);
            this.btnFCLoad.Name = "btnFCLoad";
            this.btnFCLoad.Size = new System.Drawing.Size(128, 24);
            this.btnFCLoad.TabIndex = 12;
            this.btnFCLoad.Text = "Load Feature Classes";
            this.btnFCLoad.UseVisualStyleBackColor = true;
            this.btnFCLoad.Click += new System.EventHandler(this.btnFCLoad_Click);
            // 
            // cmbFC
            // 
            this.cmbFC.FormattingEnabled = true;
            this.cmbFC.Location = new System.Drawing.Point(222, 176);
            this.cmbFC.Name = "cmbFC";
            this.cmbFC.Size = new System.Drawing.Size(201, 21);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = " Features Count";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(218, 222);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(19, 20);
            this.lblCount.TabIndex = 16;
            this.lblCount.Text = "0";
            // 
            // btnFile
            // 
            this.btnFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFile.ForeColor = System.Drawing.Color.Black;
            this.btnFile.Location = new System.Drawing.Point(445, 125);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(97, 23);
            this.btnFile.TabIndex = 17;
            this.btnFile.Text = "Browse";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(564, 256);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label1);
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
            this.Name = "Inventory";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnFile;
    }
}

