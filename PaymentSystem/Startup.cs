
using System.Reflection;
using System.Text;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PaymentSystem.Base.Token;
using PaymentSystem.Business.Cqrs;
using PaymentSystem.Business.Mapper;
using PaymentSystem.Business.Validator;
using PaymentSystem.Data;
using Hangfire;
using Hangfire.PostgreSql;

namespace PaymentSystem;

public class Startup
{
    public IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        string connection = Configuration.GetConnectionString("MsSqlConnection");
        services.AddDbContext<PaymentSystemDbContext>(options => options.UseSqlServer(connection));
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateEmployeeExpenseCommand).GetTypeInfo().Assembly));

        var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MapperConfig()));
        services.AddSingleton(mapperConfig.CreateMapper());
    
        services.AddControllers().AddFluentValidation(x =>
        {
            x.RegisterValidatorsFromAssemblyContaining<CreateTokenValidator>();
            x.RegisterValidatorsFromAssemblyContaining<CreateUserValidator>();
            x.RegisterValidatorsFromAssemblyContaining<CreateExpenseValidator>();
            x.RegisterValidatorsFromAssemblyContaining<CreateEmployeeExpenseValidator>();
            x.RegisterValidatorsFromAssemblyContaining<CreateManagerExpenseValidator>();
            x.RegisterValidatorsFromAssemblyContaining<CreateBankInfoValidator>();
            x.RegisterValidatorsFromAssemblyContaining<CreateEmployeeExpenseRequestValidator>();
            x.RegisterValidatorsFromAssemblyContaining<CreateBankInfoRequestValidator>();

                            
        });
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddResponseCaching();
        services.AddMemoryCache();
    

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Payment System Api Management", Version = "v1.0" });

            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Payment System Management for IT Company",
                Description = "Enter JWT Bearer token **_only_**",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };
            c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { securityScheme, new string[] { } }
            });
        });
        

        JwtConfig jwtConfig = Configuration.GetSection("JwtConfig").Get<JwtConfig>();
        services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));
        
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = true;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtConfig.Issuer,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig.Secret)),
                ValidAudience = jwtConfig.Audience,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(2)
            };
        });
        
       
        // services.AddHangfire(configuration => configuration
        //     .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        //     .UseSimpleAssemblyNameTypeSerializer()
        //     .UseRecommendedSerializerSettings()
        //     .UsePostgreSqlStorage(Configuration.GetConnectionString("HangfireSqlConnection"), new PostgreSqlStorageOptions
        //     {
        //         TransactionSynchronisationTimeout = TimeSpan.FromMinutes(5),
        //         InvisibilityTimeout = TimeSpan.FromMinutes(5),
        //         QueuePollInterval = TimeSpan.FromMinutes(5),
        //     }));
        // services.AddHangfireServer();

    }
    
    public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        app.UseHttpsRedirection();

        app.UseResponseCaching();


        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();
        
        app.UseEndpoints(x => { x.MapControllers(); });
    }
}
