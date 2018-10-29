using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public static class Parser
    {
        public static int ToDecimal(this string source, int @base)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>()
            {
                { '0', 0 },
                { '1', 1 },
                { '2', 2 },
                { '3', 3 },
                { '4', 4 },
                { '5', 5 },
                { '6', 6 },
                { '7', 7 },
                { '8', 8 },
                { '9', 9 },
                { 'A', 10 },
                { 'B', 11 },
                { 'C', 12 },
                { 'D', 13 },
                { 'E', 14 },
                { 'F', 15 }
            };
            
            if (source == null)
                throw new ArgumentNullException();

            if (@base > 16 || @base < 2)
                throw new ArgumentOutOfRangeException((nameof(@base)));

            char[] charArray = source.ToUpperInvariant().ToCharArray();

            foreach (var c in charArray)
            {
                if (!dict.ContainsKey(c))
                    throw new ArgumentException();
                
                if (dict[c] >= @base)
                    throw new ArgumentException(nameof(source));  
            }

            if (source.Length > 32 / (@base / 2))
                throw new ArgumentException();

            int pow = 0;
            int ans = 0;

            for (int i = charArray.Length - 1; i >= 0; i--)
            {
                ans += (int)(dict[charArray[i]] * Math.Pow(@base, pow++));
            }

            return ans;
        }
    }
}
