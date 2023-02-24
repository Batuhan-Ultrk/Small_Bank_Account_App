using LabOdev.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabOdev
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            getAll();

        }
        List<string> hesapBilgileri = new List<string>();
        List<string> kullaniciBilgileri = new List<string>();

        private void btnGiris_Click(object sender, EventArgs e)
        {
            txtYatirilacatTutar.Text = "";
            txtCekilecekTutar.Text = "";
            try
            {
                string hesapNo = txtHesapNumarası.Text;

                KullaniciBilgileriAl(hesapNo);

                if (kullaniciBilgileri[3] == "kisavadeli")
                {

                    KisaVadeli kisaVadeli = new KisaVadeli(Convert.ToDecimal(kullaniciBilgileri[1]), kullaniciBilgileri[0], Convert.ToDateTime(kullaniciBilgileri[2]), kullaniciBilgileri[3]);
                    var hesapTuru = kisaVadeli.HesapBilgileriveBakiyeGörüntüle(kullaniciBilgileri[3]);

                    lblHesapTuru.Text = hesapTuru;

                }
                else if (kullaniciBilgileri[3] == "uzunvadeli")
                {
                    UzunVadeli uzunVadeli = new UzunVadeli(Convert.ToDecimal(kullaniciBilgileri[1]), kullaniciBilgileri[0], Convert.ToDateTime(kullaniciBilgileri[2]), kullaniciBilgileri[3]);
                    var hesapTuru = uzunVadeli.HesapBilgileriveBakiyeGörüntüle(kullaniciBilgileri[3]);

                    lblHesapTuru.Text = hesapTuru;
                }
                else if (kullaniciBilgileri[3] == "normal")
                {
                    NormalHesap normalVadeli = new NormalHesap(Convert.ToDecimal(kullaniciBilgileri[1]), kullaniciBilgileri[0], Convert.ToDateTime(kullaniciBilgileri[2]), kullaniciBilgileri[3]);
                    var hesapTuru = normalVadeli.HesapBilgileriveBakiyeGörüntüle(kullaniciBilgileri[3]);

                    lblHesapTuru.Text = hesapTuru;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("HESAP BULUNAMADI, LÜTFEN HESAP NUMRANIZI DOĞRU GİRİNİZ.");
            }


        }

        public void KullaniciBilgileriAl(string hesapNo)
        {
            for (int i = 0; i < hesapBilgileri.Count; i++)
            {
                if (hesapNo.Trim() == hesapBilgileri[i])
                {
                    kullaniciBilgileri.Add(hesapBilgileri[i]);
                    kullaniciBilgileri.Add(hesapBilgileri[i + 1]);
                    kullaniciBilgileri.Add(hesapBilgileri[i + 2]);
                    kullaniciBilgileri.Add(hesapBilgileri[i + 3]);

                    lblHesapNumarasi.Text = kullaniciBilgileri[0];
                    lblHesapBakiyesi.Text = kullaniciBilgileri[1].ToString();
                    lblHesapAcmaTarihi.Text = kullaniciBilgileri[2];
                    break;
                }
                else
                {
                    kullaniciBilgileri.Clear();
                    lblHesapNumarasi.Text = "";
                    lblHesapBakiyesi.Text = "";
                    lblHesapAcmaTarihi.Text = "";
                    lblHesapTuru.Text = "";
                }
            }
        }

        public void getAll()
        {
            try
            {
                using (StreamReader sr = new StreamReader("C:\\Users\\USER\\Desktop\\C#_Dersleri\\Odev\\Hesap2"))
                {
                    string deger = "";
                    string satir;
                    List<string> satirlarList = new List<string>();
                    while ((satir = sr.ReadLine()) != null)
                    {
                        for (int i = 0; i < satir.Length; i++)
                        {
                            if (satir[i] == ' ')
                            {
                                satirlarList.Add(deger);
                                deger = "";
                            }
                            deger += satir[i];
                        }
                    }
                    for (int i = 1; i < satirlarList.Count; i += 2)
                    {
                        hesapBilgileri.Add(satirlarList[i].Trim());
                        //MessageBox.Show(satirlarList[i]);

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void btnParaCek_Click(object sender, EventArgs e)
        {
            try
            {

                decimal yeniTutar = 0;
                decimal cekilecekTutar = Convert.ToDecimal(txtCekilecekTutar.Text);
                if (kullaniciBilgileri[3] == "kisavadeli")
                {
                    KisaVadeli kisaVadeli = new KisaVadeli(Convert.ToDecimal(kullaniciBilgileri[1]), kullaniciBilgileri[0], Convert.ToDateTime(kullaniciBilgileri[2]), kullaniciBilgileri[3]);
                    yeniTutar = kisaVadeli.ParaCek(cekilecekTutar);


                }
                else if (kullaniciBilgileri[3] == "uzunvadeli")
                {
                    UzunVadeli uzunVadeli = new UzunVadeli(Convert.ToDecimal(kullaniciBilgileri[1]), kullaniciBilgileri[0], Convert.ToDateTime(kullaniciBilgileri[2]), kullaniciBilgileri[3]);
                    yeniTutar = uzunVadeli.ParaCek(cekilecekTutar);

                }
                else if (kullaniciBilgileri[3] == "normal")
                {
                    NormalHesap normalVadeli = new NormalHesap(Convert.ToDecimal(kullaniciBilgileri[1]), kullaniciBilgileri[0], Convert.ToDateTime(kullaniciBilgileri[2]), kullaniciBilgileri[3]);
                    yeniTutar = normalVadeli.ParaCek(cekilecekTutar);

                }
                Control(yeniTutar);
               
        }
            catch (Exception)
            {

                MessageBox.Show("LÜTFEN ÇEKİLECEK TUTARI GİRİNİZ.");
            }



}

        private void Control(decimal yeniTutar)
        {
            try
            {
                if (yeniTutar == -1)
                {
                    MessageBox.Show("UZUN VADELİ HESAP KULLANIYOSUNUZ HESABINIZDA EN AZ 1000 TL KALMALIDIR.");
                }
                else if (yeniTutar == -2)
                {
                    MessageBox.Show("KISA VADELİ HESAP KULLANIYOSUNUZ HESABINIZDA EN AZ 2000 TL KALMALIDIR.");
                }
                else if (yeniTutar == -3)
                {
                    MessageBox.Show("YETERSİZ LİMİT.");
                }
                else
                {
                    lblHesapBakiyesi.Text = yeniTutar.ToString();
                    MessageBox.Show("PARA ÇEKME İŞLEMİ BAŞARILI");
                    txtCekilecekTutar.Text = "";
                }
            }
            catch (Exception)
            {

                MessageBox.Show("HATA İLE KARŞILAŞILDI");
            }

        }

        private void btnParaYatir_Click(object sender, EventArgs e)
        {
            try
            {
                decimal yeniTutar = 0;
                decimal yatirilacakTutar = Convert.ToDecimal(txtYatirilacatTutar.Text);
                if (kullaniciBilgileri[3] == "kisavadeli")
                {
                    KisaVadeli kisaVadeli = new KisaVadeli(Convert.ToDecimal(kullaniciBilgileri[1]), kullaniciBilgileri[0], Convert.ToDateTime(kullaniciBilgileri[2]), kullaniciBilgileri[3]);
                    yeniTutar = kisaVadeli.ParaYatir(yatirilacakTutar);


                }
                else if (kullaniciBilgileri[3] == "uzunvadeli")
                {
                    UzunVadeli uzunVadeli = new UzunVadeli(Convert.ToDecimal(kullaniciBilgileri[1]), kullaniciBilgileri[0], Convert.ToDateTime(kullaniciBilgileri[2]), kullaniciBilgileri[3]);
                    yeniTutar = uzunVadeli.ParaYatir(yatirilacakTutar);

                }
                else if (kullaniciBilgileri[3] == "normal")
                {
                    NormalHesap normalVadeli = new NormalHesap(Convert.ToDecimal(kullaniciBilgileri[1]), kullaniciBilgileri[0], Convert.ToDateTime(kullaniciBilgileri[2]), kullaniciBilgileri[3]);
                    yeniTutar = normalVadeli.ParaYatir(yatirilacakTutar);

                }
                lblHesapBakiyesi.Text = yeniTutar.ToString();
                MessageBox.Show("PARA YATIRMA İŞLEMİ BAŞARILI");
                txtYatirilacatTutar.Text = "";
              
            }
            catch (Exception)
            {
                MessageBox.Show("LÜTFEN YATIRILACAK TUTARI GİRİNİZ.");
            }

        }

        private void btnKarHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                decimal kar = 0;
                if (kullaniciBilgileri[3] == "kisavadeli")
                {
                    KisaVadeli kisaVadeli = new KisaVadeli(Convert.ToDecimal(kullaniciBilgileri[1]), kullaniciBilgileri[0], Convert.ToDateTime(kullaniciBilgileri[2]), kullaniciBilgileri[3]);
                    kar = kisaVadeli.KarHesapla();


                }
                else if (kullaniciBilgileri[3] == "uzunvadeli")
                {
                    UzunVadeli uzunVadeli = new UzunVadeli(Convert.ToDecimal(kullaniciBilgileri[1]), kullaniciBilgileri[0], Convert.ToDateTime(kullaniciBilgileri[2]), kullaniciBilgileri[3]);
                    kar = uzunVadeli.KarHesapla();

                }
                else if (kullaniciBilgileri[3] == "normal")
                {
                    MessageBox.Show("NORMAL VADELİ HESAPTA KAR ELDE EDİLEMEZ");

                }
                lblKar.Text = kar.ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("HATA İLE KARŞILAŞILDI");
            }

        }
    }
}
