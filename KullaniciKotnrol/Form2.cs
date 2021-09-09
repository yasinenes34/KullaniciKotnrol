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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        UserContext db = new UserContext();
        User user = new User();
        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Users.Where(x=>x.IsAcvtive==true).ToList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var ud = db.Users.Find(id);
            ud.LastEntry = DateTime.Now;
            ud.IsAcvtive = false;
            //TimeSpan time = user.FirstEntry - user.LastEntry;
            db.SaveChanges();
            MessageBox.Show(ud.Name+" isimli kişinin çıkışı yapıldı");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rapor = db.Users.Where(x => x.IsAcvtive == false).ToList();
            foreach (var i in rapor)
            {
                new XDocument(new XElement("Rapor",
                         new XElement("İsim", i.Name),
                         new XElement("Soyisim", i.SurName),
                         new XElement("Yaş", i.Age),
                         new XElement("Sisteme İlk Giriş Tarihi", i.FirstEntry),
                         new XElement("Sistemden Çıkış Tarihi", i.LastEntry)
            )
            ).Save("rapor.xml");
            }


        }
    }
}
