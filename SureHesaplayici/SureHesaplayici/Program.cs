using System;
using System.Collections.Generic;
using System.Linq;

namespace SureHesaplayici
{
    class Program
    {
        static void Main(string[] args)
        {
            int perEightHour = 975;
            List<int> minutes = new List<int> {
           420,240,120,240,30,200,430,420,600,360
            };

            long summ = minutes.Sum(q => q);

            float ToplamSaat= summ / 60;

            decimal result = Convert.ToDecimal(((float)((float)perEightHour / 8) / 60) * summ);

            Console.WriteLine("Toplam Ücret: "+ result.ToString() +"   Çalışılan Dakika: " + summ.ToString() + "  Toplam Çalışılan Saat: "+ ToplamSaat.ToString());
        }
      
    }
}
