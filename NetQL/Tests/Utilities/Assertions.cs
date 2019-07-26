using NUnit.Framework;
using NetQL.Validation;
namespace NetQL.Tests.Utilities
{
    internal static class Assertions
    {
        internal static void HasValidDocuments(string[] documents, IValidation validation)
        {
            ExecutableDefinitions executableDefinitions = new ExecutableDefinitions();
            foreach (string document in documents)
            {
                Assert.IsTrue(executableDefinitions.IsValid(document));
            }
        }

        internal static void HasInValidDocuments(string[] documents, IValidation validation)
        {
            ExecutableDefinitions executableDefinitions = new ExecutableDefinitions();
            foreach(string document in documents)
            {
                Assert.IsFalse(!executableDefinitions.IsValid(document));
            }
        }
    }
}
