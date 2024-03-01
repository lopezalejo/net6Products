namespace ARAINV.Infrastructure.Wrappers
{
    public class ApiResponse<T>
    {
        public ApiResponse() { }

        public ApiResponse(T data, string message = null)
        {
            Succeded = true;
            Message = message;
            Data = data;
        }

        public ApiResponse(string message, bool isOk = false)
        {
            Succeded = isOk;
            Message = message;
        }

        public bool Succeded { get; set; }
        public string Message { get; set; }
        public IReadOnlyDictionary<string, string[]> Errors { get; set; }
        public T Data { get; set; }
    }
}
