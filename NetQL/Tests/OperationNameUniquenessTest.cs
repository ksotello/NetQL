using NUnit.Framework;
using NetQL.Validation;
using System;

namespace NetQL.Tests
{
    [TestFixture]
    public class OperationNameUniquenessTest : ITest
    {
        // Each named operation definition must be unique within a document when referred to by its name.
        [Test]
        public void HasUniqueOperationNames()
        {
            OperationNameUniqueness operationNameUniqueness = new OperationNameUniqueness();
            Assert.IsTrue(operationNameUniqueness.IsValid(ValidDocument()));
        }

        [Test]
        public void HasNoUniqueOperationNames()
        {
            OperationNameUniqueness operationNameUniqueness = new OperationNameUniqueness();
            Assert.IsFalse(operationNameUniqueness.IsValid(InValidDocument()));
        }

        public string ValidDocument()
        {
            return @"
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
            ";
        }

        public string InValidDocument()
        {
            Random random = new Random();
            string[] array = {
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

            return array[random.Next(0, 1)];
        }

    }
}
