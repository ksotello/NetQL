using NUnit.Framework;
using NetQL.Validation;
namespace NetQL.Tests.Utilities
{
    internal static class Assertions
    {
        internal static void HasValidDocuments(string[] documents, IValidation validation)
        {
            foreach (string document in documents)
            {
                Assert.IsTrue(validation.IsValid(document));
            }
        }

        internal static void HasInValidDocuments(string[] documents, IValidation validation)
        {
            foreach(string document in documents)
            {
                Assert.IsFalse(validation.IsValid(document));
            }
        }
    }
}
