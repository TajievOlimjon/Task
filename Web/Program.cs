using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence.Data;
using Services.AccountServices;
using Services.EntitiesServices;
using Services.EntitiesServices.UserServices;
using Services.MapperServices;
using Web.HalperMethods;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConecction");
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connection));

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IWalletService,WalletService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<AccountService>();

builder.Services.AddAutoMapper(typeof(EntitiesMapper));

builder.Services.AddedAutorizeService(builder);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
 builder.Services.AddSwaggerGen(c =>
 {
         c.SwaggerDoc("v1", new OpenApiInfo
         {
             Title = "Sample web API",
             Version = "v1",
             Description = "Sampme API Services.",
             Contact = new OpenApiContact
             {
                 Name = "Tajiev Olimjon."
             },
         });
         c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
         c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
         {
             Name = "Authorization",
             Type = SecuritySchemeType.ApiKey,
             Scheme = "Bearer",
             BearerFormat = "JWT",
             In = ParameterLocation.Header,
             Description = "JWT Authorization header using the Bearer scheme."
         });

          c.AddSecurityRequirement(new OpenApiSecurityRequirement
              {
                  {
                      new OpenApiSecurityScheme
                      {
                          Reference = new OpenApiReference
                          {
                              Type = ReferenceType.SecurityScheme,
                              Id = "Bearer"
                          }
                      },
                      new string[] {}
                  }
              }
          );
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
