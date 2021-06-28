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
    public partial class UC_AracCikis : UserControl
    {
        String girilenSaat;
        DateTime giris;
        DateTime cikis;
        TimeSpan span;
        otobarkDBEntities db = new otobarkDBEntities();
        public UC_AracCikis()
        {
            InitializeComponent();
            IslemleriGetir();
        }
        private void IslemleriGetir()
        {
            dataGridView_listArac.DataSource = db.tbl_islemler.Where(w => w.Durum == true && w.otoparkId == Kullanici.ParkID).Select(s => new
            {
                Id = s.id,
                MusteriAdi = s.tbl_musteri.Ad + " " + s.tbl_musteri.Soyad,
                Arac = s.tbl_arac.tbl_marka.MarkaAdi + " / " + s.tbl_arac.Model,
                Plaka = s.tbl_arac.plaka,
                Giris = s.girisTarihi,
                Cikis = s.cikisTarihi,
                Otopark = s.tbl_parkAlani.otoparkAlanAdi,
                Tutar = s.Tutar
            }).ToList();

        }

        private void dataGridView_listArac_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtId.Text = dataGridView_listArac.SelectedRows[0].Cells["Id"].Value.ToString();
            txtMusteriAd.Text = dataGridView_listArac.SelectedRows[0].Cells["MusteriAdi"].Value.ToString();
            txt_plaka.Text = dataGridView_listArac.SelectedRows[0].Cells["Plaka"].Value.ToString();
            girilenSaat = dataGridView_listArac.SelectedRows[0].Cells["Giris"].Value.ToString();

            giris = Convert.ToDateTime(girilenSaat);
            cikis = DateTime.Now;
            span = cikis - giris;
            var saat = db.tbl_parkAlani.SingleOrDefault(w => w.otoparkAlanAdi == Kullanici.ParkAdi);

            if (span.TotalDays < 1)
            {
                if (span.TotalHours<=saat.saat_1)
                {
                    txt_saat.Text = saat.saat_1.ToString(); ;
                    txtTutar.Text = Convert.ToString(Convert.ToDouble(saat.saat_1_ucret));

                }else if(span.TotalHours >= saat.saat_1 && span.TotalHours <= saat.saat_2)
                {
                    txt_saat.Text = saat.saat_2.ToString();
                    txtTutar.Text = Convert.ToString(Convert.ToDouble(saat.saat_2_ucret));
                }
                else if (span.TotalHours >= saat.saat_2 && span.TotalHours <= saat.saat_3)
                {
                    txt_saat.Text = saat.saat_3.ToString();
                    txtTutar.Text = Convert.ToString(Convert.ToDouble(saat.saat_3_ucret));
                }
            }else if (span.TotalHours >=1)
            {
                txt_saat.Text = span.TotalDays.ToString();
                txtTutar.Text = Convert.ToString(Convert.ToDouble(saat.saat_gunboyu_ucret));
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            tbl_islemler islemler = db.tbl_islemler.Find(id);

            tbl_parkAlani otopark = db.tbl_parkAlani.Find(Kullanici.ParkID);

            islemler.cikisTarihi = DateTime.Now;
            islemler.Durum = false;
            islemler.Tutar = int.Parse(txtTutar.Text);

            double toplam = Convert.ToDouble(otopark.kasa) + Convert.ToDouble(txtTutar.Text);
            otopark.kasa = Convert.ToDecimal(toplam);

            db.SaveChanges();

            

            DialogResult res = MessageBox.Show("Kayıt Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            IslemleriGetir();


        }
    }
}
