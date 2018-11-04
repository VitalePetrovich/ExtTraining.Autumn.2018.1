using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book : IFormattable, IComparable<Book>, IComparable, IEquatable<Book>
    {
        public string Title { get; }
        public string Author { get; }
        public string Year { get; }
        public string PublishingHous { get; }
        public int Edition { get; }
        public int Pages { get; }
        public decimal Price { get; }
        
        public Book()
        {
            this.Title = null;
            this.Author = null;
            this.Year = null;
            this.PublishingHous = null;
            this.Edition = 0;
            this.Pages = 0;
            this.Price = 0;
        }

        public Book(string title, string author, string year, string publishingHous, int edition, int pages, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Year = year;
            this.PublishingHous = publishingHous;
            this.Edition = edition;
            this.Pages = pages;
            this.Price = price;
        }
        
        public int CompareTo(Book other)
        {
            return string.Compare(this.Title, other?.Title, StringComparison.InvariantCulture);
        }

        public int CompareTo(object obj)
        {
            return this.CompareTo((Book)obj);
        }
        
        public bool Equals(Book other)
        {
            if (this.GetType() != other.GetType())
                return false;

            if (this.GetHashCode() != other?.GetHashCode())
                return false;

            if (this.Title != other.Title ||
                this.Author != other.Author ||
                this.Year != other.Year ||
                this.PublishingHous != other.PublishingHous ||
                this.Edition != other.Edition ||
                this.Pages != other.Pages ||
                this.Price != other.Price)
            {
                return false;
            }

            return true;
        }
        
        //Override object method.
        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Pages;
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
                case "PR":
                    return $"{this.Author.ToString(provider)}, {this.Title.ToString(provider)}, {this.Price.ToString("C", provider)}";
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }


        }

    }
}
