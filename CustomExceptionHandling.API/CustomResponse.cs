namespace CustomExceptionHandlingMiddleware.API
{
    public class CustomResponse<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public static CustomResponse<T> Fail(string errorMessage)
        {
            return new CustomResponse<T> { Succeeded = false, Message = errorMessage };
        }
        public static CustomResponse<T> Success(T data)
        {
            return new CustomResponse<T> { Succeeded = true, Data = data };
        }
    }
}
