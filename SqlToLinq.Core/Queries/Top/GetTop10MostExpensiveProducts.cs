using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries.Top
{
    public class GetTop10MostExpensiveProducts : Query
    {
        public GetTop10MostExpensiveProducts(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
            : base(dbContext, adoExecutor)
        {


            SqlQuery = @"
SELECT TOP 10
    [Name], 
    Price
FROM
    Production.Products
ORDER BY 
    Price DESC;
";

            LinqMethodSyntaxQuery = @"
var query = DbContext.Products
    .OrderByDescending(p => p.Price)
    .Take(10)
    .Select(c => new
    {
        c.Name,
        c.Price
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
                .OrderByDescending(p => p.Price)
                .Take(10)
                .Select(c => new
                {
                    c.Name,
                    c.Price
                });


            return new QueryResult(query.ToList(), query.ToQueryString());
        }

        protected override QueryResult ExecuteLinqQuerySyntaxApproachImpl()
        {
            throw new NotImplementedException("Take not supported in C# query syntax");

        }
    }
}