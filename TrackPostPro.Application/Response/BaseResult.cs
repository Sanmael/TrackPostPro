namespace Aplication.Response
{
    public class BaseResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public BaseResult(bool success = true, string? message = null)
        {
            Success = success;
            Message = message;
        }
    }

    public class BaseResult<T> : BaseResult
    {
        public T? Data { get; }

        public BaseResult(T? data = default, string message = "", bool success = true)
            : base(success, message)
        {
            Data = data;
        }
    }
}
