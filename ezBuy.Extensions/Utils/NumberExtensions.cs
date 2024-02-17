using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ezBuy.Extensions.Utils
{
    public static class NumberExtensions
    {
        public static bool IsPositive(this int value) => value > decimal.Zero;
        public static bool IsPositive(this decimal value) => value > decimal.Zero;

        public static bool IsZero(this int value) => value == 0;
        public static bool IsZero(this decimal value)
            => value == 0 || decimal.Round(value, 2).ToString() == "0.00";

        public static bool IsNegative(this int value) => value < decimal.Zero;
        public static bool IsNegative(this decimal value) => value < decimal.Zero;

        public static bool IsNullOrZero(this int? value) => !value.HasValue || value.Value.IsZero();

        public static bool IsEquals(this decimal value, decimal input)
            => decimal.Round(value, 2) == decimal.Round(input, 2);

        public static bool IsEquals(this decimal? value, decimal? input)
        {
            if (!value.HasValue && !input.HasValue)
            {
                return true;
            }
            else if (!value.HasValue || !input.HasValue)
            {
                return false;
            }
            else if (value.HasValue && input.HasValue)
            {
                return value.Value.IsEquals(input.Value);
            }

            return false;
        } 

        public static bool Between(this int value, int startIndex, int endIndex) => value >= startIndex && value <= endIndex;

        public static bool Between(this decimal value, decimal startIndex, decimal endIndex) => value >= startIndex && value <= endIndex;
    }
}
