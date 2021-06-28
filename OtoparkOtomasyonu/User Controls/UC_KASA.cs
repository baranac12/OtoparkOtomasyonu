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
    public partial class UC_KASA : UserControl
    {
        otobarkDBEntities db = new otobarkDBEntities();
        public UC_KASA()
        {
            InitializeComponent();
            KasaListele();
            kasaToplam();
        }

        private void KasaListele()
        {
            dataGridView_kasa.DataSource = db.tbl_islemler.Where(w => w.otoparkId == Kullanici.ParkID && w.Durum==false).Select(s => new
            {
                Musteri = s.tbl_musteri.Ad +" "+ s.tbl_musteri.Soyad,
                AraçBilgi = s.tbl_arac.tbl_marka.MarkaAdi +"--"+ s.tbl_arac.Model,
                Plaka = s.tbl_arac.plaka,
                Tarih = s.cikisTarihi,
                Tutar = s.Tutar
            }).ToList();
        }

        private void kasaToplam()
        {
            double toplam = 0;
            for(int i =0; i<dataGridView_kasa.Rows.Count; i++)
            {
                toplam += Convert.ToDouble(dataGridView_kasa.Rows[i].Cells["Tutar"].Value.ToString());
            }
            txtToplamKAsa.Text = Convert.ToString(toplam);
            txtGiris.Text = dataGridView_kasa.Rows.Count.ToString();
        }

    }
}
