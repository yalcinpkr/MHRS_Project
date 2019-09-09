using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MHRSProject
{
    public partial class FrmDepartmentAdd : Form
    {
        public FrmDepartments MasterForm { get; set; }
        public FrmDepartmentAdd()
        {
            InitializeComponent();
        }

        private void FrmDepartmentAdd_Load(object sender, EventArgs e)
        {
            HospitalLoad();
        }

        private void HospitalLoad()
        {
            using (var db = new ApplicationDbContext())
            {
                var hospitals = db.Hospitals.OrderBy(o => o.Name).ToList();
                cmbHospital.Items.Clear();
                cmbHospital.Items.Add(new Hospital() { Name = "Hastane Seçiniz", Id = 0 });
                cmbHospital.DisplayMember = "Name";
                cmbHospital.ValueMember = "Id";
                foreach (var item in hospitals)
                {
                    cmbHospital.Items.Add(item);
                }
                cmbHospital.SelectedIndex = 0;
            }
        }

        private void DepartmentLoad()
        {
            using (var db = new ApplicationDbContext())
            {
                int hospitalid = ((Hospital)cmbHospital.SelectedItem).Id;
                var department = db.Departments.Where(x=>x.HospitalId==hospitalid).OrderBy(o => o.Name).ToList();
                cmbParentDepartment.Items.Clear();
                cmbParentDepartment.Items.Add(new Department() { Name = "Üst Bölüm Seçiniz", Id = 0 });
                cmbParentDepartment.DisplayMember = "Name";
                cmbParentDepartment.ValueMember = "Id";
                foreach (var item in department)
                {
                    cmbParentDepartment.Items.Add(item);
                }

                cmbParentDepartment.SelectedIndex = 0;
            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtDepartmentName.Text == "")
            {
                MessageBox.Show("- Bölüm Adı Gereklidir -");
            }
            if (((Hospital)cmbHospital.SelectedItem).Id == 0)
            {
                MessageBox.Show("- Hastane Gereklidir -");
                return;
            }

            using (var db = new ApplicationDbContext())
            {
                var departmentadd = new Department();
                departmentadd.Name = txtDepartmentName.Text;
                departmentadd.HospitalId = ((Hospital)cmbHospital.SelectedItem).Id;
                if (((Department)cmbParentDepartment.SelectedItem).Id > 0)
                {
                    departmentadd.ParentDepartmentId = ((Department)cmbParentDepartment.SelectedItem).Id;
                }
                db.Departments.Add(departmentadd);
                db.SaveChanges();
                MessageBox.Show("- Bölüm Eklendi -");
                if (MasterForm != null)
                {
                    MasterForm.LoadDepartments();
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (MasterForm != null)
            {
                MasterForm.LoadDepartments();
                this.Close();
            }
        }

        private void CmbHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepartmentLoad();
        }
    }
}
