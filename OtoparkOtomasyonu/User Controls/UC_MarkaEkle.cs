using OtoparkOtomasyonu.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoparkOtomasyonu.User_Controls
{
    public partial class UC_MarkaEkle : UserControl
    {
        otobarkDBEntities db = new otobarkDBEntities();
        public UC_MarkaEkle()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            tbl_marka mrk = new tbl_marka();
            mrk.MarkaAdi = txtMarka.Text;
            db.tbl_marka.Add(mrk);
            db.SaveChanges();
            DialogResult res = MessageBox.Show("Kayıt Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
