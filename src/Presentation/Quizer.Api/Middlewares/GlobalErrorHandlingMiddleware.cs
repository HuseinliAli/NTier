using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Quizer.Core.Exceptions;
using Quizer.Models.Common;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Quizer.Api.Middlewares;

internal class GlobalErrorHandlingMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
			ApiResponse response = new ApiResponse();
			switch (ex)
			{
				case NotFoundException:
					response = ApiResponse.Fail(ex.Message,HttpStatusCode.NotFound);
                    break;
				case BadRequestException:
                    response = ApiResponse.Fail(ex.Message, HttpStatusCode.BadRequest);
                    break;
				case UnhandledException:
				default:
					response = ApiResponse.Fail(ex.Message);
					break;
			}

			context.Response.ContentType="application/json";
			context.Response.StatusCode=(int)response.StatusCode;
			await context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings
			{
				ContractResolver = new DefaultContractResolver
				{
					NamingStrategy=new CamelCaseNamingStrategy()
				},
				NullValueHandling=NullValueHandling.Ignore
			})); ;
		}
    }
}
