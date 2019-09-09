namespace MHRSProject
{
    partial class FrmDoctors
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDoctorsEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDoctorsAdd = new System.Windows.Forms.Button();
            this.dgwDoctors = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwDoctors)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDoctorsEdit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnDoctorsAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 42);
            this.panel1.TabIndex = 0;
            // 
            // btnDoctorsEdit
            // 
            this.btnDoctorsEdit.Location = new System.Drawing.Point(93, 12);
            this.btnDoctorsEdit.Name = "btnDoctorsEdit";
            this.btnDoctorsEdit.Size = new System.Drawing.Size(75, 23);
            this.btnDoctorsEdit.TabIndex = 2;
            this.btnDoctorsEdit.Text = "Düzenle";
            this.btnDoctorsEdit.UseVisualStyleBackColor = true;
            this.btnDoctorsEdit.Click += new System.EventHandler(this.BtnDoctorsEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(174, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnDoctorsAdd
            // 
            this.btnDoctorsAdd.Location = new System.Drawing.Point(12, 12);
            this.btnDoctorsAdd.Name = "btnDoctorsAdd";
            this.btnDoctorsAdd.Size = new System.Drawing.Size(75, 23);
            this.btnDoctorsAdd.TabIndex = 0;
            this.btnDoctorsAdd.Text = "Ekle";
            this.btnDoctorsAdd.UseVisualStyleBackColor = true;
            this.btnDoctorsAdd.Click += new System.EventHandler(this.BtnDoctorsAdd_Click);
            // 
            // dgwDoctors
            // 
            this.dgwDoctors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwDoctors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgwDoctors.Location = new System.Drawing.Point(12, 48);
            this.dgwDoctors.Name = "dgwDoctors";
            this.dgwDoctors.Size = new System.Drawing.Size(635, 292);
            this.dgwDoctors.TabIndex = 1;
            this.dgwDoctors.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgwDoctors_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.HeaderText = "Doktor No";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "FirstName";
            this.Column2.HeaderText = "Ad";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "LastName";
            this.Column3.HeaderText = "Soyad";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Gender";
            this.Column4.HeaderText = "Cinsiyet";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "DepartmentId";
            this.Column5.HeaderText = "Bölüm";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "HospitalId";
            this.Column6.HeaderText = "Hastane";
            this.Column6.Name = "Column6";
            // 
            // FrmDoctors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 391);
            this.Controls.Add(this.dgwDoctors);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDoctors";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDoctors";
            this.Load += new System.EventHandler(this.FrmDoctors_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwDoctors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDoctorsEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDoctorsAdd;
        private System.Windows.Forms.DataGridView dgwDoctors;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}