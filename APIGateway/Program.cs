using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"); for different env,ocelot

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
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerForOcelot(builder.Configuration);

var app = builder.Build();

app.UseCors("CorsPolicy");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseOcelot().Wait();

app.UseAuthorization();

app.MapControllers();

app.Run();
