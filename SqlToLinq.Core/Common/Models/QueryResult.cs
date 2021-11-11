namespace SqlToLinq.Core.Common.Models
{
    public class QueryResult
    {
        public dynamic Result { get; init; }
        public string SqlQuery { get; init; }

        public QueryResult(dynamic result, string sqlQuery)
        {
            Result = result;
            SqlQuery = sqlQuery;
        }

    }
}