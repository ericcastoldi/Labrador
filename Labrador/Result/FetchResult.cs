using System.Collections.Immutable;

namespace Labrador.Result
{
    public class FetchResult<T> : IFetchResult<T>
    {
        private IImmutableList<T> _resultSet;
        private int _affected;

        public FetchResult(IImmutableList<T> resultSet)
        {
            _affected = resultSet.Count;
            _resultSet = resultSet;
        }

        public IImmutableList<T> ResultSet
        {
            get { return _resultSet; }
        }

        public int Affected
        {
            get { return _affected; }
        }
    }

}
