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
    public partial class FrmDoctorEdit : Form
    {
        public FrmDoctors MasterForm { get; set; }
        public int IdSelector { get; set; }
        
        public FrmDoctorEdit()
        {
            InitializeComponent();
        }


        private void BtnEdit_Click(object sender, EventArgs e)
        {
            using (var db=new ApplicationDbContext())
            {
                var doctoredit = db.Doctors.Where(x => x.Id == IdSelector).FirstOrDefault();
                if (doctoredit!=null)
                {
                    doctoredit.FirstName = txtFirstName.Text;
                    doctoredit.LastName = txtLastName.Text;
                    if (rbtMale.Checked)
                    {
                        doctoredit.Gender = Gender.Male;
                    }
                    else
                    {
                        doctoredit.Gender = Gender.Female;
                    }
                    doctoredit.HospitalId = ((Hospital)cmbHospital.SelectedItem).Id;
                    doctoredit.DepartmentId = ((Department)cmbDepartment.SelectedItem).Id;
                    db.SaveChanges();
                    MasterForm.RefreshDoctor();
                    
                    MessageBox.Show("- Başarıyla Güncellendi -");
                }
            }
        }

        private void FrmDoctorEdit_Load(object sender, EventArgs e)
        {
            HospitalLoad();
            if (IdSelector>0)
            {
                using (var db=new ApplicationDbContext())
                {
                    var transfer = db.Doctors.Where(x => x.Id == IdSelector).FirstOrDefault();
                    if (transfer!=null) //Sorgu Sonucu boş değilse
                    {
                        txtFirstName.Text = transfer.FirstName;
                        txtLastName.Text = transfer.LastName;
                        if (transfer.Gender == Gender.Male)
                        {
                            rbtMale.Checked = true;
                        }
                        else if (transfer.Gender == Gender.Female)
                        {
                            rbtFemale.Checked = true;
                        }
                        int index = 0;
                        foreach (var item in cmbHospital.Items)
                        {
                            if (((Hospital)item).Id==transfer.HospitalId)
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
                        index = 0;
                        foreach (var item in cmbDepartment.Items)
                        {
                            if (((Department)item).Id==transfer.DepartmentId)
                            {
                                break;
                            }
                            index++;
                            if (index>=cmbDepartment.Items.Count)
                            {
                                index = 0;
                            }
                        }
                        if (index>=cmbDepartment.Items.Count)
                        {
                            index = 0;
                        }
                        cmbDepartment.SelectedIndex = index;
                    }
                }
            }
            else
            {
                MessageBox.Show("HATA Var");
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepartmentLoad();
        }
    }
}
