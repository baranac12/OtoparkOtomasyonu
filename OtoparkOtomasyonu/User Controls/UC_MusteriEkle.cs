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
    public partial class UC_MusteriEkle : UserControl
    {
        otobarkDBEntities db = new otobarkDBEntities();
        public UC_MusteriEkle()
        {

            InitializeComponent();
        }
        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMusteriAd.Text != "" || txtMusteriSoyad.Text != "" || txtTelefon.Text != "")
                {
                    tbl_musteri mstr = new tbl_musteri();
                    mstr.Ad = txtMusteriAd.Text;
                    mstr.Soyad = txtMusteriSoyad.Text;
                    mstr.Telefon = txtTelefon.Text;
                    db.tbl_musteri.Add(mstr);
                    db.SaveChanges();

                    DialogResult res = MessageBox.Show("Kayıt Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    DialogResult res = MessageBox.Show("Boş alan bırakmayınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception hata)
            {

                DialogResult res = MessageBox.Show("hata : " + hata, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
