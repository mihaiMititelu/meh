using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Dapper;

namespace FileHolder.DataAccess
{
    public class Repository : IRepository
    {
        protected IDbConnection Connection;
        protected string connectionString =
            "Data Source=MIHAI-PC;Initial Catalog=FIleHolder.Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int Add<T>(T item)
        {
            var columns = GetColumns<T>();

            var query = $"INSERT INTO {typeof(T).BaseType.Name}s ({string.Join(", ", columns)}) VALUES ({string.Join(", ", columns.Select(c => "@" + c))})";

            using (Connection = new SqlConnection(connectionString))
            {
                return Connection.Execute(query, item);
            }
        }

        public int Update<T>(T item)
        {
            var columns = GetColumns<T>();

            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));

            var query = $"update {typeof(T).BaseType.Name}s set {stringOfColumns} where Id = @Id";

            using (Connection = new SqlConnection(connectionString))
            {
                return Connection.Execute(query, item);
            }
        }

        public void Delete<T>(T item)
        {
            var query = $"delete from {typeof(T).BaseType.Name}s where Id = @Id";
            using (Connection = new SqlConnection(connectionString))
            {
                Connection.Execute(query, item);
            }
        }

        public IEnumerable<T> GetAll<T>()
        {
            var query = $"select * from {typeof(T).Name}s";
            using (Connection = new SqlConnection(connectionString))
            {
                return Connection.Query<T>(query);
            }
        }

        private IEnumerable<string> GetColumns<T>()
        {
            return typeof(T)
                .GetProperties()
                .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
                .Select(e => e.Name);
        }
    }
}
