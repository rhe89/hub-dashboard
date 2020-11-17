using System.Globalization;

namespace Dashboard.BlazorApp.Extension
{
    public static class DecimalExtensions
    {
        public static string ToCurrency(this decimal number)
        {
            return number.ToString("C", CultureInfo.CreateSpecificCulture("nb-NO"));
        }
    }
}