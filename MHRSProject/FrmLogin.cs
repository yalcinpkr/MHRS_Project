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
    public partial class FrmLogin : Form
    {

        public FrmLogin()
        {
            InitializeComponent();
            txtIdentityLogin.Text = "12345678900";
            txtPasswordLogin.Text = "0";
        }

       private void BoxClear()
        {
            txtIdentityLogin.Text = null;
            txtPasswordLogin.Text = null;
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                var user=db.Patients.Where(p=>p.IdentityNumber==txtIdentityLogin.Text && p.Password==txtPasswordLogin.Text).FirstOrDefault();
              

                if (user!=null)
                {
                    string gendertitle="Bey";
                    if (user.Gender==Gender.Female)
                    {
                        gendertitle = "Hanımefendi";
                    }
                    string message = "Hoş geldiniz " + user.FirstName + " "+user.LastName+" " + gendertitle + " :)";
                    MessageBox.Show(message,"Hata");
                    ((FrmMain)this.MdiParent).ActiveUser = user;
                    ((FrmMain)this.MdiParent).menuStrip1.Enabled = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Turp Gibisin, Bizi meşgul etme");
                    BoxClear();
                }
              
            }
        }

        private void BtnPatientRegister_Click(object sender, EventArgs e)
        {
            //INSERT İŞLEMİ
            using (var db=new ApplicationDbContext())
            {
                var patient = new Patient();
                patient.FirstName = txtFirstName.Text;
                patient.LastName = txtLastName.Text;
                patient.IdentityNumber = txtIdentityNumber.Text;
                patient.Password = txtPassword.Text;
                patient.Email = txtEmail.Text;
                patient.Phone = txtPhone.Text;

                //Cinsiyet Ayarı
                patient.Gender = (rbtMale.Checked ? Gender.Male : (rbtFemale.Checked ? Gender.Female : Gender.Male));

                db.Patients.Add(patient);
                db.SaveChanges();
                MessageBox.Show("Kulanıcı başarıyla Eklendi","Tebrikler");
            }
            tabControl1.Show();

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            ((FrmMain)this.MdiParent).menuStrip1.Enabled = false;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmForgetPassword frm = new FrmForgetPassword();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}
