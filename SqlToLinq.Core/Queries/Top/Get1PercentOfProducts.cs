using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Extensions;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries.Top
{
    public class Get1PercentOfProducts : Query
    {
        public Get1PercentOfProducts(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
            : base(dbContext, adoExecutor)
        {


            SqlQuery = @"
SELECT TOP 1 PERCENT
    [Name], 
    Price
FROM
    Production.Products
ORDER BY 
    Price DESC;
";

            LinqMethodSyntaxQuery = @"
// This line executes separate query on the DataBase
var totalRows = DbContext.Products.Count();

var query = DbContext.Products
    .OrderByDescending(p => p.Price)
    .Take(1.PercentOf(totalRows))
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
            // This line executes separate query on the DataBase
            var totalRows = DbContext.Products.Count();

            var query = DbContext.Products
                .OrderByDescending(p => p.Price)
                .Take(1.PercentOf(totalRows))
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