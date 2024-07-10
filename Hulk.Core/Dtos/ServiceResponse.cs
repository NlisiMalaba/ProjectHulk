namespace Hulk.Core.Dtos
{
    public class ServiceResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public DateTime Time { get; set; }
        public T? Data { get; set; }

        public ServiceResponse() { }
        public ServiceResponse(T data, string message)
        {
            IsSuccess = true;
            Message = message;
            Time = DateTime.UtcNow;
            Data = data;
        }
    }
}
