using KullaniciKotnrol.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KullaniciKotnrol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        UserContext db = new UserContext();
        User user = new User();
        private void button1_Click(object sender, EventArgs e)
        {

            user.Name = ad.Text;
            user.SurName = soyad.Text;
            user.Age = int.Parse(yas.Text);
            user.IsAcvtive = true;
            user.FirstEntry = DateTime.Now;
            user.LastEntry = DateTime.Now;
            db.Users.Add(user);
            db.SaveChanges();
            MessageBox.Show("Kullanıcı Eklendi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            var rapor = db.Users.Where(x => x.IsAcvtive == false).ToList();
            foreach (var i in rapor)
            {
              var x=  new XDocument(
                                new XElement("Rapor",
                                    new XElement("İsim", i.Name),
                                    new XElement("Soyisim", i.SurName),
                                    new XElement("Yaş", i.Age),
                                    new XElement("Sisteme İlk Giriş", i.FirstEntry.ToString()),
                                    new XElement("Sistem Çıkış", i.LastEntry.ToString())
                                    )   
                                        ).ToString();
                MessageBox.Show(x.ToString());
              
            }
            
        }
    }
}
