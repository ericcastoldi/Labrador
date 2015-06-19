using Labrador.Result;

namespace Labrador
{
    public interface ILeash<T> where T : IRetriever
    {
        T Retriever { get; }

        IResult Commmit();

        IResult Rollback();
    }
}
