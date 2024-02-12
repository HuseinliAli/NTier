using Quizer.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();
app.AddGlobalErrorHandling();
if (!app.Environment.IsDevelopment())
{

}


app.Run();
