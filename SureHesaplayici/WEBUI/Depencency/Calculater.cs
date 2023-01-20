namespace WEBUI.Depencency
{
    public static class Calculater
    {
        public static string CalculateApp(List<int> minutes, int perEightHour)
        {
            long summ = minutes.Sum(q => q);

            decimal ToplamSaat = Convert.ToDecimal((float)summ / (float)60);

            decimal result = Convert.ToDecimal(((float)((float)perEightHour / 8) / 60) * summ);

            return "Toplam Ücret: " + result.ToString() + "   Çalışılan Dakika: " + summ.ToString() + "  Toplam Çalışılan Saat: " + ToplamSaat.ToString();

        }
    }
}
