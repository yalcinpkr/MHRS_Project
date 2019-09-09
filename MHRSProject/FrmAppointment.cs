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
    public partial class FrmAppointment : Form
    {
        private FrmMyAppointments gridForm; // Burada Tanımladık
        public FrmAppointment(FrmMyAppointments gridForm)
        {
            this.gridForm = gridForm;
            InitializeComponent();
        }
        private void FrmAppointment_Load(object sender, EventArgs e)
        {
            //Form Yüklendiğinde Hastaneleri Yükle
            using (var db = new ApplicationDbContext())
            {
                var hospitals = db.Hospitals.OrderBy(o => o.Name).ToList();
                cmbHospital.DisplayMember = "Name";
                cmbHospital.ValueMember = "Id";
                cmbHospital.DataSource = hospitals;
                cmbHospital.SelectedIndex = -1;
                cmbHospital.Text = "-Hastane Seçiniz-";
                LoadDepartments();
            }

            //Randevu Saati combosunu temizle ve randevu saatlerini ekle
            cmbHour.Items.Clear();
            for (int i = 9; i <= 17; i++)
            {
                cmbHour.Items.Add(string.Format("{0:00}:00", i));
                if (i < 17)
                {
                    cmbHour.Items.Add(string.Format("{0:00}:30", i));
                }
            }
        }

        private void LoadDepartments()
        {
        using (var db = new ApplicationDbContext())
            {
                //Hastane combosunda aktif öğe null mı kontrol et , null değilse o hastanenin departmanlarını yükle
                int hospitalId = 0;
                if (cmbHospital.SelectedValue != null)
                {
                    hospitalId = (int)cmbHospital.SelectedValue;
                }

                var departments = db.Departments.Where(d => d.HospitalId == hospitalId).OrderBy(o => o.Name).ToList();
                cmbDepartment.DisplayMember = "Name";
                cmbDepartment.ValueMember = "Id";
                cmbDepartment.DataSource = departments;

                cmbDepartment.SelectedValue = -1;
                cmbDepartment.Text = "-Bölüm Seçiniz Seçiniz-";
                LoadDoctors();
            }
        }

        private void LoadDoctors()
        {
            using (var db = new ApplicationDbContext())
            {
                int departmentId = 0;

                if (cmbDepartment.SelectedValue != null)
                {
                    departmentId = (int)cmbDepartment.SelectedValue;
                }
                var doctors = db.Doctors.Where(z => z.DepartmentId == departmentId).OrderBy(o => o.FirstName).ThenBy(t => t.LastName).ToList();
                cmbDoctor.DisplayMember = "FullName";
                cmbDoctor.ValueMember = "Id";
                cmbDoctor.DataSource = doctors;

                cmbDoctor.SelectedValue = -1;
                cmbDoctor.Text = "-Doktor Seçiniz-";
            }
        }

        //Hastane combosundaki seçili öğre değiştiğinde 
        private void CmbHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDepartments();
        }

        private void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDoctors();
        }

        private void BtnInsertAppointment_Click(object sender, EventArgs e)
        {
            if (cmbHospital.SelectedValue == null)
            {
                MessageBox.Show("- Hastane Seçmelisiniz -");
            }
           else if (cmbDepartment.SelectedValue == null)
            {
                MessageBox.Show("- Bölüm Seçmelisiniz -");
            }
           else if (cmbDoctor.SelectedValue == null)
            {
                MessageBox.Show("- Doktor Seçmelisiniz -");
            }
           else if (string.IsNullOrEmpty(cmbHour.Text))
            {
                MessageBox.Show("- Randevu Saati Seçmelisiniz -");
            }
            using (var db = new ApplicationDbContext())
            {
                var UserId = ((FrmMain)this.MdiParent).ActiveUser.Id;  //Kullanıcının bilgiler ana formda var

                var appo = new Appointment();
                appo.PatientId = UserId;
                appo.DoctorId = (int)cmbDoctor.SelectedValue;
                appo.IsCancelled = false;
                appo.HospitalId = (int)cmbHospital.SelectedValue;
                appo.DepartmentId = (int)cmbDepartment.SelectedValue;
                appo.Hour =Convert.ToDateTime(dateTimePicker1.Text + cmbHour.Text);
                db.Appointments.Add(appo);
                db.SaveChanges();
                MessageBox.Show("- Randevu Başarıyla Kaydedildi -");
                gridForm.RefreshGrid();
                this.Close();

            }
        }


    }
}
