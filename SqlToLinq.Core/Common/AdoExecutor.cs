using System.Data;
using Microsoft.Data.SqlClient;
using SqlToLinq.Core.Common.Models;
using SqlToLinq.Core.Interfaces;

namespace SqlToLinq.Core.Common
{
    public class AdoExecutor : IAdoExecutor
    {
        public QueryResult Execute(string query)
        {
            using var sqlConnection = new SqlConnection(ConnectionStrings.AdoConnectionString);

            using var sqlCommand = new SqlCommand(query, sqlConnection);

            using var sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            var dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            return new QueryResult(dataTable, query);
        }
    }
}