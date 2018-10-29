using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BookLibrary.Tests
{
    [TestFixture]
    public class BookTest
    {
        Book book = new Book(title: "C# in Depth",
                            author: "Jon Skeet",
                            year: "2019",
                            publishingHous: "Manning",
                            edition: "4",
                            pages: "900",
                            price: "40$");

        [TestCase("G", ExpectedResult = "- Book record: Jon Skeet, C# in Depth, 2019, Manning")]
        [TestCase("C", ExpectedResult = "- Book record: Jon Skeet, C# in Depth, 2019, Manning")]
        [TestCase("y", ExpectedResult = "- Book record: Jon Skeet, C# in Depth, 2019")]
        [TestCase("S", ExpectedResult = "- Book record: Jon Skeet, C# in Depth")]
        [TestCase("p", ExpectedResult = "- Book record: C# in Depth, 2019, Manning")]
        [TestCase("T", ExpectedResult = "- Book record: C# in Depth")]
        public string BookToStringFormat_ValidFormats(string format)
            => book.ToString(format);
        
        [TestCase("S", ExpectedResult = "- Book record: Jon Skeet, C# in Depth")]
        public string BookToStringFormat_ValidFormats1(string format)
            => string.Format("{0:s}", book);

        [Test]
        public void BookToString_WithNonSupportedFormat()
            =>Assert.Throws<FormatException>(() => book.ToString("0"));
    }
}
