using API;
using API.Filters;
using Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SQLServer;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add<FilterException>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Catalogo de produtos",
        Description = "Catalogo de produtos com categorias e autenticação"
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

#region DI
builder.Services.AddSQLServerModule(Environment.GetEnvironmentVariable("CONNECTION_STRING_SQL_SERVER"));
builder.Services.AddRedisModule(Environment.GetEnvironmentVariable("REDIS_CONNECTION"));
builder.Services.AddReositoryModule();
builder.Services.AddServicesModule();
builder.Services.AddPresenterModule();
#endregion

#region CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("autenticacaoCors",
        provider =>
        {
            provider.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
#endregion

#region JWT
var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("TOKEN_SECRET"));
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
}); ;
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseCors("autenticacaoCors");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
