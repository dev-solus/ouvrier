using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Hubs;

namespace Services
{
    public static class ServiceExtension
    {

        public static void AddDbContext(this IServiceCollection services, IConfiguration Configuration, string ConnectionString)
        {
            services.AddDbContext<MyContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString(ConnectionString), op => op.CommandTimeout(60));
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            });

        }

        public static void AddSwaggerGen(this IServiceCollection services, string Title, string Description, string Version = "v1")
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = Title,
                    Version = Version,
                    Description = Description,
                    Contact = new OpenApiContact
                    {
                        Name = "Mohamed Mourabit",
                        Email = "mohamed.mourabit@outlook.com"
                    }
                });

                // article thta hepled me in this one
                // https://codeburst.io/api-security-in-swagger-f2afff82fb8e
                // add JWT Authentication
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
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
        }

        public static void AddAuthentication(this IServiceCollection services, IConfiguration Configuration, string ConnectionString = "sqlite")
        {



            var key = Encoding.ASCII.GetBytes(Configuration["AppSettings:Secret"]);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(options =>
           {
               //    options.Events = new JwtBearerEvents
               //    {
               //        OnTokenValidated = context =>
               //        {
               //                  var route = context.HttpContext.Request.RouteValues;
               //                 //  var userId = int.Parse(context.Principal.Identity.Name);
               //                 //  var user = userService.GetById(userId);
               //                 //  if (user == null)
               //                 //  {
               //                 //      // return unauthorized if user no longer exists
               //                 //      context.Fail("Unauthorized");
               //                 //  }
               //               return Task.CompletedTask;
               //        }
               //    };

               options.Events = new JwtBearerEvents
               {
                   OnAuthenticationFailed = context =>
                   {
                       if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                       {
                           context.Response.Headers.Add("Token-Expired", "true");
                       }
                       return Task.CompletedTask;
                   }
               };
               /**
                  * this just for the sake of signalR
                  */
               options.Events = new JwtBearerEvents
               {
                   OnMessageReceived = context =>
                   {
                       var accessToken = context.Request.Query["access_token"];
                       if (string.IsNullOrEmpty(accessToken) == false)
                       {
                           context.Token = accessToken;
                       }
                       return Task.CompletedTask;
                   }
               };

               options.RequireHttpsMetadata = false;
               options.SaveToken = true;
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });
        }

    }
}