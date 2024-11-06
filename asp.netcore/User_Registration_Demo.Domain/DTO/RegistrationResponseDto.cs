namespace User_Registration_Demo.Domain.DTO
{
    public class ResponseDto<T>
    {
        public bool Success { get; set; } 
        public T Data { get; set; } 
        public string Message { get; set; } 
        public List<string> Errors { get; set; }

        public ResponseDto()
        {
            Errors = new List<string>();
        }

        public ResponseDto(T data, bool success = true, string message = "")
        {
            Success = success;
            Data = data;
            Message = message;
            Errors = new List<string>();
        }

        public ResponseDto(string message, List<string> errors)
        {
            Success = false;
            Data = default;
            Message = message;
            Errors = errors ?? new List<string>();
        }

        public static ResponseDto<T> SuccessResponse(T data, string message = "")
        {
            return new ResponseDto<T>(data, true, message);
        }

        public static ResponseDto<T> FailureResponse(string message, List<string> errors = null)
        {
            return new ResponseDto<T>(message, errors);
        }

    }
}
