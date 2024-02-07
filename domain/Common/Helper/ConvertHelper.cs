namespace domain.Common.Helper
{
    public static class ConvertHelper
    {
        public static DateTime StrToDate(string strDate)
        {
            DateTime item = DateTime.ParseExact(strDate, "dd/MM/yyyy", null);
            return item;
        }
    }
}
