using Labrador.Fetching;
using System.Collections.Immutable;

namespace Labrador.Sample
{
    public class UserFetchStrategy : IFetchStrategy
    {

        public string Command
        {
            get { return "SELECT * FROM USERS"; }
        }

        public IImmutableList<IFetchRule> FetchRestrictions
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
