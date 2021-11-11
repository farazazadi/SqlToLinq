using System;
using System.Diagnostics;
using SqlToLinq.Core.Common.Models;

namespace SqlToLinq.Core.Common
{
    public static class ExecutionTimeProfiler
    {
        private static readonly Stopwatch Stopwatch = new();

        public static ExecutionResult ExecuteAndProfile(Func<QueryResult> func)
        {
            Stopwatch.Restart();

            var queryResult = func.Invoke();

            Stopwatch.Stop();

            var executionResult = new ExecutionResult(queryResult.Result, queryResult.SqlQuery,
                TimeSpan.FromTicks(Stopwatch.ElapsedTicks));

            return executionResult;
        }
    }
}