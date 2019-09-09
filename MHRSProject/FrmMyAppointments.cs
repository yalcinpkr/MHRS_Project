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
    public partial class FrmMyAppointments : Form
    {
        public FrmMyAppointments()
        {
            InitializeComponent();
        }

        private void FrmMyAppointments_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        public void RefreshGrid()
        {
            var userId = ((FrmMain)this.MdiParent).ActiveUser.Id;

            using (var db = new ApplicationDbContext())
            {
                var myappointments = db.Appointments.Include("Hospital").Include("Department").Include("Doctor").Where(a => a.PatientId == userId).OrderBy(o => o.Hour).AsEnumerable().Select(x => new { Id = x.Id, Hour = x.Hour, HospitalName = x.Hospital.Name, DepartmentName = x.Department.Name, DoctorName = x.Doctor.FullName, IsCancelled = x.IsCancelled }).ToList();
                this.dataGridView1.AutoGenerateColumns = false;
                this.dataGridView1.DataSource = myappointments;
            }
        }

        private void TxtNewAppointment_Click(object sender, EventArgs e)
        {
            FrmAppointment frm = new FrmAppointment(this);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void TxtCancelAppointment_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                int selectedAppointmentsId = int.Parse(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                using (var db=new ApplicationDbContext())
                {
                    var appointment = db.Appointments.FirstOrDefault(x => x.Id == selectedAppointmentsId);

                    if (appointment!=null) //Error Prom Code olmaması için kontrol ettik
                    {
                        DialogResult res = MessageBox.Show("İptal Etmek İstediğinize Emin Misiniz ?", "Randevu İptal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res==DialogResult.Yes)
                        {
                            appointment.IsCancelled = true;
                            db.SaveChanges();
                            MessageBox.Show("- Seçtiğiniz Randevu İptal Edildi -");
                            RefreshGrid();
                        }
                    }
                    else
                    {
                        MessageBox.Show("- Seçili Randevu Bulunamadı -");
                    }
                }
            }
            else
            {
                MessageBox.Show("- Lütfen İptal Etmek İstediğiniz Randevuyu Seçiniz -");
            }
        }

    
    }
}
