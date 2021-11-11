using System;

namespace SqlToLinq.Core.Extensions
{
    public static class NumberExt
    {
        public static int PercentOf(this int current, int target)
        {
            var result = (int) Math.Ceiling(current * ((double)target / 100));
            return result;
        }
    }
}
