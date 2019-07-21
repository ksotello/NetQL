using System;
namespace NetQL.Tests
{
    public interface ITest
    {
        /// <summary>
        /// Used to return a valid document to be parsed
        /// </summary>
        /// <returns></returns>
        string ValidDocument();

        /// <summary>
        /// Used to return an valid document to be parsed
        /// </summary>
        /// <returns></returns>
        string InValidDocument();
    }
}
