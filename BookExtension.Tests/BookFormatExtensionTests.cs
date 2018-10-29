using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;
using NUnit.Framework;

namespace BookExtension.Tests
{
    [TestFixture]
    public class BookFormatExtensionTests
    {
        Book book = new Book(title: "C# in Depth",
            author: "Jon Skeet",
            year: "2019",
            publishingHous: "Manning",
            edition: "4",
            pages: "900",
            price: "40$");

        [TestCase(ExpectedResult = "- Book record: Jon Skeet, C# in Depth, 2019, Manning")]
        public string BookToStringFormat_DefaultFormatsGeneral()
            => string.Format(new BookFormatExtension(), "{0:g}", book);

        [TestCase(ExpectedResult = "- Book record: Jon Skeet, C# in Depth, 2019, Manning")]
        public string BookToStringFormat_DefaultFormats()
            => string.Format(new BookFormatExtension(), "{0:C}", book);

        [TestCase(ExpectedResult = "- Book record: Jon Skeet, C# in Depth, 2019")]
        public string BookToStringFormat_DefaultFormatsYear()
            => string.Format(new BookFormatExtension(), "{0:y}", book);

        [TestCase(ExpectedResult = "- Book record: Jon Skeet, C# in Depth")]
        public string BookToStringFormat_DefaultFormatsShort()
            => string.Format(new BookFormatExtension(), "{0:s}", book);

        [TestCase(ExpectedResult = "- Book record: C# in Depth, 2019, Manning")]
        public string BookToStringFormat_DefaultFormatsPublishinghous()
            => string.Format(new BookFormatExtension(), "{0:p}", book);

        [TestCase(ExpectedResult = "- Book record: C# in Depth")]
        public string BookToStringFormat_DefaultFormatsTitle()
            => string.Format(new BookFormatExtension(), "{0:T}", book);

        [TestCase(ExpectedResult = "- Book record: 4")]
        public string BookToStringFormat_DefaultCustomEdition()
            => string.Format(new BookFormatExtension(), "{0:e}", book);

        [TestCase(ExpectedResult = "- Book record: C# in Depth")]
        public string BookToStringFormat_DefaultFormatsTitleWithDefaultFormatProvider()
            => string.Format(CultureInfo.CurrentCulture, "{0:T}", book);
    }
}
