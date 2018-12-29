using System;
using System.Data;
using System.Data.Common;
using WebApiCore.Data.Infrastructure;

namespace WebApiCore.Data
{
    public class MsSqlConnectionFactory : IConnectionFactory
    {
        private static readonly string ConnectionString = Common.Infrastructure.ConnectionString.GetConfig("WebApiCore.Data.SqlConn"); // ConfigHelper.ConnectionString;

        public IDbConnection GetConnection
        {
            get
            {
                if (string.IsNullOrEmpty(ConnectionString))
                {
                    throw new ArgumentException("No connection string provided for MsSqlConnection.");
                }
                var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                var conn = factory.CreateConnection();
                if (conn != null)
                {
                    conn.ConnectionString = ConnectionString;
                    //conn.Open();
                    return conn;
                }
                throw new ApplicationException("MsSqlConnection was not successfully created by the factory.");
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ConnectionFactory() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
