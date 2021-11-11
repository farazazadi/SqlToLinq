using System.Linq;
using Microsoft.EntityFrameworkCore;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries.Where
{
    public class GetCustomersWhoDoNotHaveThePhoneNumber : Query
    {
        public GetCustomersWhoDoNotHaveThePhoneNumber(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
            : base(dbContext, adoExecutor)
        {


            SqlQuery = @"
SELECT
    Id,
    FirstName,
    LastName,
    Phone
FROM
    Sales.Customers
WHERE
    Phone IS NULL
ORDER BY
    FirstName,
    LastName;
";

            LinqMethodSyntaxQuery = @"
var query = DbContext.Customers
    .Where(c => c.Phone == null)
    .OrderBy(c => c.FirstName)
    .ThenBy(c => c.LastName)
    .Select(c => new
    {
        c.Id,
        c.FirstName,
        c.LastName,
        c.Phone
    });

return query.ToList();
";

            LinqQuerySyntaxQuery = @"
var query =
    from customer in DbContext.Customers
    where customer.Phone == null
    orderby customer.FirstName, customer.LastName
    select new
    {
        customer.Id,
        customer.FirstName,
        customer.LastName,
        customer.Phone
    };

return query.ToList();
";


        }


        protected override QueryResult ExecuteLinqMethodSyntaxApproachImpl()
        {
            var query = DbContext.Customers
                .Where(c => c.Phone == null)
                .OrderBy(c => c.FirstName)
                .ThenBy(c => c.LastName)
                .Select(c => new
                {
                    c.Id,
                    c.FirstName,
                    c.LastName,
                    c.Phone
                });


            return new QueryResult(query.ToList(), query.ToQueryString());
        }

        protected override QueryResult ExecuteLinqQuerySyntaxApproachImpl()
        {
            var query =
                from customer in DbContext.Customers
                where customer.Phone == null
                orderby customer.FirstName, customer.LastName
                select new
                {
                    customer.Id,
                    customer.FirstName,
                    customer.LastName,
                    customer.Phone
                };


            return new QueryResult(query.ToList(), query.ToQueryString());
        }
    }
}
