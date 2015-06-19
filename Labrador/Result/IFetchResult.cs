using System.Collections.Immutable;

namespace Labrador.Result
{
    public interface IFetchResult<T> : IResult
    {
        IImmutableList<T> ResultSet { get; }
    }
}
