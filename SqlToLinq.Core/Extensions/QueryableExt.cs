using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SqlToLinq.Core.Extensions
{
    public static class QueryableExt
    {

        public enum OrderType
        {
            Ascending,
            Descending
        }


        public static IQueryable<T> TopWithTies<T, TComparator>(this IQueryable<T> source, Expression<Func<T, TComparator>> topBy, int topCount
                                                                , OrderType orderType = OrderType.Descending)
        {
            // https://stackoverflow.com/a/30082505


            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (topBy == null)
                throw new ArgumentNullException(nameof(topBy));

            if (topCount < 1)
                throw new ArgumentOutOfRangeException(nameof(topCount), $"{nameof(topCount)} must be greater than 0!");

            var orderedByValue = orderType == OrderType.Ascending ? 
                            source.OrderBy(topBy) : source.OrderByDescending(topBy);

            var topNValues = orderedByValue
                .Select(topBy)
                .Take(topCount)
                .Distinct();

            var topNRowsWithTies = topNValues
                .Join(source, value => value, topBy, (x, row) => row);

            return orderType == OrderType.Ascending ? 
                topNRowsWithTies.OrderBy(topBy) : topNRowsWithTies.OrderByDescending(topBy);
        }



        public static IQueryable<TSource> Between<TSource, TKey>(this IQueryable<TSource> source,
            Expression<Func<TSource, TKey>> keySelector, TKey low, TKey high) where TKey : IComparable<TKey>
        {
            var key = Expression.Invoke(keySelector, keySelector.Parameters.ToList());

            var lowerBound = Expression.GreaterThanOrEqual(key, Expression.Constant(low));
            var upperBound = Expression.LessThanOrEqual(key, Expression.Constant(high));

            var and = Expression.AndAlso(lowerBound, upperBound);

            var lambda = Expression.Lambda<Func<TSource, bool>>(and, keySelector.Parameters);

            return source.Where(lambda);
        }
      
        
    }
}
