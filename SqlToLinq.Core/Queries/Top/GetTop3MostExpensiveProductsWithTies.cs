using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Extensions;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries.Top
{
    public class GetTop3MostExpensiveProductsWithTies : Query
    {
        public GetTop3MostExpensiveProductsWithTies(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
            : base(dbContext, adoExecutor)
        {


            SqlQuery = @"
SELECT TOP 3 WITH TIES
    [Name], 
    Price
FROM
    Production.Products
ORDER BY 
    Price DESC;
";

            LinqMethodSyntaxQuery = @"
// Top With Ties not supported in LINQ by default
var query = DbContext.Products
    .TopWithTies(p => p.Price, 3, QueryableExt.OrderType.Descending) // Extension method
    .Select(p => new
    {
        p.Name,
        p.Price
    });

return query.ToList();
";

            LinqQuerySyntaxQuery = @"
// Take not supported in C# query syntax
";


        }


        protected override QueryResult ExecuteLinqMethodSyntaxApproachImpl()
        {
            var query = DbContext.Products
                .TopWithTies(p => p.Price, 3) // Extension method
                .Select(p => new
                {
                    p.Name,
                    p.Price
                });

            return new QueryResult(query.ToList(), query.ToQueryString());
        }

        protected override QueryResult ExecuteLinqQuerySyntaxApproachImpl()
        {
            throw new NotImplementedException("Take not supported in C# query syntax");

        }
    }
}