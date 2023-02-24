using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabOdev.Entity
{
    public class KisaVadeli : Hesap
    {


        public KisaVadeli(decimal hesapBakiyesi, string hesapNumarasi, DateTime hesapAcmaTarihi, string hesapTuru) : base(hesapBakiyesi, hesapNumarasi, hesapAcmaTarihi, hesapTuru)
        {

        }
        public override string HesapBilgileriveBakiyeGörüntüle(string hesapTuru)
        {

            return "KISA VADELİ";


        }
        public override decimal ParaCek(decimal cekilecekPara)
        {
            if (Hesapbakiyesi - cekilecekPara >= 2000)
            {
                decimal yeniBakiye = CekmeIslemi(cekilecekPara);
                return yeniBakiye;
            }
            else
            {
                return -2;
            }
        }
        public override decimal ParaYatir(decimal yatirilacakPara)
        {
            decimal yeniBakiye = YatirmaIslemi(yatirilacakPara);
            return yeniBakiye;         
        }
        public override decimal KarHesapla()
        {
            try
            {
                TimeSpan gunSayisiHesapla = DateTime.Now - HesapAcmaTarihi;
                int gunSayisi = (int)gunSayisiHesapla.Days;
                decimal kar = ((decimal)Hesapbakiyesi / (decimal)100) * ((decimal)10 / (decimal)365) * (decimal)gunSayisi;
                return kar;
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
