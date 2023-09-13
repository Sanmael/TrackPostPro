namespace Aplication.Response
{
    public class BaseResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public BaseResult(bool success = true , string message = "")
        {
            Success = success;
            Message = message;
        }

    }
    public class BaseResult<T> : BaseResult
    {
        public BaseResult(T data,bool success = true,string message = "") : base(success,message)         
        {
            Data = data;
        }
        public T Data { get; set; }
    }
}
