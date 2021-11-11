using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries.SubQuery
{
    public class GetTheCustomersWhoDidNotBuyAnyProductsIn2017 : Query
    {
        public GetTheCustomersWhoDidNotBuyAnyProductsIn2017(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
            : base(dbContext, adoExecutor)
        {


            SqlQuery = @"
SELECT
    Id,
    FirstName,
    LastName,
    City
FROM
    Sales.Customers c
WHERE
    NOT EXISTS (
        SELECT
            o.CustomerId
        FROM
            Sales.Orders o
        WHERE
            o.CustomerId = c.Id
        AND YEAR (OrderDate) = 2017
    )
ORDER BY
    FirstName,
    LastName;
";

            LinqMethodSyntaxQuery = @"
var query = DbContext.Customers
    .Where(c =>
        !DbContext.Orders
        .Where(o => o.OrderDate.Year == 2017)
        .Select(o => o.CustomerId)
        .Contains(c.Id))
    .Select(c => new
    {
        c.Id,
        c.FirstName,
        c.LastName,
        c.City
    })
    .OrderBy(c => c.FirstName)
    .ThenBy(c => c.LastName);

return query.ToList();
";

            LinqQuerySyntaxQuery = @"
// Contains not supported in C# query syntax
";


        }


        protected override QueryResult ExecuteLinqMethodSyntaxApproachImpl()
        {
            var query = DbContext.Customers
                .Where(c =>
                    !DbContext.Orders
                    .Where(o => o.OrderDate.Year == 2017)
                    .Select(o => o.CustomerId)
                    .Contains(c.Id))
                .Select(c => new
                {
                    c.Id,
                    c.FirstName,
                    c.LastName,
                    c.City
                })
                .OrderBy(c => c.FirstName)
                .ThenBy(c => c.LastName);

            return new QueryResult(query.ToList(), query.ToQueryString());
        }

        protected override QueryResult ExecuteLinqQuerySyntaxApproachImpl()
        {
            throw new NotImplementedException("Contains not supported in C# query syntax");
        }

    }
}
