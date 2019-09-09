﻿namespace MHRSProject
{
    partial class FrmMyAppointments
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
            this.txtCancelAppointment = new System.Windows.Forms.Button();
            this.txtNewAppointment = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCancelAppointment);
            this.panel1.Controls.Add(this.txtNewAppointment);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 45);
            this.panel1.TabIndex = 0;
           
            // 
            // txtCancelAppointment
            // 
            this.txtCancelAppointment.Location = new System.Drawing.Point(118, 12);
            this.txtCancelAppointment.Name = "txtCancelAppointment";
            this.txtCancelAppointment.Size = new System.Drawing.Size(100, 25);
            this.txtCancelAppointment.TabIndex = 1;
            this.txtCancelAppointment.Text = "Randevu İptal Et";
            this.txtCancelAppointment.UseVisualStyleBackColor = true;
            this.txtCancelAppointment.Click += new System.EventHandler(this.TxtCancelAppointment_Click);
            // 
            // txtNewAppointment
            // 
            this.txtNewAppointment.Location = new System.Drawing.Point(12, 12);
            this.txtNewAppointment.Name = "txtNewAppointment";
            this.txtNewAppointment.Size = new System.Drawing.Size(100, 25);
            this.txtNewAppointment.TabIndex = 0;
            this.txtNewAppointment.Text = "Yeni Randevu";
            this.txtNewAppointment.UseVisualStyleBackColor = true;
            this.txtNewAppointment.Click += new System.EventHandler(this.TxtNewAppointment_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(659, 346);
            this.dataGridView1.TabIndex = 1;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Id";
            this.Column6.HeaderText = "Randevu No";
            this.Column6.Name = "Column6";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Hour";
            this.Column1.HeaderText = "Randevu Tarihi";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "HospitalName";
            this.Column2.HeaderText = "Hastane";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "DepartmentName";
            this.Column3.HeaderText = "Bölüm";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DoctorName";
            this.Column4.HeaderText = "Doktor";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "IsCancelled";
            this.Column5.HeaderText = "İptal mi ?";
            this.Column5.Name = "Column5";
            // 
            // FrmMyAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 391);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMyAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Randevularım";
            this.Load += new System.EventHandler(this.FrmMyAppointments_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button txtCancelAppointment;
        private System.Windows.Forms.Button txtNewAppointment;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}