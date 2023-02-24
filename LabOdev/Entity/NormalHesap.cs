using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabOdev.Entity
{
    public class NormalHesap : Hesap
    {
        public NormalHesap(decimal hesapBakiyesi, string hesapNumarasi, DateTime hesapAcmaTarihi, string hesapTuru) : base(hesapBakiyesi, hesapNumarasi, hesapAcmaTarihi, hesapTuru)
        {
        }
        public override string HesapBilgileriveBakiyeGörüntüle(string hesapTuru)
        {
            return "NORMAL VADELİ";
        }
        public override decimal ParaCek(decimal cekilecekPara)
        {
            if (Hesapbakiyesi - cekilecekPara >= 0)
            {
                decimal yeniBakiye = CekmeIslemi(cekilecekPara);
                return yeniBakiye;
            }
            else
            {
                return -3;
            }
        }
        public override decimal ParaYatir(decimal yatirilacakPara)
        {
            decimal yeniBakiye = YatirmaIslemi(yatirilacakPara);
            return yeniBakiye;
        }
    }
}
