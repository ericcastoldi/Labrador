using Labrador.Fetching;

namespace Labrador
{
    public interface IBoneAdapterFactory
    {
        IBoneAdapter<T> Create<T>();


        // Como comentado no IFetchStragety, o boneadapter e o
        // fetchstrategy provavelmente terão algum vinculo.
        // Este método receberia uma fetch strategy e saberia 
        // retornar o adapter mais adequado a aquela strategy.
        // Pois uma strategy sem join não exigiria uma conversão
        // de uma propriedade de tipo complexo (FK)
        IBoneAdapter<T> Create<T>(IFetchStrategy fetchStrategy);

    }
}
