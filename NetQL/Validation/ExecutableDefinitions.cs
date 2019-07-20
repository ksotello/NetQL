﻿using System.Text.RegularExpressions;
using System;

namespace NetQL.Validation
{
    internal class ExecutableDefinitions
    {
        /// <summary>
        /// 5.1.1Executable Definitions
        /// 
        /// Formal Specification
        ///
        /// For each definition definition in the document.
        /// definition must be OperationDefinition or
        /// FragmentDefinition (it must not be TypeSystemDefinition).
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public bool IsValid(string document)
        {
            Regex typesRegex = new Regex(@"\s{2}?type");
            Regex typeExtensionsRegex = new Regex(@"extend");

            MatchCollection typeExtensions = typeExtensionsRegex.Matches(document);
            MatchCollection types = typesRegex.Matches(document);


            if (typeExtensions.Count > 0)
            {
                return typeExtensions.Count <= types.Count;
            }


            return true;
        }
    }
}
