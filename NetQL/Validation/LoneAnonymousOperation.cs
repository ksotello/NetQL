using System.Text.RegularExpressions;

namespace NetQL.Validation
{
    public class LoneAnonymousOperation : IValidation
    {
        /// <summary>
        /// 5.2.2.1Lone Anonymous Operation
        ///
        /// Formal Specification
        /// 
        /// Let operations be all operation definitions in the document.
        /// Let anonymous be all anonymous operation definitions in the document.
        /// If operations is a set of more than 1:
        ///     - anonymous must be empty.
        ///
        /// Explanatory Text
        ///
        /// GraphQL allows a short‐hand form for defining query operations when
        /// only that one operation exists in the document.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public bool IsValid(string document)
        {
            Regex shorthandRegex = new Regex("/^{/");
            Regex operationsRegex = new Regex("/(query|mutation|subscription)/");

            MatchCollection shorthandMatch = shorthandRegex.Matches(document);
            MatchCollection operationsMatch = operationsRegex.Matches(document);

            return shorthandMatch.Count == 0 && operationsMatch.Count > 0;
        }
    }
}
