using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries.Distinct
{
    public class GetTheDistinctCityAndStateOfAllCustomers : Query
    {
        public GetTheDistinctCityAndStateOfAllCustomers(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
            : base(dbContext, adoExecutor)
        {


            SqlQuery = @"
SELECT DISTINCT
    City,
    State
FROM
    Sales.Customers
ORDER BY 
    City,
    State
";

            LinqMethodSyntaxQuery = @"
var query = DbContext.Customers
    .OrderBy(c => c.City)
    .ThenBy(c => c.State)
    .Select(c => new
    {
        c.City,
        c.State
    })
    .Distinct();


return query.ToList();
";

            LinqQuerySyntaxQuery = @"
// Distinct not supported in C# query syntax
";


        }


        protected override QueryResult ExecuteLinqMethodSyntaxApproachImpl()
        {
            var query = DbContext.Customers
                .OrderBy(c => c.City)
                .ThenBy(c => c.State)
                .Select(c => new
                {
                    c.City,
                    c.State
                })
                .Distinct();


            return new QueryResult(query.ToList(), query.ToQueryString());
        }

        protected override QueryResult ExecuteLinqQuerySyntaxApproachImpl()
        {
            throw new NotImplementedException("Distinct not supported in C# query syntax");
        }
    }
}
