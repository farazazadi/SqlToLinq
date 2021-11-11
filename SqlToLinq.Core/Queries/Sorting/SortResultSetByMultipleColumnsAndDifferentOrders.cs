using System.Linq;
using Microsoft.EntityFrameworkCore;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries.Sorting
{
    public class SortResultSetByMultipleColumnsAndDifferentOrders : Query
    {
        public SortResultSetByMultipleColumnsAndDifferentOrders(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
            : base(dbContext, adoExecutor)
        {


            SqlQuery = @"
SELECT
  City,
  FirstName,
  LastName
FROM
  Sales.Customers
ORDER BY
  City DESC,
  FirstName ASC;
";

            LinqMethodSyntaxQuery = @"
var query = DbContext.Customers
    .OrderByDescending(c => c.City)
    .ThenBy(c => c.FirstName)
    .Select(c => new
    {
        c.City,
        c.FirstName,
        c.LastName
    });

return query.ToList();
";

            LinqQuerySyntaxQuery = @"
var query =
    from customer in DbContext.Customers
    orderby customer.City descending, customer.FirstName
    select new
    {
        customer.City,
        customer.FirstName,
        customer.LastName
    };

return query.ToList();
";


        }


        protected override QueryResult ExecuteLinqMethodSyntaxApproachImpl()
        {
            var query = DbContext.Customers
                .OrderByDescending(c => c.City)
                .ThenBy(c => c.FirstName)
                .Select(c => new
                {
                    c.City,
                    c.FirstName,
                    c.LastName
                });


            return new QueryResult(query.ToList(), query.ToQueryString());
        }

        protected override QueryResult ExecuteLinqQuerySyntaxApproachImpl()
        {
            var query =
                from customer in DbContext.Customers
                orderby customer.City descending, customer.FirstName
                select new
                {
                    customer.City,
                    customer.FirstName,
                    customer.LastName
                };


            return new QueryResult(query.ToList(), query.ToQueryString());
        }
    }
}