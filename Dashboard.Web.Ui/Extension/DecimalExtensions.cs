using System.Globalization;

namespace Dashboard.Web.Ui.Extension
{
    public static class DecimalExtensions
    {
        public static string ToCurrency(this decimal number)
        {
            return number.ToString("C", CultureInfo.CreateSpecificCulture("nb-NO"));
        }
    }
}