using System;
using System.Data.SQLite;

namespace Labrador
{
    public class Backyard : IBackyard
    {
        private string _connectionString;

        public Backyard(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IRetriever PlayTime()
        {
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            return new Retriever(connection, new BoneAdapterFactory());
        }

        public ILeash<IRetriever> PlayTimeOnLeash()
        {
            throw new NotImplementedException();
        }
    }
}
