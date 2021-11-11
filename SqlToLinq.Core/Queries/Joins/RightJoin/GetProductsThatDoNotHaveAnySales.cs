using System.Linq;
using Microsoft.EntityFrameworkCore;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries.Joins.RightJoin
{
    public class GetProductsThatDoNotHaveAnySales : Query
    {
        public GetProductsThatDoNotHaveAnySales(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
            : base(dbContext, adoExecutor)
        {


            SqlQuery = @"
SELECT
    p.[Name] AS ProductName
FROM
    Sales.OrderItems o RIGHT JOIN Production.Products p 
        ON o.ProductId = p.Id
WHERE 
    o.Id IS NULL
ORDER BY
    p.[Name];
";

            LinqMethodSyntaxQuery = @"
// Right Join not Supported in LINQ method syntax
var query = DbContext.Products
    .Where(p => p.OrderItems.Count == 0)
    .OrderBy(p => p.Name)
    .Select(p => new
    {
        ProductName = p.Name
    });

return query.ToList();
";

            LinqQuerySyntaxQuery = @"
// Right Join not Supported in LINQ query syntax
var query =
    from product in DbContext.Products
    where product.OrderItems.Count == 0
    orderby product.Name
    select new
    {
        ProductName = product.Name
    };

return query.ToList();
";


        }


        protected override QueryResult ExecuteLinqMethodSyntaxApproachImpl()
        {
            var query = DbContext.Products
                .Where(p => p.OrderItems.Count == 0)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    ProductName = p.Name
                });


            return new QueryResult(query.ToList(), query.ToQueryString());
        }

        protected override QueryResult ExecuteLinqQuerySyntaxApproachImpl()
        {
            var query =
                from product in DbContext.Products
                where product.OrderItems.Count == 0
                orderby product.Name
                select new
                {
                    ProductName = product.Name
                };


            return new QueryResult(query.ToList(), query.ToQueryString());
        }

    }
}
