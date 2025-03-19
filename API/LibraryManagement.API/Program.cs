using Microsoft.EntityFrameworkCore;
using LibraryManagement.API.Utils;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        JWTProvider jwtProvider = JWTProvider.GetInstance(builder.Configuration);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"] ?? throw new KeyNotFoundException("SecretForKey not found in configuration"),

            ValidateAudience = true,
            ValidAudience = builder.Configuration["Authentication:Audience"] ?? throw new KeyNotFoundException("SecretForKey not found in configuration"),

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = jwtProvider.SecurityKey
        };
    });

string localClientCorsPolicy = "LocalClientCorsPolicy";
string localWebClientOrigin = builder.Configuration["CorsPolicy:Local"] ?? throw new KeyNotFoundException("CorsPolicy:Local not found in configuration");

builder.Services.AddCors(options =>
{
    options.AddPolicy(localClientCorsPolicy,
        builder => builder.WithOrigins(localWebClientOrigin)
        .AllowAnyHeader()
        .AllowAnyMethod()
        );
});

builder.Services.AddAuthorization();

string connectionString = builder.Configuration.GetConnectionString("LibraryManagement") ??
    throw new InvalidOperationException("Connection string LibraryManagement not found.");

builder.Services.AddDbContext<LibraryManagementContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddLibraryManagementRepositories();
builder.Services.AddLibraryManagementServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors(localClientCorsPolicy);

app.UseClientSecretValidation();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();

