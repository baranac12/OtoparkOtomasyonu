using OtoparkOtomasyonu.Forms;
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
    public partial class UC_aracEkle : UserControl
    {
        otobarkDBEntities db = new otobarkDBEntities();
        public UC_aracEkle()
        {
            InitializeComponent();
            ModelListele();
        }
        private void btnGiris_Click(object sender, EventArgs e)
        {
            tbl_arac arac = new tbl_arac();
            if (txt_Model.Text != "" || txt_plaka.Text != "")
            {
                arac.plaka = txt_plaka.Text;
                arac.MarkaId = int.Parse(comboBox_marka.SelectedValue.ToString());
                arac.Model = txt_Model.Text;
                DialogResult res = MessageBox.Show("Kayıt Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                db.tbl_arac.Add(arac);
                db.SaveChanges();
            }
            else
            {
                DialogResult res = MessageBox.Show("Boş alan bırakmayınız", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void ModelListele()
        {

                var marka = db.tbl_marka;
                comboBox_marka.DisplayMember = "MarkaAdi";
                comboBox_marka.ValueMember = "id"; ;
                comboBox_marka.DataSource = marka.ToList();
            
        }


    }
}
