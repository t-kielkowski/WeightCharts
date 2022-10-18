namespace WeightCharts.Application
{
    public class ApiResponse<T>
    {
       public ApiResponse(T data)
        {
            IsValid = true;
            Data = data;
        }

        public ApiResponse(string errorMessage)
        {
            IsValid = false;
            ErrorMessage = errorMessage;
        }

        public bool IsValid { get; }

        public T? Data { get; }
        public string? ErrorMessage { get; }
    }
}
