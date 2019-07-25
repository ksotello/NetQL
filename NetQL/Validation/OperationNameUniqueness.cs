using System.Text.RegularExpressions;
using System.Collections;
using System;

namespace NetQL.Validation
{
    public class OperationNameUniqueness : IValidation
    {
        /// <summary>
        /// 5.2.1.1 Operation Name Uniqueness
        /// Formal Specification
        /// 
        /// For each operation definition operation in the document.
        ///   Let operationName be the name of operation.
        /// 
        /// If operationName exists
        ///   Let operations be all operation definitions in the document named operationName.
        /// 
        /// Operations must be a set of one.
        /// </summary>
        /// <returns></returns>
        public bool IsValid(string document)
        {
            string[] operations = { "query", "mutation", "subscription" };
            ArrayList matches = new ArrayList();

            foreach(string operation in operations)
            {
                MatchCollection operationMatch = GetMatch(new Regex(operation + ".*\\w"), document);

                foreach (Match match in operationMatch)
                {
                    string name = match.Value.Split(operation)[1];
                    MatchCollection nameMatches = GetMatch(new Regex(name), document);

                    if (nameMatches.Count > 1)
                    {
                        matches.Add(nameMatches);
                    }
                }
            }

            return matches.Count == 0;
        }

        /// <summary>
        /// Get an array of matches based on the regex provided if
        /// found within the document.
        /// </summary>
        /// <param name="regex"></param>
        /// <param name="document"></param>
        /// <returns>An array of matches if they exist; else an empty array</returns>
        private MatchCollection GetMatch(Regex regex, string document)
        {
            return regex.Matches(document);
        }
    }
}
