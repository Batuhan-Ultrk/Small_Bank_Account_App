using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabOdev.Entity
{
    public class UzunVadeli : Hesap
    {
        public UzunVadeli(decimal hesapBakiyesi, string hesapNumarasi, DateTime hesapAcmaTarihi, string hesapTuru) : base(hesapBakiyesi, hesapNumarasi, hesapAcmaTarihi, hesapTuru)
        {

        }
        public override string HesapBilgileriveBakiyeGörüntüle(string hesapTuru)
        {
            return "UZUN VADELİ";
        }
        public override decimal ParaCek(decimal cekilecekPara)
        {
            if (Hesapbakiyesi - cekilecekPara>=1000)
            {
                decimal yeniBakiye = CekmeIslemi(cekilecekPara);
                return yeniBakiye;
            }
            else
            {
                return -1;
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
                decimal kar = ((decimal)Hesapbakiyesi / (decimal)100) * ((decimal)20 / (decimal)365) * (decimal)gunSayisi;
                return kar;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
