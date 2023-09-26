using TrackPostPro.Application.Response;

namespace Aplication.Response
{
    public class BaseResult<T> : IBaseResult<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; }

        public BaseResult(T? data = default, string message = "", bool success = true)
        {
            Message = message; 
            Success = success;
            Data = data;
        }
    }
}
