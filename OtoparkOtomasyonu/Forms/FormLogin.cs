using OtoparkOtomasyonu.Forms;
using OtoparkOtomasyonu.Model.Entities;
using OtoparkOtomasyonu.Model.Manuel;
using OtoparkOtomasyonu.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoparkOtomasyonu
{
    public partial class FormLogin : Form
    {
        otobarkDBEntities db = new otobarkDBEntities();
        public FormLogin()
        {
            InitializeComponent();
        }
        private void kayitKontrol(String kadi , String parola)
        {
            try
            {
                if (kadi != "" && parola != "")
                {
                    tbl_kullanici klnc = db.tbl_kullanici.AsNoTracking().FirstOrDefault(x => x.KullaniciAdi == txtKAdi.Text && x.Parola == txtParola.Text);
                    if (klnc != null)
                    {
                        Kullanici.Adi = klnc.Ad;
                        Kullanici.Soyadi = klnc.Soyad;
                        Kullanici.ParkAdi = klnc.tbl_parkAlani.otoparkAlanAdi;
                        Kullanici.KullaniciAdi = klnc.KullaniciAdi;
                        Kullanici.Id = klnc.id;
                        Kullanici.ParkID = klnc.ParkAlanId;
                        DialogResult res = MessageBox.Show("Kullanici Bilgileri Doğru. AnaSayfaya Yönlendiriliyorsunuz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormAnaSayfa frm = new FormAnaSayfa();
                        this.Hide();
                        frm.ShowDialog();

                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("Kullanici Bilgileri Yanlış Tekrar Deneyiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    DialogResult res = MessageBox.Show("Alanları Doldurunuz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception hata)
            {
                DialogResult res = MessageBox.Show("HATA : "+hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            kayitKontrol(txtKAdi.Text, txtParola.Text);
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            FormKullaniciEkle klnc = new FormKullaniciEkle();
            this.Hide();
            klnc.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Buyult_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                btn_Buyult.Image = Resources.icons8_collapse_48;

                this.WindowState = FormWindowState.Maximized;
            }
            else
            {

                this.WindowState = FormWindowState.Normal;
                btn_Buyult.Image = Resources.icons8_expand_48;
            }
        }

        private void btn_Kucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
