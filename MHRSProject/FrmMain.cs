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
    public partial class FrmMain : Form
    {
        public Patient ActiveUser { get; set; }
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var frmLogin = new FrmLogin();
            frmLogin.MdiParent = this;
            frmLogin.Show();
        }

        private void RandevularımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmAppointment = new FrmMyAppointments();
            frmAppointment.MdiParent = this;
            frmAppointment.Show();
        }

        private void HastanelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmHospital = new FrmHospitals();
            frmHospital.MdiParent = this;
            frmHospital.Show();
        }

        private void BölümlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmDepartment = new FrmDepartments();
            frmDepartment.MdiParent = this;
            frmDepartment.Show();
        }

        private void DoktorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmDoctors();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void HastalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmPatients();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}
