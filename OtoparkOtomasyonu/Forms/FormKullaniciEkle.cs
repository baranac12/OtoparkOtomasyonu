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
    public partial class FormKullaniciEkle : Form
    {
        otobarkDBEntities db = new otobarkDBEntities();
        public FormKullaniciEkle()
        {
            InitializeComponent();
            OtoparkListele();
        }

        private void btnOtoparkEkle_Click(object sender, EventArgs e)
        {
            FormOtoparkEkle frm = new FormOtoparkEkle();
            this.Hide();
            frm.ShowDialog();

        }
        private void OtoparkListele()
        {
            var otopark = db.tbl_parkAlani;
            comboBox_otopark.DisplayMember = "otoparkAlanAdi";
            comboBox_otopark.ValueMember = "id"; ;
            comboBox_otopark.DataSource = otopark.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            tbl_kullanici klnc = new tbl_kullanici();
            try
            {
                if (txt_Kadi.Text !="" && txt_parola.Text!="")
                {
                    klnc.Ad = txt_adi.Text;
                    klnc.Soyad = txt_soyad.Text;
                    klnc.KullaniciAdi = txt_Kadi.Text;
                    klnc.Parola = txt_parola.Text;
                    klnc.ParkAlanId = int.Parse(comboBox_otopark.SelectedValue.ToString());
                    DialogResult res = MessageBox.Show("Kayıt Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db.tbl_kullanici.Add(klnc);
                    db.SaveChanges();
                }
                else
                {
                    DialogResult res = MessageBox.Show("Alanları Doldurunuz  " , "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                temizle();



            }
            catch (Exception hata)
            {
                DialogResult res = MessageBox.Show("Kayıt Sırasında hata :  "+ hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void temizle()
        {
            txt_adi.Text = "";
            txt_Kadi.Text = "";
            txt_parola.Text = "";
            txt_soyad.Text = "";
            comboBox_otopark.Text = "Otopark Seçiniz.";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
