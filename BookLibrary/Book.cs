using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book : IFormattable
    {
       public string Title { get; }
       public string Author { get; }
       public string Year { get; }
       public string PublishingHous { get; }
       public string Edition { get; }
       public string Pages { get; }
       public string Price { get; }

        public Book()
        {
            this.Title = null;
            this.Author = null;
            this.Year = null;
            this.PublishingHous = null;
            this.Edition = null;
            this.Pages = null;
            this.Price = null;
        }

        public Book(string title, string author, string year, string publishingHous, string edition, string pages, string price)
        {
            this.Title = title;
            this.Author = author;
            this.Year = year;
            this.PublishingHous = publishingHous;
            this.Edition = edition;
            this.Pages = pages;
            this.Price = price;
        }

        //Override object method.
        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }
        
        //Implementing IFormattable.
        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }
   
        public string ToString(string format, IFormatProvider provider) 
        {
            if (string.IsNullOrEmpty(format)) 
                format = "G";

            if (provider == null) 
                provider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "G":
                case "C":
                    return
                        $"{this.Author.ToString(provider)}, {this.Title.ToString(provider)}, {this.Year.ToString(provider)}, {PublishingHous.ToString(provider)}";
                case "Y":
                    return $"{this.Author.ToString(provider)}, {this.Title.ToString(provider)}, {this.Year.ToString(provider)}";
                case "S":
                    return $"{this.Author.ToString(provider)}, {this.Title.ToString(provider)}";
                case "P":
                    return $"{this.Title.ToString(provider)}, {this.Year.ToString(provider)}, {this.PublishingHous.ToString(provider)}";
                case "T":
                    return $"{this.Title.ToString(provider)}";
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }


        }

    }
}
