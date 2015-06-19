using Labrador.Fetching;
using Labrador.Result;
using System;
using System.Collections.Immutable;
using System.Data;

namespace Labrador
{
    public class Retriever : IRetriever
    {
        private IDbConnection _connection;
        private IBoneAdapterFactory _boneAdapterFactory;

        // Por baixo dos panos esse Retriever tem uma factory de BoneAdapter que sabe tratar o T.

        public Retriever(IDbConnection connection, IBoneAdapterFactory boneAdapterFactory)
        {
            _connection = connection;
            _boneAdapterFactory = boneAdapterFactory;
        }


        public T Fetch<T>(IFetchStrategy fetchStrategy)
        {
            T entity = default(T);
            var boneAdapter = _boneAdapterFactory.Create<T>(fetchStrategy);

            this.Fetch<T>(fetchStrategy, (reader) =>
            {
                if (entity != null)
                {
                    throw new InvalidOperationException("Mais de um registro encontrado");
                }

                entity = boneAdapter.Resolve(reader);
            });

            return entity;
        }

        public IFetchResult<T> FetchMany<T>(IFetchStrategy fetchStrategy)
        {
            var boneAdapter = _boneAdapterFactory.Create<T>(fetchStrategy);
            var resultSetBuilder = ImmutableList<T>.Empty.ToBuilder();

            this.Fetch<T>(fetchStrategy, (reader) =>
            {
                resultSetBuilder.Add(boneAdapter.Resolve(reader));
            });

            var resultSet = resultSetBuilder.ToImmutable();
            return new FetchResult<T>(resultSet);
        }

        private void Fetch<T>(IFetchStrategy fetchStrategy, Action<IDataReader> resolveRecord)
        {
            IFetchStrategyResolver fetchStrategyResolver = new FetchStrategyResolver();

            var cmd = fetchStrategyResolver.Resolve(_connection, fetchStrategy);

            using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (reader.Read())
                {
                    resolveRecord(reader);
                }
            }
        }

        public ICommandResult Store<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public ICommandResult Bury<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }

}
