using Labrador.Fetching;
using Labrador.Result;
using System;

namespace Labrador
{
    public interface IRetriever : IDisposable
    {
        T Fetch<T>(IFetchStrategy fetchStrategy);

        IFetchResult<T> FetchMany<T>(IFetchStrategy fetchStrategy);

        ICommandResult Store<T>(T entity);

        ICommandResult Bury<T>(T entity);
    }
}
