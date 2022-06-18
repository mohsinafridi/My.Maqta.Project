using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;


var builder = WebApplication.CreateBuilder(args);



builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
    builder => builder.WithOrigins("http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
});


builder.Services.AddAuthentication().AddJwtBearer("employees_auth_scheme", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_employee_api_secret")),
        ValidAudience = "employeeAudience",
        ValidIssuer = "employeesIssuer",
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };

});

builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

app.UseCors("CorsPolicy");
app.UseOcelot();


// app.MapGet("/", () => "Hello World!");


app.MapControllers();

app.Run();
