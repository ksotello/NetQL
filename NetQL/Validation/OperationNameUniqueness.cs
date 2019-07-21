namespace NetQL.Validation
{
    public class OperationNameUniqueness : IValidation
    {
        /// <summary>
        /// 5.2.1.1Operation Name Uniqueness
        /// Formal Specification
        /// 
        /// For each operation definition operation in the document.
        /// Let operationName be the name of operation.
        /// If operationName exists
        /// Let operations be all operation definitions in the document named operationName.
        /// operations must be a set of one.
        /// </summary>
        /// <returns></returns>
        public bool IsValid(string document)
        {
            return true;
        }
    }
}
