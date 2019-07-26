namespace NetQL.Tests
{
    public interface ITest
    {
        /// <summary>
        /// Used to return a valid document to be parsed
        /// </summary>
        /// <returns>An array of valid documents</returns>
        string[] ValidDocuments();

        /// <summary>
        /// Used to return an valid document to be parsed
        /// </summary>
        /// <returns>An array of invalid documents</returns>
        string[] InValidDocuments();
    }
}
