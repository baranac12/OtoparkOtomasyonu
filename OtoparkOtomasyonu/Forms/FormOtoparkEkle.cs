
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

namespace OtoparkOtomasyonu.Forms
{

    public partial class FormOtoparkEkle : Form
    {
        otobarkDBEntities db = new otobarkDBEntities();
        public FormOtoparkEkle()
        {
            InitializeComponent();
        }

        private void btnOtoparkEkle_Click(object sender, EventArgs e)
        {
            tbl_parkAlani otopark = new tbl_parkAlani();
            try
            {
                otopark.otoparkAlanAdi = txt_ad.Text;
                otopark.kapasite = int.Parse(txt_kapasite.Text);
                otopark.saat_1 = int.Parse(txt_saat1.Text);
                otopark.saat_1_ucret = Convert.ToDecimal(txt_saat1_ucret.Text);
                otopark.saat_2 = int.Parse(txt_saat2.Text);
                otopark.saat_2_ucret = Convert.ToDecimal(txt_saat2_ucret.Text);
                otopark.saat_3 = int.Parse(txt_saat3.Text);
                otopark.saat_3_ucret = Convert.ToDecimal(txt_saat3_ucret.Text);
                otopark.saat_gunboyu_ucret = Convert.ToDecimal(txt_gunboyu.Text);
                otopark.Durumu = true;
                otopark.kasa = Convert.ToDecimal(txtKasa.Text);
                DialogResult res = MessageBox.Show("Kayıt Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.tbl_parkAlani.Add(otopark);
                db.SaveChanges();
                FormKullaniciEkle frm = new FormKullaniciEkle();
                this.Hide();
                frm.ShowDialog();



            }
            catch (Exception hata)
            {
                DialogResult res = MessageBox.Show("Kayıt Sırasında hata :  " + hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormKullaniciEkle frm = new FormKullaniciEkle();
            this.Hide();
            frm.ShowDialog();

        }
    }
}
