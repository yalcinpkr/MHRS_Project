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
    public partial class FrmDoctorAdd : Form
    {
        public FrmDoctors MasterForm{get;set;}
        public FrmDoctorAdd()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text=="")
            {
                MessageBox.Show("- Lütfen Adınızı Giriniz -");
                return;
            }
            else if (txtLastName.Text=="")
            {
                MessageBox.Show("- Lütfen Soyadınızı Giriniz -");
                return;
            }
            else if (!rbtMale.Checked && !rbtFemale.Checked)
            {
                MessageBox.Show("- Lütfen Cinsiyetinizi Giriniz -");
                return;
            }
            else if (cmbHospital.SelectedIndex==0)
            {
                MessageBox.Show("- Lütfen Hastane Seçiniz -");
                return;
            }
            else if (((Department)cmbDepartment.SelectedItem).Id==0)
            {
                MessageBox.Show("- Lütfen Bölüm Seçiniz -");
                return;
            }
            using (var db=new ApplicationDbContext())
            {
                var doctor = new Doctor();
                doctor.FirstName = txtFirstName.Text;
                doctor.LastName = txtLastName.Text;
                if (rbtMale.Checked)
                {
                    doctor.Gender = Gender.Male;
                }
                else
                {
                    doctor.Gender = Gender.Female;
                }
                doctor.HospitalId=(((Department)cmbDepartment.SelectedItem).HospitalId); 
                doctor.DepartmentId = ((Department)cmbDepartment.SelectedItem).Id;
               
                db.Doctors.Add(doctor);
                db.SaveChanges();
                MasterForm.RefreshDoctor();
               
                MessageBox.Show("- Başarıyla Eklendi -");
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
                cmbDepartment.Items.Clear();
                cmbDepartment.Items.Add(new Department() { Name = "Üst Bölüm Seçiniz", Id = 0 });
                cmbDepartment.DisplayMember = "Name";
                cmbDepartment.ValueMember = "Id";
                foreach (var item in department)
                {
                    cmbDepartment.Items.Add(item);
                }

                cmbDepartment.SelectedIndex = 0;
            }
        }

        private void FrmDoctorAdd_Load(object sender, EventArgs e)
        {
            HospitalLoad();
          
        }

        private void CmbHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepartmentLoad();
        }
    }
}
