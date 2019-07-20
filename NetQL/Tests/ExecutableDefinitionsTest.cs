using NUnit.Framework;
using NetQL.Validation;

namespace NetQL.Tests
{
    [TestFixture]
    public class ExecutableDefinitionsTest
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

        private string ValidDocument()
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

        private string InValidDocument()
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
