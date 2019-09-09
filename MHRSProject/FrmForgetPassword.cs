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
    public partial class FrmForgetPassword : Form
    {
        public FrmForgetPassword()
        {
            InitializeComponent();
        }

        private void BtnForgetPassword_Click(object sender, EventArgs e)
        {
            if (txtIdentity.Text=="")
            {
                MessageBox.Show("- Lütfen Kimlik Numaranızı Giriniz -");
                return;
            }
            else if(txtPassword.Text=="")
            {
                MessageBox.Show("- Lütfen Yeni Şifreyi Giriniz -");
            }
            else if (txtPasswordValidate.Text=="")
            {
                MessageBox.Show("- Lütfen Şifre Tekrar Alanını Doldurunuz -");
            }

            if (txtPassword.Text==txtPasswordValidate.Text)
            {
                using (var db=new ApplicationDbContext())
                {
                  var patient= db.Patients.Where(t => t.IdentityNumber == txtIdentity.Text).FirstOrDefault();
                    if (patient!=null)
                    {
                        patient.Password = txtPassword.Text;
                        db.SaveChanges();
                        MessageBox.Show("Şifreniz Başarıyla Değişmiştir");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("- Böyle Bir Hasta Bulunamadı -");
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("- Lütfen Şifrelerin Doğruluğunu Kontrol Ediniz -");
            }
        }
    }
}
