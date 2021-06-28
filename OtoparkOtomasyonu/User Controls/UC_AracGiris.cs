using OtoparkOtomasyonu.Forms;
using OtoparkOtomasyonu.Model.Entities;
using OtoparkOtomasyonu.Model.Manuel;
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
    public partial class UC_AracGiris : UserControl
    {
        otobarkDBEntities db = new otobarkDBEntities();
        public UC_AracGiris()
        {
            InitializeComponent();
            MusteriListele();
            //  MarkaListele();
            AracListele();
        }
        private void MusteriListele()
        {
            DGW_musteri.DataSource = db.tbl_musteri
                .Select(s=>
                    new
                    {
                        Id = s.id,
                        MusteriAd = s.Ad,
                        MusteriSoyad = s.Soyad,
                        Telefon = s.Telefon
                    }).ToList();
        }
        private void AracListele()
        {
            DGW_arac.DataSource = db.tbl_arac.Select(s =>
                    new
                    {
                        Id = s.id,
                        Plaka = s.plaka,
                        Model = s.tbl_marka.MarkaAdi+" /"+ s.Model,

                    }).ToList();
        }


        private void DGW_musteri_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtMüsteriAdi.Text = DGW_musteri.SelectedRows[0].Cells["MusteriAd"].Value.ToString();
            label_id.Text = DGW_musteri.SelectedRows[0].Cells["Id"].Value.ToString();

        }
        private void DGW_arac_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtAracPlaka.Text = DGW_arac.SelectedRows[0].Cells["Plaka"].Value.ToString();
            label_aracId.Text = DGW_arac.SelectedRows[0].Cells["Id"].Value.ToString();
        }


        private void btnGiris_Click(object sender, EventArgs e)
        {
            tbl_islemler islem = new tbl_islemler();
            if (txtMüsteriAdi.Text=="")
            {
                islem.otoparkId = Kullanici.ParkID;
                islem.aracId = int.Parse(label_aracId.Text);
                islem.Durum = true;
                islem.girisTarihi = DateTime.Now;
                db.tbl_islemler.Add(islem);
                db.SaveChanges();
                MusteriListele();
                //  MarkaListele();
                AracListele();
                DialogResult res = MessageBox.Show("Kayıt Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                islem.musteriId = int.Parse(label_id.Text);
                islem.otoparkId = Kullanici.ParkID;
                islem.aracId = int.Parse(label_aracId.Text);
                islem.Durum = true;
                islem.girisTarihi = DateTime.Now;
                db.tbl_islemler.Add(islem);
                db.SaveChanges();
                MusteriListele();
                //  MarkaListele();
                AracListele();
                DialogResult res = MessageBox.Show("Kayıt Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
  
            for (int i =0; i<DGW_musteri.Rows.Count; i++)
            {
                if (textBox1.Text == DGW_musteri.Rows[i].Cells["MusteriAd"].Value.ToString())
                {
                    DGW_musteri.DataSource = db.tbl_musteri.Where(w=> w.Ad==textBox1.Text).Select(s =>
                    new
                    {
                        Id = s.id,
                        MusteriAd = s.Ad,
                        MusteriSoyad = s.Soyad,
                        Telefon = s.Telefon
                    }).ToList();
                }
                else if( textBox1.Text=="")
                {
                    MusteriListele();
                }

            }
            

        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < DGW_arac.Rows.Count; i++)
            {
                if (textBox2.Text == DGW_arac.Rows[i].Cells["Plaka"].Value.ToString())
                {
                    DGW_arac.DataSource = db.tbl_arac.Where(w => w.plaka == textBox2.Text).Select(s =>
                       new
                       {
                           Id = s.id,
                           Plaka = s.plaka,
                           Model = s.tbl_marka.MarkaAdi + " /" + s.Model,
                           MusteriAdi = s.tbl_musteri.Ad + s.tbl_musteri.Soyad
                       }).ToList();
                }
                else if (textBox2.Text == "")
                {
                    AracListele();
                }

            }

        }

    }
}
