namespace Quizer.Api.Middlewares;

internal static class GlobalErrorHandlingMiddlewareExtension
{
	public static IApplicationBuilder AddGlobalErrorHandling(this IApplicationBuilder builder)
	{
		builder.UseMiddleware<GlobalErrorHandlingMiddleware>();
		return builder;
	}
}