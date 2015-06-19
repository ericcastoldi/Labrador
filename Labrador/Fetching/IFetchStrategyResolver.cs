using System.Data;

namespace Labrador.Fetching
{
    internal interface IFetchStrategyResolver
    {
        // Transforma uma FetchStrategy em um IDbCommand
        // Verifica se existem Sub-Strategys (sub-queries)
        // Caso existam, executa as sub queries e gerencia a
        // corrente de queries e conversões
        IDbCommand Resolve(IDbConnection connection, IFetchStrategy fetchStrategy);
    }
}
