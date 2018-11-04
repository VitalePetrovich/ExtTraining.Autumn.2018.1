using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;

namespace BookExtension
{
    public class BookFormatExtension : IFormatProvider, ICustomFormatter
    {
        //Implementing IFormatProvider
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
           
           return null;
        }

        //Implementing ICustomFormatter
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg.GetType() != typeof(Book))
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException)
                {
                    throw new FormatException($"The format of '{format}' is invalid.");
                }
            }

            string ftm = format.ToString(CultureInfo.InvariantCulture).ToUpperInvariant();
            if (ftm != "E")
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException)
                {
                    throw new FormatException($"The format of '{format}' is invalid.");
                }
            }
            
            return ((Book)arg).Edition.ToString(formatProvider);
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);

            if (arg != null)
                return arg.ToString();
            
            return string.Empty;
        }
    }
}
