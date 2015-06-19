using System.Data;

namespace Labrador.Fetching
{
    public class FetchStrategyResolver : IFetchStrategyResolver
    {
        public IDbCommand Resolve(IDbConnection connection, IFetchStrategy fetchStrategy)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = fetchStrategy.Command;
            return cmd;
        }
    }

}
