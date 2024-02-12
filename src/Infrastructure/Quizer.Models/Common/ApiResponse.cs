using System.Net;

namespace Quizer.Models.Common;

public class ApiResponse
{
    public HttpStatusCode StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public Dictionary<string,string> Errors { get; set; }

    public static ApiResponse Success(string message=null,HttpStatusCode httpStatusCode=HttpStatusCode.OK)
    {
       
        return new() {StatusCode=httpStatusCode,IsSuccess=true,Message=message };
    }
    public static ApiResponse<T> Success<T>(T data,string message = null, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        where T:class
    {

        return new() { StatusCode=httpStatusCode, IsSuccess=true, Message=message,Data= data};
    }
    public static ApiResponse Fail(string message = null, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
    {

        return new() { StatusCode=httpStatusCode, IsSuccess=false, Message=message };
    }
    public static ApiResponse Fail(Dictionary<string,string> errors,string message = null, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
    {
        return new() { StatusCode=httpStatusCode, IsSuccess=false, Message=message,Errors=errors };
    }
}
