using System.Collections.Generic;
using System.Linq;
using Microsoft.Build.Logging.StructuredLogger;

namespace Microsoft.Build.Logging.StructuredLogger
{
    public class SearchResultSet
    {
        private readonly HashSet<BaseNode> resultSet;
        private readonly HashSet<BaseNode> ancestorNodes = new HashSet<BaseNode>();

        public static SearchResultSet Empty { get; } = new SearchResultSet(Enumerable.Empty<BaseNode>());

        public SearchResultSet(IEnumerable<BaseNode> searchResults)
        {
            resultSet = new HashSet<BaseNode>(searchResults);

            foreach (var node in resultSet)
            {
                var current = node.Parent;
                while (current != null && ancestorNodes.Add(current))
                {
                    current = current.Parent;
                }
            }
        }

        public bool IsSearchResult(BaseNode node)
            => resultSet.Contains(node);

        public bool ContainsSearchResult(BaseNode node)
            => ancestorNodes.Contains(node);
    }
}
