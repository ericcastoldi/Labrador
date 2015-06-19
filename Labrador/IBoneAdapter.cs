using System.Data;

namespace Labrador
{
    public interface IBoneAdapter<T>
    {
        T Resolve(IDataRecord dataRecord);
    }

}
