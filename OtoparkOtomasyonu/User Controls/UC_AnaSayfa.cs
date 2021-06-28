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
    public partial class UC_AnaSayfa : UserControl
    {
        otobarkDBEntities db = new otobarkDBEntities();
        Array arabalar;
        public UC_AnaSayfa()
        {
            InitializeComponent();
            timer_saat.Start();
            bilgileriDoldur();
        }

        private void timer_saat_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label_timer.Text = dt.ToString("HH:mm:ss");
        }
        private void bilgileriDoldur()
        {

            try
            {
                var park = db.tbl_parkAlani.SingleOrDefault(r => r.Durumu == true && r.otoparkAlanAdi == Kullanici.ParkAdi);
                double kasa = Convert.ToDouble(park.kasa);
                double ucret1 = Convert.ToDouble(park.saat_1_ucret);
                double ucret2 = Convert.ToDouble(park.saat_2_ucret);
                double ucret3 = Convert.ToDouble(park.saat_3_ucret);
                double ucretGunboyu = Convert.ToDouble(park.saat_gunboyu_ucret);
                var arabaSayisi = db.tbl_islemler.Where(w => w.Durum == true && w.tbl_parkAlani.otoparkAlanAdi == Kullanici.ParkAdi);
                label_aracSayısı.Text = Convert.ToString(arabaSayisi.Count());
                string saatlikUcret = " SAATLİK ÜCRET";
                label_kapasite.Text = Convert.ToString(park.kapasite);
                label_kasa.Text = Convert.ToString(kasa) + " TL";
                label_saat1.Text = Convert.ToString(park.saat_1) + saatlikUcret;
                label_saat2.Text = Convert.ToString(park.saat_2) + saatlikUcret;
                label_saat3.Text = Convert.ToString(park.saat_3) + saatlikUcret;
                label_ucret1.Text = Convert.ToString(ucret1) + " TL";
                label_ucret2.Text = Convert.ToString(ucret2) + " TL";
                label_ucret3.Text = Convert.ToString(ucret3) + " TL";
                label_ucret4.Text = Convert.ToString(ucretGunboyu) + " TL";

                label_bosluk.Text = Convert.ToString(park.kapasite - arabaSayisi.Count());


                label_otopark.Text = Kullanici.ParkAdi.ToUpper();
                label_ad.Text = Kullanici.Adi.ToUpper() + " " + Kullanici.Soyadi.ToUpper();

            }
            catch (Exception hata)
            {

                label_message.Text = hata.Message;
            }





        }
    }
}
