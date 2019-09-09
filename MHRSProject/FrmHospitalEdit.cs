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
    public partial class FrmHospitalEdit : Form
    {
        public string Masterform { get; set; }
        public FrmHospitals GridRefresher {get;set;}
        public FrmHospitalEdit()
        {
            InitializeComponent();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                int id = Convert.ToInt32(Masterform);
                var transformer = db.Hospitals.Where(x => x.Id == id).FirstOrDefault();
                 transformer.Name= txtHospitalName.Text;
                 transformer.Address=txtAddress.Text;
                 transformer.Phone=txtPhone.Text;
                 db.SaveChanges();
            }
            MessageBox.Show("- Başarıyla Güncellendi -");
        }

        private void FrmHospitalEdit_Load(object sender, EventArgs e)
        {
           
                using (var db = new ApplicationDbContext())
                {
                    int id = Convert.ToInt32(Masterform);
                    var transformer = db.Hospitals.Where(x => x.Id == id).FirstOrDefault();
                    txtHospitalName.Text = transformer.Name.ToString();
                    txtAddress.Text = transformer.Address.ToString();
                    txtPhone.Text = transformer.Phone.ToString();
                }
            
            
        }

        private void BtnKapat_Click(object sender, EventArgs e)
        {
            GridRefresher.RefreshGrid();
            this.Close();
        }
    }
}
