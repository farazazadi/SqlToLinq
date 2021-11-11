using System.Linq;
using Microsoft.EntityFrameworkCore;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries.Like
{
    public class GetCustomersWhoseLastNameStartsAndEndsWithSpecificLetter : Query
    {
        public GetCustomersWhoseLastNameStartsAndEndsWithSpecificLetter(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
            : base(dbContext, adoExecutor)
        {


            SqlQuery = @"
SELECT
    Id,
    FirstName,
    LastName
FROM
    Sales.Customers
WHERE
    LastName LIKE 't%s'
ORDER BY
    FirstName;
";

            LinqMethodSyntaxQuery = @"
var query = DbContext.Customers
    .Where(c => c.LastName.StartsWith(""t"") 
             && c.LastName.EndsWith(""s""))
    .OrderBy(c => c.FirstName)
    .Select(c => new
    {
        c.Id,
        c.FirstName,
        c.LastName
    });

return query.ToList();
";

            LinqQuerySyntaxQuery = @"
var query =
    from customer in DbContext.Customers
    where customer.LastName.StartsWith(""t"") 
        && customer.LastName.EndsWith(""s"")
    orderby customer.FirstName
    select new
    {
        customer.Id,
        customer.FirstName,
        customer.LastName
    };

return query.ToList();
";


        }


        protected override QueryResult ExecuteLinqMethodSyntaxApproachImpl()
        {
            var query = DbContext.Customers
                .Where(c => c.LastName.StartsWith("t") && c.LastName.EndsWith("s"))
                .OrderBy(c => c.FirstName)
                .Select(c => new
                {
                    c.Id,
                    c.FirstName,
                    c.LastName
                });


            return new QueryResult(query.ToList(), query.ToQueryString());
        }

        protected override QueryResult ExecuteLinqQuerySyntaxApproachImpl()
        {
            var query =
                from customer in DbContext.Customers
                where customer.LastName.StartsWith("t") && customer.LastName.EndsWith("s")
                orderby customer.FirstName
                select new
                {
                    customer.Id,
                    customer.FirstName,
                    customer.LastName
                };


            return new QueryResult(query.ToList(), query.ToQueryString());
        }
    }
}
