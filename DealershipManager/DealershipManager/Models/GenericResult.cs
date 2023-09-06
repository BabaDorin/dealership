namespace DealershipManager.Models
{
    public class GenericResult<TResult> : Result
    {
        public TResult Result { get; }

        private GenericResult(bool isSuccess, string? errorMessage, TResult? result)
            : base(isSuccess, errorMessage)
        {
            Result = result;
        }

        public static GenericResult<TResult> Success(TResult? result)
        {
            return new GenericResult<TResult>(true, null, result);
        }

        public static GenericResult<TResult> Fail(string errorMessage)
        {
            return new GenericResult<TResult>(false, errorMessage, default);
        }
    }
}
