using System.Linq;
using Microsoft.EntityFrameworkCore;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries.Sorting
{
    public class SortResultSetByOneColumnInDescendingOrder : Query
    {
        public SortResultSetByOneColumnInDescendingOrder(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
            : base(dbContext, adoExecutor)
        {


            SqlQuery = @"
SELECT
  FirstName,
  LastName,
  Email
FROM
  Sales.Customers
ORDER BY
  FirstName DESC;
";

            LinqMethodSyntaxQuery = @"
var query = DbContext.Customers
    .OrderByDescending(c => c.FirstName)
    .Select(c => new
    {
        c.FirstName,
        c.LastName,
        c.Email
    });

return query.ToList();
";

            LinqQuerySyntaxQuery = @"
var query =
    from customer in DbContext.Customers
    orderby customer.FirstName descending
    select new
    {
        customer.FirstName,
        customer.LastName,
        customer.Email
    };

return query.ToList();
";


        }


        protected override QueryResult ExecuteLinqMethodSyntaxApproachImpl()
        {
            var query = DbContext.Customers
                .OrderByDescending(c => c.FirstName)
                .Select(c => new
                {
                    c.FirstName,
                    c.LastName,
                    c.Email
                });


            return new QueryResult(query.ToList(), query.ToQueryString());
        }

        protected override QueryResult ExecuteLinqQuerySyntaxApproachImpl()
        {
            var query =
                from customer in DbContext.Customers
                orderby customer.FirstName descending
                select new
                {
                    customer.FirstName,
                    customer.LastName,
                    customer.Email
                };


            return new QueryResult(query.ToList(), query.ToQueryString());
        }
    }
}