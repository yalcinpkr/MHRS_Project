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

    public partial class FrmDoctors : Form
    {
        public int idfromsky;
        public FrmDoctors()
        {
            InitializeComponent();
        }

        private void BtnDoctorsAdd_Click(object sender, EventArgs e)
        {
            var frm = new FrmDoctorAdd();
            frm.MdiParent = this.MdiParent;
            frm.MasterForm = this;
            frm.Show();
        }

        private void FrmDoctors_Load(object sender, EventArgs e)
        {
            RefreshDoctor();
        }

        public void RefreshDoctor()
        {
            using (var db = new ApplicationDbContext())
            {

                var doctor = db.Doctors.Include("Department").Include("Hospital").OrderBy(x => x.FirstName).ThenBy(y => y.LastName).AsEnumerable().Select(z => new { Id = z.Id, FirstName = z.FirstName, LastName = z.LastName, Gender = z.Gender==Gender.Male?"Erkek":"Kadın", DepartmentId = z.Department.Name, HospitalId = z.Hospital.Name }).ToList();
                this.dgwDoctors.AutoGenerateColumns = false;
                dgwDoctors.DataSource = doctor;
            }
        }

        private void DgwDoctors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwDoctors.SelectedRows.Count > 0)
            {
                idfromsky = Convert.ToInt32(dgwDoctors.SelectedRows[0].Cells[0].Value);
            }
            else
            {
                MessageBox.Show("- Lütfen Doktor Seçiniz -");
            }
        }

        private void BtnDoctorsEdit_Click(object sender, EventArgs e)
        {

            var frm = new FrmDoctorEdit();
            frm.MdiParent = this.MdiParent;
            frm.IdSelector=idfromsky;
            frm.MasterForm = this;
            frm.Show();



        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgwDoctors.SelectedRows.Count>0)
            {
                using (var db=new ApplicationDbContext())
                {
                    DialogResult deletevalidate = new DialogResult();
                    deletevalidate = MessageBox.Show("Silmek İstediğinize Emin Misiniz ?", "Uyarı", MessageBoxButtons.YesNo);
                    if (deletevalidate==DialogResult.Yes)
                    {
                        var delete = db.Doctors.Where(q => q.Id == idfromsky).FirstOrDefault();
                        try
                        {
                            db.Doctors.Remove(delete);
                            db.SaveChanges();
                            RefreshDoctor();
                            MessageBox.Show("- Doktor Silindi -");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("- Doktor Aktif Randevuları Olduğu İçin Silinemiyor -" + ex.Message);

                        }
                       
                    }
                }
            }
            else
            {
                MessageBox.Show("- Lütfen Doktor Seçiniz -");
            }
        }
    }
}
