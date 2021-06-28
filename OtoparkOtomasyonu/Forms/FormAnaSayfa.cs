using OtoparkOtomasyonu.Properties;
using OtoparkOtomasyonu.User_Controls;
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
    public partial class FormAnaSayfa : Form
    {



        public FormAnaSayfa()
        {
            InitializeComponent();
            UC_AnaSayfa anaSayfa = new UC_AnaSayfa();
            uc_doldur(anaSayfa);

        }

        private void uc_doldur(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            panel_uc.Controls.Clear();
            panel_uc.Controls.Add(uc);
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            UC_AracGiris aracGiris = new UC_AracGiris();
            uc_doldur(aracGiris);
            btnAracEkle.Visible = true;
            btnMusteriEkle.Visible = true;
            btnMarkaEkle.Visible = false;
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            UC_AnaSayfa anaSayfa =new UC_AnaSayfa();

            uc_doldur(anaSayfa);
            btnAracEkle.Visible = false;
            btnMusteriEkle.Visible = false;
            btnMarkaEkle.Visible = false;
        }

        private void btn_cikis_Click(object sender, EventArgs e)
        {
            UC_AracCikis aracCikis = new UC_AracCikis();
            uc_doldur(aracCikis);
            btnAracEkle.Visible = false;
            btnMusteriEkle.Visible = false;
            btnMarkaEkle.Visible = false;
        }

        private void btn_kasa_Click(object sender, EventArgs e)
        {
            UC_KASA kasa = new UC_KASA(); ;
            uc_doldur(kasa);
            btnAracEkle.Visible = false;
            btnMusteriEkle.Visible = false;
            btnMarkaEkle.Visible = false;
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

        private void button5_Click(object sender, EventArgs e)
        {
                        this.WindowState = FormWindowState.Minimized;
        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            UC_MusteriEkle msutr = new  UC_MusteriEkle(); ;
            uc_doldur(msutr);
            btnAracEkle.Visible = false;
            btnMusteriEkle.Visible = true;
            btnMarkaEkle.Visible = false;

        }

        private void btnAracEkle_Click(object sender, EventArgs e)
        {
            UC_aracEkle arac = new UC_aracEkle();
            uc_doldur(arac);
            btnAracEkle.Visible = true;
            btnMusteriEkle.Visible = false;
            btnMarkaEkle.Visible = true;
        }

        private void btnMarkaEkle_Click(object sender, EventArgs e)
        {
            UC_MarkaEkle marka = new UC_MarkaEkle();
            uc_doldur(marka);
            btnAracEkle.Visible = true;
            btnMusteriEkle.Visible = false;
            btnMarkaEkle.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
