using NUnit.Framework;
using NetQL.Validation;
using NetQL.Tests.Utilities;

namespace NetQL.Tests
{
    [TestFixture]
    public class OperationNameUniquenessTest : ITest
    {
        [Test]
        public void HasUniqueOperationNames()
        {
            OperationNameUniqueness operationNameUniqueness = new OperationNameUniqueness();
            Assertions.HasValidDocuments(ValidDocuments(), operationNameUniqueness);
        }

        [Test]
        public void HasNoUniqueOperationNames()
        {
            OperationNameUniqueness operationNameUniqueness = new OperationNameUniqueness();
            Assertions.HasInValidDocuments(InValidDocuments(), operationNameUniqueness);
        }

        public string[] ValidDocuments()
        {
            string[] validDocuments =
            {
                @"
                query getDogName {
                  dog {
                    name
                  }
                }

                query getOwnerName {
                  dog {
                    owner {
                      name
                    }
                  }
                }
                ",
                @"
                query getDogName {
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
            string[] invalidDocuments = {
                @"
                query getName {
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
                ",
                @"
                query dogOperation {
                  dog {
                    name
                  }
                }

                mutation dogOperation {
                  mutateDog {
                    id
                  }
                }
                ",

            };

            return invalidDocuments;
        }

    }
}
