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
    public partial class FrmHospitalAdd : Form
    {
        private FrmHospitals grider;
        public FrmHospitalAdd(FrmHospitals grider)
        {
            this.grider = grider;
            InitializeComponent();
        }
        

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //TODO: Önce validasyonlar yapılır.
            //Veritabanına kaydedilir.
            //TODO:Master Formdaki veri yenilenir.

            if (string.IsNullOrEmpty(txtHospitalName.Text))
            {
                MessageBox.Show("- Lütfen Hastane Adı Giriniz -");
                return;
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("- Lütfen Adres Giriniz -");
                return;
            }
            else if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("- Lütfen Telefon Giriniz -");
                return;
            }
            
                using (var db = new ApplicationDbContext())
                {
                    var hospitaladd = new Hospital();
                    hospitaladd.Name = txtHospitalName.Text;
                    hospitaladd.Address = txtAddress.Text;
                    hospitaladd.Phone = txtPhone.Text;
                    db.Hospitals.Add(hospitaladd);
                    db.SaveChanges();
                    MessageBox.Show("- Hastane Eklendi -");
                }
            
        }
        private void BtnKapat_Click(object sender, EventArgs e)
        {
            grider.RefreshGrid();
            this.Close();
        }

       
        private void FrmHospitalAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
