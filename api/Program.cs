using Services;
using Extension;
using Providers;
using Controllers;
using Hubs;
using Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{
    var services = builder.Services;
    var env = builder.Environment;
    var Configuration = builder.Configuration;

    // to handle ptoblem : .NET6 and DateTime problem. Cannot write DateTime with Kind=UTC to PostgreSQL type 'timestamp without time zone'
    // AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

    //Provide a secret key to Encrypt and Decrypt the Token
    // configure strongly typed settings objects
    var appSettingsSection = Configuration.GetSection("AppSettings");
    services.Configure<AppSettings>(appSettingsSection);
    // configure jwt authentication
    var appSettings = appSettingsSection.Get<AppSettings>();

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen("Mailing Core", "API documentation");

    services.AddDbContext(Configuration, "sqlserver");

    services.AddAuthentication(Configuration);
    services.AddAuthorization();

    services.AddScoped<Crypto>();
    services.AddScoped<MyContext>();
    services.AddScoped<TokenHandler>();
    services.AddScoped<FilesController>();
    services.AddScoped<EmailService>();
    services.AddScoped<HtmlService>();
    //test
    services.AddSignalR(o =>
            {
                o.EnableDetailedErrors = true;
                o.MaximumReceiveMessageSize = 10240; // bytes
            });
    
    services.AddHttpClient("SendinBlueApi", c =>
    {
        c.BaseAddress = new Uri(Configuration["AppSettings:SendinBlueApi"]);
        c.DefaultRequestHeaders.Add("api-key", Configuration["AppSettings:SendinBlueKey"]);
    });

    services.AddControllers().AddNewtonsoftJson();
}

var app = builder.Build();

// configure HTTP request pipeline
{
    // generated swagger json and swagger ui middleware
    // source https://christian-schou.dk/how-to-make-api-documentation-using-swagger/
    app.UseStaticFiles();
    
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // c.RoutePrefix = "/swagger";
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mailing Core API V1");
    });

    app.UseReDoc(options =>
    {   
        // options.RoutePrefix = "/api-docs";
        options.DocumentTitle = "Mailing Core API V1";
        options.SpecUrl = "/swagger/v1/swagger.json";
    });

    // global cors policy
    app.UseCors(x => x
        .SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());

    app.UseHttpsRedirection();


    // global error handler
    app.UseMiddleware<ErrorHandler>();


    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.MapHub<ChatHub>("/ChatHub");
}

app.Run();
// http://[::]:5000 