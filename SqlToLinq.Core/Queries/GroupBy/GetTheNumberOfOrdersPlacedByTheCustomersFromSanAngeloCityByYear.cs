using System.Linq;
using Microsoft.EntityFrameworkCore;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries.GroupBy
{
    public class GetTheNumberOfOrdersPlacedByTheCustomersFromSanAngeloCityByYear : Query
    {
        public GetTheNumberOfOrdersPlacedByTheCustomersFromSanAngeloCityByYear(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
            : base(dbContext, adoExecutor)
        {


            SqlQuery = @"
SELECT
	o.CustomerId,
	c.FirstName + ' ' + c.LastName AS CustomerName,
	YEAR(o.OrderDate) OrderYear,
	COUNT(o.Id) CountOfOrders
FROM
	Sales.Orders o
INNER JOIN Sales.Customers c ON c.Id = o.CustomerId
WHERE c.City = 'San Angelo'
GROUP BY
	o.CustomerId,
	c.FirstName + ' ' + c.LastName,
	YEAR(o.OrderDate)
ORDER BY
	CustomerName,
	OrderYear;
";

            LinqMethodSyntaxQuery = @"
var query = DbContext.Orders
        .Where(o => o.Customer.City == ""San Angelo"")
        .GroupBy(o => new
        {
            o.CustomerId,
            CustomerName = o.Customer.FirstName + "" "" + o.Customer.LastName,
            OrderYear = o.OrderDate.Year
        })
        .Select(g => new
        {
            g.Key.CustomerId,
            g.Key.CustomerName,
            g.Key.OrderYear,
            CountOfOrders = g.Count()
        })
    .OrderBy(r => r.CustomerName)
    .ThenBy(r => r.OrderYear);


return query.ToList();
";

            LinqQuerySyntaxQuery = @"
var query =
    from order in DbContext.Orders
    where order.Customer.City == ""San Angelo""
    group order by new
    {
        order.CustomerId,
        CustomerName = order.Customer.FirstName + "" "" + order.Customer.LastName,
        OrderYear = order.OrderDate.Year
    }
    into g
    orderby
        g.Key.CustomerName,
        g.Key.OrderYear
    select new
    {
        g.Key.CustomerId,
        g.Key.CustomerName,
        g.Key.OrderYear,
        CountOfOrders = g.Count()
    };


return query.ToList();
";


        }


        protected override QueryResult ExecuteLinqMethodSyntaxApproachImpl()
        {
            var query = DbContext.Orders
                    .Where(o => o.Customer.City == "San Angelo")
                    .GroupBy(o => new
                    {
                        o.CustomerId,
                        CustomerName = o.Customer.FirstName + " " + o.Customer.LastName,
                        OrderYear = o.OrderDate.Year
                    })
                    .Select(g => new
                    {
                        g.Key.CustomerId,
                        g.Key.CustomerName,
                        g.Key.OrderYear,
                        CountOfOrders = g.Count()
                    })
                .OrderBy(r => r.CustomerName)
                .ThenBy(r => r.OrderYear);


            return new QueryResult(query.ToList(), query.ToQueryString());
        }

        protected override QueryResult ExecuteLinqQuerySyntaxApproachImpl()
        {
            var query =
                from order in DbContext.Orders
                where order.Customer.City == "San Angelo"
                group order by new
                {
                    order.CustomerId,
                    CustomerName = order.Customer.FirstName + " " + order.Customer.LastName,
                    OrderYear = order.OrderDate.Year
                }
                into g
                orderby
                    g.Key.CustomerName,
                    g.Key.OrderYear
                select new
                {
                    g.Key.CustomerId,
                    g.Key.CustomerName,
                    g.Key.OrderYear,
                    CountOfOrders = g.Count()
                };


            return new QueryResult(query.ToList(), query.ToQueryString());
        }

    }
}
