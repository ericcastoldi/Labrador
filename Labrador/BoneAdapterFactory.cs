using Labrador.Fetching;
using Labrador.Sample;

namespace Labrador
{
    public class BoneAdapterFactory : IBoneAdapterFactory
    {
        public IBoneAdapter<T> Create<T>()
        {
            return new UserBoneAdapter() as IBoneAdapter<T>;
        }
        // TODO: Resolver esta factory com arquivo de configuração.
        public IBoneAdapter<T> Create<T>(IFetchStrategy fetchStrategy)
        {
            return new UserBoneAdapter() as IBoneAdapter<T>;
        }
    }
}
