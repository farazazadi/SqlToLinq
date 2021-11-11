using SqlToLinq.Core.Common.Models;

namespace SqlToLinq.Core.Interfaces
{
    public interface IAdoExecutor
    {
        QueryResult Execute(string query);
    }
}