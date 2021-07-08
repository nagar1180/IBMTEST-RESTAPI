using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Implementation
{
    internal sealed class DBManagerFactory
    {
        private DBManagerFactory()
        {
        }
        public static IDbConnection GetConnection()
        {
            IDbConnection iDbConnection = null;
            iDbConnection = new SqlConnection();
            return iDbConnection;
        }

        public static IDbCommand GetCommand()
        {
            return new SqlCommand();
        }

        public static IDbDataAdapter GetDataAdapter()
        {
            return new SqlDataAdapter();
        }

        public static IDbTransaction GetTransaction()
        {
            IDbConnection iDbConnection = GetConnection();
            IDbTransaction iDbTransaction = iDbConnection.BeginTransaction();
            return iDbTransaction;
        }

        public static IDataParameter GetParameter()
        {
            IDataParameter iDataParameter = null;
            iDataParameter = new SqlParameter();
            return iDataParameter;
        }

        public static IDbDataParameter[] GetParameters(int paramsCount)
        {
            IDbDataParameter[] idbParams = new IDbDataParameter[paramsCount];
            for (int i = 0; i < paramsCount; ++i)
            {
                idbParams[i] = new SqlParameter();
            }
            return idbParams;
        }
    }
}
