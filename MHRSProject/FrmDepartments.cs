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
    public partial class FrmDepartments : Form
    {
        string idfromsky;
        public FrmDepartments()
        {
            InitializeComponent();
        }

        private void FrmDepartments_Load(object sender, EventArgs e)
        {
            LoadDepartments();
        }

        public void LoadDepartments()
        {
            using (var db = new ApplicationDbContext())
            {
                var department = db.Departments.OrderBy(x => x.Name).Select(s => new { s.Id, s.Name, ParentName = (s.ParentDepartment != null ? s.ParentDepartment.Name : ""), HospitalName = s.Hospital.Name }).ToList();
                this.dgwDepartments.AutoGenerateColumns = false;
                this.dgwDepartments.DataSource = department;
            }
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var frm = new FrmDepartmentAdd();
            frm.MdiParent = this.MdiParent;
            frm.MasterForm = this;
            frm.Show();
        }

        private void DgwDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idfromsky = dgwDepartments.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgwDepartments.SelectedRows.Count > 0)
            {
                var frm = new FrmDepartmentEdit();
                frm.GridId = idfromsky;
                frm.MasterForm = this;
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            else
            {
                MessageBox.Show("- Lütfen Düzenlemek İstediğiniz Bölümü Seçiniz -");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(idfromsky)>0)
            {
                DialogResult deletedialog = new DialogResult();
                deletedialog = MessageBox.Show("Silmek İstediğinize Emin Misiniz ?", "Uyarı", MessageBoxButtons.YesNo);
                if (deletedialog==DialogResult.Yes)
                {
                    using (var db = new ApplicationDbContext())
                    {
                        int id = Convert.ToInt32(idfromsky);
                        var depdelete = db.Departments.Where(x => x.Id == id).FirstOrDefault();
                        db.Departments.Remove(depdelete);

                        if (depdelete!=null)
                        {
                            try
                            {
                                db.SaveChanges();
                                MessageBox.Show("- Kayıt Başarıyla Silindi");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("- Bu Bölüm Kullanıldığı İçin Silinemiyor -"+ex.Message);
                            }
                        }


                        LoadDepartments();
                       
                    }

                }
            }
            else
            {
                MessageBox.Show("- Lütfen Bölüm Seçiniz -");
            }
        }
    } 
}
