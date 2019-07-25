using NUnit.Framework;
using NetQL.Validation;
using NetQL.Tests.Utilities;

namespace NetQL.Tests
{
    [TestFixture]
    public class ExecutableDefinitionsTest : ITest
    {
        [Test]
        public void ReturnsTrueForAValidDocument()
        {
            ExecutableDefinitions executableDefinitions = new ExecutableDefinitions();
            Assertions.HasValidDocuments(ValidDocuments(), executableDefinitions);
        }

        [Test]
        public void ReturnsFalseForAnInValidDocument()
        {
            ExecutableDefinitions executableDefinitions = new ExecutableDefinitions();
            Assertions.HasInValidDocuments(InValidDocuments(), executableDefinitions);
        }

        public string[] ValidDocuments()
        {
            string[] validDocuments =
            {
                @"
                query getDogName {
                  dog {
                    name
                    color
                  }
                }
                ",
                @"
                {
                  dog {
                    name
                    color
                  }
                }
                "
            };

            return validDocuments;
        }

        public string[] InValidDocuments()
        {
            string[] invalidDocuments =
            {
                @"
                query getDogName {
                  dog {
                    name
                    color
                  }

                  extend type Dog {
                    color: String
                  }
                }
                "
            };

            return invalidDocuments;
        }
    }
}
