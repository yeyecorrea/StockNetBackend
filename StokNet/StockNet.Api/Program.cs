using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StockNet.Application.DTOs.Dashboard;
using StockNet.Business.Interfaces;
using StockNet.Business.Interfaces.Dashboard;
using StockNet.Business.Mapping;
using StockNet.Business.Services;
using StockNet.Business.Services.Auth;
using StockNet.Business.Services.Dashboard;
using StockNet.Data.DataContext;
using StockNet.Data.Interfaces;
using StockNet.Data.Interfaces.Dashboard;
using StockNet.Data.Repository;
using StockNet.Data.Repository.Dashboard;
using StockNet.Domain.Entities;
using StockNet.Shared.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add dbcontext with SQl provider
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddScoped<IJwtGenerator, JwtGenerator>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Add base services
builder.Services.AddScoped<IBaseService<Negocio, BusinessDto>, BaseService<Negocio, BusinessDto>>();
builder.Services.AddScoped<IBaseService<Cliente, CustomerDto>, BaseService<Cliente, CustomerDto>>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IBusinessService, BusinessService>();

// Add base repository
builder.Services.AddScoped<IBaseRepository<int, Negocio>, BaseRespository<int, Negocio>>();
builder.Services.AddScoped<IBaseRepository<int, Cliente>, BaseRespository<int, Cliente>>();

// Add repository
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// add identity services
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>();

// add httpContext
builder.Services.AddHttpContextAccessor();

// Add authentication with JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = JwtConfig.GetTokenValidationParameters(builder.Configuration);
});

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// add cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        builder => builder.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "StockNet API", Version = "v1" });

    // Configurar seguridad JWT para Swagger
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Ingresa tu token JWT. Ejemplo: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});




var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "StockNet API V1");
});


app.UseHttpsRedirection();

app.UseCors("AllowAngular");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
