using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries.OffsetFetch
{
    public class SkipTheFirst10ProductsAndSelectTheNext10Products : Query
    {
        public SkipTheFirst10ProductsAndSelectTheNext10Products(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
            : base(dbContext, adoExecutor)
        {

            SqlQuery = @"
SELECT
    [Name],
    Price
FROM
    Production.Products
ORDER BY
    Price,
    [Name] 
OFFSET 10 ROWS
FETCH NEXT 10 ROWS ONLY;
";

            LinqMethodSyntaxQuery = @"
var query = DbContext.Products
    .OrderBy(p=> p.Price)
    .ThenBy(p=> p.Name)
    .Skip(10)
    .Take(10)
    .Select(p => new
    {
        p.Name,
        p.Price
    });

return query.ToList();
";

            LinqQuerySyntaxQuery = @"
// Skip not Supported in C# query syntax
";


        }

        protected override QueryResult ExecuteLinqMethodSyntaxApproachImpl()
        {
            var query = DbContext.Products
                .OrderBy(p => p.Price)
                .ThenBy(p => p.Name)
                .Skip(10)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Price
                });


            return new QueryResult(query.ToList(), query.ToQueryString());
        }

        protected override QueryResult ExecuteLinqQuerySyntaxApproachImpl()
        {
            throw new NotImplementedException("Skip and Take not supported in C# query syntax");
        }


    }
}