using System.Linq;
using Microsoft.EntityFrameworkCore;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries.Where
{
    public class GetProductsWhosePriceIsGreaterThan300AndModelIs2018 : Query
    {
        public GetProductsWhosePriceIsGreaterThan300AndModelIs2018(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
            : base(dbContext, adoExecutor)
        {


            SqlQuery = @"
SELECT
    Id,
    Name,
    CategoryId,
    ModelYear,
    Price
FROM
    Production.Products
WHERE
    Price > 300 AND ModelYear = 2018
ORDER BY
    Price DESC;
";

            LinqMethodSyntaxQuery = @"
var query = DbContext.Products
    .Where(p=> p.Price > 300 && p.ModelYear == 2018)
    .OrderByDescending(p=> p.Price)
    .Select(p => new
    {
        p.Id,
        p.Name,
        p.CategoryId,
        p.ModelYear,
        p.Price
    });

return query.ToList();
";

            LinqQuerySyntaxQuery = @"
var query =
    from product in DbContext.Products
    where product.Price > 300 && product.ModelYear == 2018
    orderby product.Price descending
    select new
    {
        product.Id,
        product.Name,
        product.CategoryId,
        product.ModelYear,
        product.Price
    };

return query.ToList();
";


        }


        protected override QueryResult ExecuteLinqMethodSyntaxApproachImpl()
        {
            var query = DbContext.Products
                .Where(p => p.Price > 300 && p.ModelYear == 2018)
                .OrderByDescending(p => p.Price)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.CategoryId,
                    p.ModelYear,
                    p.Price
                });


            return new QueryResult(query.ToList(), query.ToQueryString());
        }

        protected override QueryResult ExecuteLinqQuerySyntaxApproachImpl()
        {
            var query =
                from product in DbContext.Products
                where product.Price > 300 && product.ModelYear == 2018
                orderby product.Price descending
                select new
                {
                    product.Id,
                    product.Name,
                    product.CategoryId,
                    product.ModelYear,
                    product.Price
                };


            return new QueryResult(query.ToList(), query.ToQueryString());
        }
    }
}
