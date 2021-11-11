using System.Linq;
using Microsoft.EntityFrameworkCore;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries.Selection
{

    public class GetAllCustomersWithItsAllColumns : Query
    {

        public GetAllCustomersWithItsAllColumns(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
            : base(dbContext, adoExecutor)
        {

            SqlQuery = @"
SELECT
  *
FROM sales.Customers;
";

            LinqMethodSyntaxQuery = @"
return DbContext.Customers.ToList();
";

            LinqQuerySyntaxQuery = @"
var query =
    from customer in DbContext.Customers
    select customer;

return query.ToList();
";
        }


        protected override QueryResult ExecuteLinqMethodSyntaxApproachImpl()
        {
            var query = DbContext.Customers;

            return new QueryResult(query.ToList(), query.ToQueryString());
        }

        protected override QueryResult ExecuteLinqQuerySyntaxApproachImpl()
        {
            var query =
                from customer in DbContext.Customers
                select customer;

            return new QueryResult(query.ToList(), query.ToQueryString());
        }


    }
}