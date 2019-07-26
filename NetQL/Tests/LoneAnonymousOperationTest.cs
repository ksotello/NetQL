using NUnit.Framework;
using NetQL.Tests.Utilities;
using NetQL.Validation;

namespace NetQL.Tests
{
    [TestFixture]
    public class LoneAnonymousOperationTest : ITest
    {
        [Test]
        public void AllowsForShortHand()
        {
            LoneAnonymousOperation loneAnonymousOperation = new LoneAnonymousOperation();
            Assertions.HasValidDocuments(ValidDocuments(), loneAnonymousOperation);
        }

        [Test]
        public void CannotMixShortHand()
        {
            LoneAnonymousOperation loneAnonymousOperation = new LoneAnonymousOperation();
            Assertions.HasInValidDocuments(InValidDocuments(), loneAnonymousOperation);
        }

        public string[] ValidDocuments()
        {
            string[] validDocuments =
            {
                @"
                {
                  dog {
                    name
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
                {
                  dog {
                    name
                  }
                }

                query getName {
                  dog {
                    owner {
                      name
                    }
                  }
                }
                "
            };

            return invalidDocuments;
        }
    }
}
