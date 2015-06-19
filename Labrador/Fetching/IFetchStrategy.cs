using System.Collections.Immutable;
using System.Data;

namespace Labrador.Fetching
{
    public interface IFetchStrategy
    {
        // A fetch strategy cuidará da parte de joins (select)
        // E o Retriever tem uma referencia pra um bone adapter
        // que transforma o resultado da base em uma entidade.
        
        // Como a princípio o Retriever vai fazer a conversão das
        // FKs também, ele deve ter um certo vinculo com a fetch
        // strategy, pois se a fetch strategy faz join o adapter
        // tem que converter esse join.

        // E até porque o nome dos parâmetros da query vai ser
        // usado na conversão dos registros (boneadapter)

        string Command { get; }

        IImmutableList<IFetchRule> FetchRestrictions { get; }
    }

    public interface IFetchRule
    {
        string Field { get; }
        object Value { get; }
    }
}
