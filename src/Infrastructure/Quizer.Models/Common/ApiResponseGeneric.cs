namespace Quizer.Models.Common;

public class ApiResponse<T> : ApiResponse
    where T:class
{
    public T Data { get; set; }
}