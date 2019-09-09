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
    public partial class FrmHospitals : Form
    {
       public string idfromsky;
        public FrmHospitals()
        {
            
            InitializeComponent();
        }
    private void FrmHospitals_Load(object sender, EventArgs e)
        {
          
            RefreshGrid();
        }
    public void RefreshGrid()
        {
            using (var db=new ApplicationDbContext())
            {
                var hospital = db.Hospitals.OrderBy(x=>x.Name).ToList();
                this.dgwHospital.AutoGenerateColumns = false;
                this.dgwHospital.DataSource = hospital;
           
            }
        }

        private void BtnHospitalAdd_Click(object sender, EventArgs e)
        {
            var frm = new FrmHospitalAdd(this);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void DgwHospital_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwHospital.SelectedRows.Count!=0)
            {
            idfromsky=  dgwHospital.SelectedRows[0].Cells[0].Value.ToString();
               
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

            if (this.dgwHospital.SelectedRows.Count>0)
            {
                var frm = new FrmHospitalEdit();
                frm.Masterform = idfromsky;
                frm.GridRefresher = this;
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            else
            {
                MessageBox.Show("- Lütfen Hastane Seçiniz -");
            }

            
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgwHospital.SelectedRows.Count > 0)
            {
                DialogResult deletevalidate = new DialogResult();
                deletevalidate = MessageBox.Show("Silmek İstediğinize Emin Misiniz ?", "Uyarı", MessageBoxButtons.YesNo);
                if (deletevalidate == DialogResult.Yes)
                {
                    using (var db = new ApplicationDbContext())
                    {
                        int selecteddelete = Convert.ToInt32(dgwHospital.SelectedRows[0].Cells[0].Value.ToString());
                        var transformer = db.Hospitals.Where(x => x.Id == selecteddelete).FirstOrDefault();
                        db.Hospitals.Remove(transformer);
                        db.SaveChanges();
                        RefreshGrid();
                        MessageBox.Show("- Kayıt Başarıyla Silindi -");
                    }
                }
            }
            else
            {
                MessageBox.Show("- Lütfen Hastane Seçiniz -");
            }
        }
    }
}
