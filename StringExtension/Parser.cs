using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public static class Parser
    {
        const int MAX_BASE = 16,
                  MIN_BASE = 2;

        public static int ToDecimal(this string source, int @base)
        {
            if (string.IsNullOrEmpty(source))
                throw new ArgumentNullException();

            if (@base > MAX_BASE || @base < MIN_BASE)
                throw new ArgumentOutOfRangeException((nameof(@base)));

            string dict = "0123456789ABCDEF".Substring(0, @base);
            string upperSource = source.ToUpperInvariant();
            
            int ans = 0;
            long basePowered = 1;
            for (int i = upperSource.Length - 1; i >= 0; i--)
            {
                int temp = dict.IndexOf(upperSource[i]);

                try
                {
                    checked
                    {
                        ans += (temp != -1)?(temp * (int)basePowered):throw new ArgumentException($"Invalid character in {nameof(source)} for current base");
                    }

                    basePowered *= @base;
                }
                catch (OverflowException e)
                {
                    throw new ArgumentException("Too big value!", e);
                }
            }
            
            return ans;
        }
    }
}
