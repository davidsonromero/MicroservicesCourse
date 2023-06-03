namespace RESTWithASPDotNETCore.Util
{
    public sealed class Util
    {
        public static decimal ConvertToDecimal(string number)
        {
            if (decimal.TryParse(number,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimal result))
            {
                return result;
            }
            return result;
        }

        public static double ConvertToDouble(string number)
        {
            if (double.TryParse(number,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out double result))
            {
                return result;
            }
            return result;
        }

        public static bool IsNumeric(string number)
        {
            if (decimal.TryParse(number,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimal result))
            {
                return true;
            }
            return false;
        }
    }
}
