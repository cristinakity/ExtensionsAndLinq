namespace ExtensionsAndLinq
{
    public static class DateTimeExtensions
    {
        public static string ToSpecialDate(this DateTime date, string caracter)
        {
            return $"⭐⭐👌{date.ToString()}👌⭐⭐{caracter}";
        }
    }
}
