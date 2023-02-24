using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabOdev.Entity
{
    public interface IHesap
    {
        decimal ParaYatir(decimal yatirilacakPara);
        decimal ParaCek(decimal çekilecekPara);

        string HesapBilgileriveBakiyeGörüntüle(string hesapTuru);

        decimal KarHesapla();

        void AllSave(decimal eskiBakiye);

        decimal CekmeIslemi(decimal cekilecekPara);

        decimal YatirmaIslemi(decimal yatirilacakPara);

    }
}
