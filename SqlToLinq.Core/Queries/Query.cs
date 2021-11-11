using SqlToLinq.Core.Common;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Interfaces;
using SqlToLinq.Core.Persistence;

namespace SqlToLinq.Core.Queries
{
    public abstract class Query
    {
        protected readonly BikeStoresContext DbContext;
        protected readonly IAdoExecutor AdoExecutor;

        public string SqlQuery { get; init; }
        public string LinqMethodSyntaxQuery { get; init; }
        public string LinqQuerySyntaxQuery { get; init; }

        protected Query(BikeStoresContext dbContext, IAdoExecutor adoExecutor)
        {
            DbContext = dbContext;
            AdoExecutor = adoExecutor;
        }



        public virtual ExecutionResult ExecuteLinqMethodSyntaxApproach()
        {
            var result =
                ExecutionTimeProfiler.ExecuteAndProfile(ExecuteLinqMethodSyntaxApproachImpl);

            result.SetQueryType(QueryType.LinqMethodSyntax);

            return result;
        }

        public virtual ExecutionResult ExecuteLinqQuerySyntaxApproach()
        {
            var result = 
                ExecutionTimeProfiler.ExecuteAndProfile(ExecuteLinqQuerySyntaxApproachImpl);

            result.SetQueryType(QueryType.LinqQuerySyntax);

            return result;
        }

        public virtual ExecutionResult ExecuteAdoApproach()
        {
            var result =
                ExecutionTimeProfiler.ExecuteAndProfile(ExecuteAdoApproachImpl);

            result.SetQueryType(QueryType.Sql);

            return result;
        }


        protected abstract QueryResult ExecuteLinqMethodSyntaxApproachImpl();
        protected abstract QueryResult ExecuteLinqQuerySyntaxApproachImpl();
        protected virtual QueryResult ExecuteAdoApproachImpl()
        {
            var result = AdoExecutor.Execute(SqlQuery);

            return result;
        }

        public override string ToString()
        {
            return $"// Linq Method Syntax\r\n{LinqMethodSyntaxQuery}\r\n\r\n// Linq Query Syntax\r\n{LinqQuerySyntaxQuery}\r\n\r\n------- SQL Query\r\n{SqlQuery}\r\n----- SQL Query\r\n";
        }
    }
}