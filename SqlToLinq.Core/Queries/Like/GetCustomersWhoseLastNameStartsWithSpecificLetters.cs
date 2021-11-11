using System.Linq;
using Microsoft.EntityFrameworkCore;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries.Like
{
    public class GetCustomersWhoseLastNameStartsWithSpecificLetters : Query
    {
        public GetCustomersWhoseLastNameStartsWithSpecificLetters(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
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
    LastName LIKE '[YZ]%'
ORDER BY
    LastName;
";

            LinqMethodSyntaxQuery = @"
var query = DbContext.Customers
    .Where(c => EF.Functions.Like(c.LastName, ""[YZ]%""))
    .OrderBy(c => c.LastName)
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
    where EF.Functions.Like(customer.LastName, ""[YZ]%"")
    orderby customer.LastName
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
                .Where(c => EF.Functions.Like(c.LastName, "[YZ]%"))
                .OrderBy(c => c.LastName)
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
                where EF.Functions.Like(customer.LastName, "[YZ]%")
                orderby customer.LastName
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
