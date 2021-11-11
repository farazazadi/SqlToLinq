using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries.Between
{
    public class GetOrdersThatCustomersPlacedInSpecificPeriod : Query
    {
        public GetOrdersThatCustomersPlacedInSpecificPeriod(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
            : base(dbContext, adoExecutor)
        {


            SqlQuery = @"
SELECT
    Id,
    CustomerId,
    OrderDate,
    OrderStatus
FROM
    Sales.Orders
WHERE
    OrderDate BETWEEN '20170115' AND '20170117'
ORDER BY
    OrderDate;
";

            LinqMethodSyntaxQuery = @"
var query = DbContext.Orders
    .Where(o => o.OrderDate >= DateTime.Parse(""2017/01/15"")
            && o.OrderDate <= DateTime.Parse(""2017/01/17""))
    .OrderBy(o => o.OrderDate)
    .Select(o => new
    {
        o.Id,
        o.CustomerId,
        o.OrderDate,
        o.OrderStatus
    });

return query.ToList();
";

LinqQuerySyntaxQuery = @"
var query =
    from order in DbContext.Orders
    where order.OrderDate >= DateTime.Parse(""2017/01/15"")
        && order.OrderDate <= DateTime.Parse(""2017/01/17"")
    orderby order.OrderDate
    select new
    {
        order.Id,
        order.CustomerId,
        order.OrderDate,
        order.OrderStatus
    };

return query.ToList();
";


        }


        protected override QueryResult ExecuteLinqMethodSyntaxApproachImpl()
        {
            var query = DbContext.Orders
                .Where(o => o.OrderDate >= DateTime.Parse("2017/01/15")
                            && o.OrderDate <= DateTime.Parse("2017/01/17"))
                .OrderBy(o => o.OrderDate)
                .Select(o => new
                {
                    o.Id,
                    o.CustomerId,
                    o.OrderDate,
                    o.OrderStatus
                });


            return new QueryResult(query.ToList(), query.ToQueryString());
        }

        protected override QueryResult ExecuteLinqQuerySyntaxApproachImpl()
        {
            var query =
                from order in DbContext.Orders
                where order.OrderDate >= DateTime.Parse("2017/01/15")
                      && order.OrderDate <= DateTime.Parse("2017/01/17")
                orderby order.OrderDate
                select new
                {
                    order.Id,
                    order.CustomerId,
                    order.OrderDate,
                    order.OrderStatus
                };


            return new QueryResult(query.ToList(), query.ToQueryString());
        }
    }
}
