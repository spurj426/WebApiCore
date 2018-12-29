using System;
using System.Data;

namespace WebApiCore.Data.Infrastructure
{
    public interface IConnectionFactory : IDisposable
    {
        IDbConnection GetConnection { get; }
    }
}
