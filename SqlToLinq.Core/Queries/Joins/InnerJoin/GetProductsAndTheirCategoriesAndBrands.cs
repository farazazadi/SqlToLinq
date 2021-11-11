using System.Linq;
using Microsoft.EntityFrameworkCore;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries.Joins.InnerJoin
{
    public class GetProductsAndTheirCategoriesAndBrands : Query
    {
        public GetProductsAndTheirCategoriesAndBrands(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
            : base(dbContext, adoExecutor)
        {


            SqlQuery = @"
SELECT
    p.Name AS ProductName,
    c.Name AS CategoryName,
    b.Name AS BrandName,
    p.Price
FROM
    Production.Products p
INNER JOIN Production.Categories c ON c.Id = p.CategoryId
INNER JOIN Production.Brands b ON b.Id = p.BrandId
ORDER BY
    p.Name DESC;
";

            LinqMethodSyntaxQuery = @"
var query = DbContext.Products
    .Join(DbContext.Categories
        , p => p.CategoryId
        , c => c.Id
        , (p, c) => new { Product = p, Category = c })
    .Join(DbContext.Brands
        , pc => pc.Product.BrandId
        , b => b.Id
        , (pc, b) => new
        {
            ProductName = pc.Product.Name,
            CategoryName = pc.Category.Name,
            BrandName = b.Name,
            Price = pc.Product.Price
        })
    .OrderByDescending(p=> p.ProductName);


// Of course you can use the 'Navigation Properties' and let the EF do all the work for you under the hood! 
var query = DbContext.Products
    .OrderByDescending(p => p.Name)
    .Select(p => new
    {
        ProductName = p.Name,
        CategoryName = p.Category.Name,
        BrandName = p.Brand.Name,
        Price = p.Price
    });
// -----------------------------------------------


return query.ToList();
";

            LinqQuerySyntaxQuery = @"
var query =
    from product in DbContext.Products
    join category in DbContext.Categories
        on product.CategoryId equals category.Id
    join brand in DbContext.Brands
        on product.BrandId equals brand.Id
    orderby product.Name descending
    select new
    {
        ProductName = product.Name,
        CategoryName = category.Name,
        BrandName = brand.Name,
        Price = product.Price
    };


// Or just using the 'Navigation Properties'! 
var query =
    from product in DbContext.Products
    orderby product.Name descending
    select new
    {
        ProductName = product.Name,
        CategoryName = product.Category.Name,
        BrandName = product.Brand.Name,
        Price = product.Price
    };
// -----------------------------------------------


return query.ToList();
";


        }


        protected override QueryResult ExecuteLinqMethodSyntaxApproachImpl()
        {
            var query = DbContext.Products
                .Join(DbContext.Categories
                    , p => p.CategoryId
                    , c => c.Id
                    , (p, c) => new { Product = p, Category = c })
                .Join(DbContext.Brands
                    , pc => pc.Product.BrandId
                    , b => b.Id
                    , (pc, b) => new
                    {
                        ProductName = pc.Product.Name,
                        CategoryName = pc.Category.Name,
                        BrandName = b.Name,
                        Price = pc.Product.Price
                    })
                .OrderByDescending(p => p.ProductName);


            return new QueryResult(query.ToList(), query.ToQueryString());
        }

        protected override QueryResult ExecuteLinqQuerySyntaxApproachImpl()
        {
            var query =
                from product in DbContext.Products
                join category in DbContext.Categories
                    on product.CategoryId equals category.Id
                join brand in DbContext.Brands
                    on product.BrandId equals brand.Id
                orderby product.Name descending
                select new
                {
                    ProductName = product.Name,
                    CategoryName = category.Name,
                    BrandName = brand.Name,
                    Price = product.Price
                };


            return new QueryResult(query.ToList(), query.ToQueryString());
        }
    }
}
