using System.Linq;
using Microsoft.EntityFrameworkCore;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries.GroupBy
{
    public class GetTotalSalesPriceAndCountOfProductsAcrossAllStoresIn2016 : Query
    {
        public GetTotalSalesPriceAndCountOfProductsAcrossAllStoresIn2016(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
            : base(dbContext, adoExecutor)
        {


            SqlQuery = @"
SELECT
	s.Id AS StoreId,
	s.[Name] AS StoreName,
	p.Id AS ProductId,
	p.[Name] AS ProductName,
	COUNT(o.Id) NumberOfOrders,
	SUM(i.Quantity * i.Price) TotalSalesPrice
FROM Sales.OrderItems i
INNER JOIN Sales.Orders o ON i.OrderId = o.Id AND YEAR(o.OrderDate) = '2016'
INNER JOIN Production.Products p ON i.ProductId = p.Id
INNER JOIN Sales.Stores s ON o.StoreId = s.Id
GROUP BY
	p.Id,
	p.[Name],
	s.Id,
	s.[Name]
ORDER BY
	p.Id,
	COUNT(o.Id) DESC,
	s.id;
";

            LinqMethodSyntaxQuery = @"
var query = DbContext.OrderItems
    .Where(i=> i.Order.OrderDate.Year == 2016)
    .GroupBy(i => new
    {
        i.ProductId,
        ProductName = i.Product.Name,
        i.Order.StoreId,
        StoreName = i.Order.Store.Name
    })
    .Select(g => new
    {
        g.Key.ProductId,
        g.Key.ProductName,
        g.Key.StoreId,
        g.Key.StoreName,
        NumberOfOrders = g.Count(),
        TotalSalesPrice = g.Sum(i=> i.Price * i.Quantity)
    })
    .OrderBy(r=> r.ProductId)
    .ThenByDescending(r=> r.NumberOfOrders)
    .ThenBy(r=> r.StoreId);

return query.ToList();
";

            LinqQuerySyntaxQuery = @"
var query =
    from orderItem in DbContext.OrderItems
    where orderItem.Order.OrderDate.Year == 2016
    group orderItem by new
    {
        orderItem.ProductId,
        ProductName = orderItem.Product.Name,
        orderItem.Order.StoreId,
        StoreName = orderItem.Order.Store.Name
    }
    into g
    orderby
        g.Key.ProductId,
        g.Count() descending,
        g.Key.StoreId
    select new
    {
        g.Key.ProductId,
        g.Key.ProductName,
        g.Key.StoreId,
        g.Key.StoreName,
        NumberOfOrders = g.Count(),
        TotalSalesPrice = g.Sum(i => i.Price * i.Quantity)
    };

return query.ToList();
";


        }


        protected override QueryResult ExecuteLinqMethodSyntaxApproachImpl()
        {
            var query = DbContext.OrderItems
                .Where(i => i.Order.OrderDate.Year == 2016)
                .GroupBy(i => new
                {
                    i.ProductId,
                    ProductName = i.Product.Name,
                    i.Order.StoreId,
                    StoreName = i.Order.Store.Name
                })
                .Select(g => new
                {
                    g.Key.ProductId,
                    g.Key.ProductName,
                    g.Key.StoreId,
                    g.Key.StoreName,
                    NumberOfOrders = g.Count(),
                    TotalSalesPrice = g.Sum(i => i.Price * i.Quantity)
                })
                .OrderBy(r => r.ProductId)
                .ThenByDescending(r => r.NumberOfOrders)
                .ThenBy(r => r.StoreId);


            return new QueryResult(query.ToList(), query.ToQueryString());
        }

        protected override QueryResult ExecuteLinqQuerySyntaxApproachImpl()
        {
            var query =
                from orderItem in DbContext.OrderItems
                where orderItem.Order.OrderDate.Year == 2016
                group orderItem by new
                {
                    orderItem.ProductId,
                    ProductName = orderItem.Product.Name,
                    orderItem.Order.StoreId,
                    StoreName = orderItem.Order.Store.Name
                }
                into g
                orderby
                    g.Key.ProductId,
                    g.Count() descending,
                    g.Key.StoreId
                select new
                {
                    g.Key.ProductId,
                    g.Key.ProductName,
                    g.Key.StoreId,
                    g.Key.StoreName,
                    NumberOfOrders = g.Count(),
                    TotalSalesPrice = g.Sum(i => i.Price * i.Quantity)
                };


            return new QueryResult(query.ToList(), query.ToQueryString());
        }

    }
}
