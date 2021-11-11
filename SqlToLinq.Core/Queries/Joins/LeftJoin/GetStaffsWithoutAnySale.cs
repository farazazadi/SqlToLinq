using System.Linq;
using Microsoft.EntityFrameworkCore;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries.Joins.LeftJoin
{
    public class GetStaffsWithoutAnySale : Query
    {
        public GetStaffsWithoutAnySale(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
            : base(dbContext, adoExecutor)
        {


            SqlQuery = @"
SELECT 
	s.FirstName + ' ' + s.LastName AS Staff
FROM Sales.Staffs s
LEFT JOIN Sales.Orders o ON s.Id = o.StaffId
WHERE
    o.Id IS NULL
ORDER BY
    s.FirstName,
    s.LastName;
";

            LinqMethodSyntaxQuery = @"
// Left Join not Supported in LINQ method syntax
var query = DbContext.Staffs
    .Where(s => s.Orders.Count == 0)
    .OrderBy(s => s.FirstName)
    .ThenBy(s => s.LastName)
    .Select(s => new
    {
        Staff = $""{s.FirstName} {s.LastName}""
    });

return query.ToList();
";

            LinqQuerySyntaxQuery = @"
// Left Join not Supported in LINQ query syntax
var query =
    from staff in DbContext.Staffs
    where staff.Orders.Count == 0
    orderby staff.FirstName, staff.LastName
    select new
    {
        Staff = $""{staff.FirstName} {staff.LastName}""
    };

return query.ToList();
";


        }


        protected override QueryResult ExecuteLinqMethodSyntaxApproachImpl()
        {
            var query = DbContext.Staffs
                .Where(s => s.Orders.Count == 0)
                .OrderBy(s => s.FirstName)
                .ThenBy(s => s.LastName)
                .Select(s => new
                {
                    Staff = $"{s.FirstName} {s.LastName}"
                });


            return new QueryResult(query.ToList(), query.ToQueryString());
        }

        protected override QueryResult ExecuteLinqQuerySyntaxApproachImpl()
        {
            var query =
                from staff in DbContext.Staffs
                where staff.Orders.Count == 0
                orderby staff.FirstName, staff.LastName
                select new
                {
                    Staff = $"{staff.FirstName} {staff.LastName}"
                };


            return new QueryResult(query.ToList(), query.ToQueryString());
        }
    }
}
