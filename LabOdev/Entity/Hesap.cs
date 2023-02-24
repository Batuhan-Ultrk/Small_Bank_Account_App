using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LabOdev.Entity
{
    public class Hesap : IHesap
    {

        protected decimal Hesapbakiyesi { get; set; }
        protected string HesapNumarasi { get; set; }
        protected DateTime HesapAcmaTarihi { get; set; }
        protected string Hesapturu { get; set; }


        public Hesap(decimal hesapBakiyesi, string hesapNumarasi, DateTime hesapAcmaTarihi, string hesapTuru)
        {
            HesapAcmaTarihi = hesapAcmaTarihi;
            Hesapturu = hesapTuru;
            HesapNumarasi = hesapNumarasi;
            Hesapbakiyesi = hesapBakiyesi;

        }


        virtual public string HesapBilgileriveBakiyeGörüntüle(string hesapTuru)
        {
            throw new NotImplementedException();
        }

        virtual public decimal KarHesapla()
        {
            throw new NotImplementedException();
        }

        virtual public decimal ParaCek(decimal cekilecekPara)
        {
            throw new NotImplementedException();
        }

        virtual public decimal ParaYatir(decimal yatirilacakPara)
        {
            throw new NotImplementedException();
        }
        public void AllSave(decimal eskiBakiye)
        {
            TextReader tReader = new StreamReader("C:\\Users\\USER\\Desktop\\C#_Dersleri\\Odev\\hesap2");

            string okunan;
            List<string> satirlarList = new List<string>();
            while ((okunan = tReader.ReadLine()) != null)
            {
                if (okunan.Contains(HesapNumarasi))
                {
                    okunan.IndexOf(HesapNumarasi);
                    var degistirilecekKisim = okunan.Substring(okunan.IndexOf(HesapNumarasi) + 27);
                    degistirilecekKisim = degistirilecekKisim.Replace(eskiBakiye.ToString(), Hesapbakiyesi.ToString());
                    int diziUzunluğu = okunan.Length - degistirilecekKisim.Length;
                    char[] ch = new char[diziUzunluğu];
                    string dedegistirilmeyecekKisim = "";
                    okunan.CopyTo(0, ch, 0, diziUzunluğu);
                    for (int i = 0; i < ch.Length; i++)
                    {
                        dedegistirilmeyecekKisim += ch[i];

                    }
                    okunan = String.Concat(dedegistirilmeyecekKisim, degistirilecekKisim);
                }
                satirlarList.Add(okunan);
            }
            tReader.Close();
            TextWriter tWriter = new StreamWriter("C:\\Users\\USER\\Desktop\\C#_Dersleri\\Odev\\hesap2");
            foreach (var item in satirlarList)
            {
                tWriter.WriteLine(item);
                tWriter.Flush();

            }
            tWriter.Close();
        }
        public decimal CekmeIslemi(decimal cekilecekPara)
        {
            decimal eskiBakiye = Hesapbakiyesi;
            Hesapbakiyesi = Hesapbakiyesi - cekilecekPara;
            AllSave(eskiBakiye);
            return Hesapbakiyesi;
        }
        public decimal YatirmaIslemi(decimal yatirilacakPara)
        {
            decimal eskiBakiye = Hesapbakiyesi;
            Hesapbakiyesi = Hesapbakiyesi + yatirilacakPara;
            AllSave(eskiBakiye);
            return Hesapbakiyesi;
        }

    }
}
