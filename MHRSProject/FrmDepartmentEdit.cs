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
    public partial class FrmDepartmentEdit : Form
    {
        public FrmDepartments MasterForm { get; set; }
        public string GridId { get; set; }
        public FrmDepartmentEdit()
        {
            InitializeComponent();
        }

        private void FrmDepartmentEdit_Load(object sender, EventArgs e)
        {
            HospitalLoad();

            using (var db = new ApplicationDbContext())
            {
                int id = Convert.ToInt32(GridId);
                var department = db.Departments.Where(x => x.Id == id).FirstOrDefault();
                txtDepartmentName.Text = department.Name;
                int index = 0;
                foreach (var item in cmbHospital.Items)
                {
                    if (((Hospital)item).Id==department.HospitalId)
                    {
                        break;
                    }
                    index++;
                }
                if (index>=cmbHospital.Items.Count)
                {
                    index = 0;
                }
                cmbHospital.SelectedIndex = index;
                DepartmentLoad();
                index=0;
                foreach (var item in cmbParentDepartment.Items)
                {
                    if (((Department)item).Id==department.ParentDepartmentId)
                    {
                        break;
                    }
                    index++;
                }
                if (index>=cmbParentDepartment.Items.Count)
                {
                    index = 0;
                }
                cmbParentDepartment.SelectedIndex = index;
            }
            

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
                var department = db.Departments.Where(x => x.HospitalId == hospitalid).OrderBy(o => o.Name).ToList();
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

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (txtDepartmentName.Text==null)
            {
                MessageBox.Show("- Bölüm Adı Gereklidir -");
                return;
            }
            else if (((Hospital)cmbHospital.SelectedItem).Id==0)
            {
                MessageBox.Show("- Hastane Gereklidir -");
                return;
            }
            using (var db =new ApplicationDbContext())
            {
                int id = Convert.ToInt32(GridId);
                var edit = db.Departments.Where(x=>x.Id==id).FirstOrDefault();
                if (edit!=null)
                {
                    edit.Name = txtDepartmentName.Text;
                    edit.HospitalId = ((Hospital)cmbHospital.SelectedItem).Id;
                    if (((Department)cmbParentDepartment.SelectedItem).Id>0)
                    {
                        edit.ParentDepartmentId = ((Department)cmbParentDepartment.SelectedItem).Id;
                    }
                    else
                    {
                        edit.ParentDepartmentId = null;
                    }
                    db.SaveChanges();
                    MessageBox.Show("- Başarıyla Güncellendi -");
                }
                if (MasterForm != null)
                {
                    MasterForm.LoadDepartments();
                }

            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            if (MasterForm != null)
            {
                MasterForm.LoadDepartments();
            }

        }
    }
}
