using System.Linq;
using Microsoft.EntityFrameworkCore;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries.In
{
    public class GetProductsWhoseModelIsInList : Query
    {
        public GetProductsWhoseModelIsInList(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
            : base(dbContext, adoExecutor)
        {


            SqlQuery = @"
SELECT
    Id,
    Name,
    ModelYear,
    Price
FROM
    Production.Products
WHERE
    ModelYear IN (2016, 2017, 2018)
ORDER BY
    ModelYear DESC,
    Name;
";

            LinqMethodSyntaxQuery = @"
var query = DbContext.Products
    .Where(p => new[] { 2016, 2017, 2018 }.Contains(p.ModelYear))
    .OrderByDescending(p => p.ModelYear)
    .ThenBy(p=> p.Name)
    .Select(p => new
    {
        p.Id,
        p.Name,
        p.ModelYear,
        p.Price
    });

return query.ToList();
";

            LinqQuerySyntaxQuery = @"
var query =
    from product in DbContext.Products
    where new[] { 2016, 2017, 2018 }.Contains(product.ModelYear)
    orderby product.ModelYear descending, product.Name
    select new
    {
        product.Id,
        product.Name,
        product.ModelYear,
        product.Price
    };

return query.ToList();
";


        }


        protected override QueryResult ExecuteLinqMethodSyntaxApproachImpl()
        {
            var query = DbContext.Products
                .Where(p => new[] { 2016, 2017, 2018 }.Contains(p.ModelYear))
                .OrderByDescending(p => p.ModelYear)
                .ThenBy(p => p.Name)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.ModelYear,
                    p.Price
                });


            return new QueryResult(query.ToList(), query.ToQueryString());
        }

        protected override QueryResult ExecuteLinqQuerySyntaxApproachImpl()
        {
            var query =
                from product in DbContext.Products
                where new[] { 2016, 2017, 2018 }.Contains(product.ModelYear)
                orderby product.ModelYear descending, product.Name
                select new
                {
                    product.Id,
                    product.Name,
                    product.ModelYear,
                    product.Price
                };

            
            return new QueryResult(query.ToList(), query.ToQueryString());
        }
    }
}
