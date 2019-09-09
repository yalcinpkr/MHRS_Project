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
    public partial class FrmPatients : Form
    {
        public FrmPatients()
        {
            InitializeComponent();
        }

        private void RefreshPatient()
        {
            using (var db=new ApplicationDbContext())
            {
                var patient = db.Patients.OrderBy(x => x.FirstName).ThenBy(y => y.LastName).ToList();
                dgwPatient.DataSource = patient;
            }
        }
        private void FrmPatients_Load(object sender, EventArgs e)
        {
            RefreshPatient();
        }
    }
}
