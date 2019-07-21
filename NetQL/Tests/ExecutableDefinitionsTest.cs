using NUnit.Framework;
using NetQL.Validation;

namespace NetQL.Tests
{
    [TestFixture]
    public class ExecutableDefinitionsTest : ITest
    {
        [Test]
        public void ReturnsTrueForAValidDocument()
        {
            ExecutableDefinitions executableDefinitions = new ExecutableDefinitions();
            Assert.IsTrue(executableDefinitions.IsValid(ValidDocument()));
        }

        [Test]
        public void ReturnsFalseForAnInValidDocument()
        {
            ExecutableDefinitions executableDefinitions = new ExecutableDefinitions();
            Assert.IsFalse(executableDefinitions.IsValid(InValidDocument()));
        }

        public string ValidDocument()
        {
            return @"
                query getDogName {
                  dog {
                    name
                    color
                  }
                }
            ";
        }

        public string InValidDocument()
        {
            return @"
                query getDogName {
                  dog {
                    name
                    color
                  }

                  extend type Dog {
                    color: String
                  }
                }
            ";
        }
    }
}
