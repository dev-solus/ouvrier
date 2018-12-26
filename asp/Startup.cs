using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using asp.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using System.IO;
using asp.SignalR;
using asp3.Models.Repository;
using asp.Models;
using asp3.Models.DataManager;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace asp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                // options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
            services.AddScoped<IDataRepository<User>, UserManager>();
            // services.AddAutoMapper();
            services.AddSignalR();

            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.ConfigureDbContext(Configuration, "DefaultConnection");
            services.ConfigureAuthentication(Configuration);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                Console.WriteLine(">>>>>>>>>>>>>>> " + env.EnvironmentName);
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();
            app.UseCors("CorsPolicy");
            app.UseSignalR(routes =>
            {
                routes.MapHub<Like>("/like");
                routes.MapHub<CommentHub>("/CommentHub");
                routes.MapHub<CountComment>("/CountComment");
            });



            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                // c.RoutePrefix = string.Empty;
            });

            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 404
                    && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
// heroku login 
// git init 
// heroku git:remote -a ouvrier 
// git add . 
// git commit -am 'better5' 
// heroku buildpacks:set https://github.com/jincod/dotnetcore-buildpack 
// heroku buildpacks:set jincod/dotnetcore 
// git push heroku master
