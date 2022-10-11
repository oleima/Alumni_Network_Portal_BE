using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

using Alumni_Network_Portal_BE.Models;
using Microsoft.EntityFrameworkCore;
using Alumni_Network_Portal_BE.Services.UserServices;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Alumni_Network_Portal_BE.Services.TopicServices;
using Alumni_Network_Portal_BE.Services.GroupServices;
using Alumni_Network_Portal_BE.Services.PostServices;
using Alumni_Network_Portal_BE.Services.EventServices;

var builder = WebApplication.CreateBuilder(args);

//FIXME: Testing of deployment
var configurationBuilder = new ConfigurationBuilder()
                            .SetBasePath(builder.Environment.ContentRootPath)
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                            .AddEnvironmentVariables();

builder.Configuration.AddConfiguration(configurationBuilder.Build());

var defaultConnectionString = string.Empty;

if (builder.Environment.EnvironmentName == "Development")
{
    defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}
else
{
    // Use connection string provided at runtime by Heroku.
    var connectionUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

    connectionUrl = connectionUrl.Replace("postgres://", string.Empty);
    var userPassSide = connectionUrl.Split("@")[0];
    var hostSide = connectionUrl.Split("@")[1];

    var user = userPassSide.Split(":")[0];
    var password = userPassSide.Split(":")[1];
    var host = hostSide.Split("/")[0];
    var database = hostSide.Split("/")[1].Split("?")[0];

    defaultConnectionString = $"Server={host};Port=5432;Database={database};User Id={user};Password={password};sslmode=Require;TrustServerCertificate=True;";
}

builder.Services.AddDbContext<AlumniNetworkDbContext>(
    opt => {
        if(builder.Environment.EnvironmentName == "Development")
        {
            opt.UseSqlServer(defaultConnectionString);
        }
        else
        {
            opt.UseNpgsql(defaultConnectionString);
        }
    });

var serviceProvider = builder.Services.BuildServiceProvider();
try
{
    var dbContext = serviceProvider.GetRequiredService<AlumniNetworkDbContext>();
    dbContext.Database.Migrate();
}
catch
{
}

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped(typeof(ITopicService), typeof(TopicService));
builder.Services.AddScoped(typeof(IUserService), typeof(UserService));
builder.Services.AddScoped(typeof(IGroupService), typeof(GroupService));
builder.Services.AddScoped(typeof(IPostService), typeof(PostService));
builder.Services.AddScoped(typeof(IEventService), typeof(EventService));


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKeyResolver = (token, securityToken, kid, parameters) =>
            {
                var client = new HttpClient();
                var keyuri = builder.Configuration["Token:KeyURI"];
                //Retrieves the keys from keycloak instance to verify token
                var response = client.GetAsync(keyuri).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                var keys = JsonConvert.DeserializeObject<JsonWebKeySet>(responseString);
                return keys.Keys;
            },

            ValidIssuers = new List<string>
      {
        builder.Configuration["Token:IssuerURI"]
      },
            ValidAudience = "account",
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Alumni Network API",
        Description = "Get information about users, posts, groups and events",
        TermsOfService = new Uri("https://example.com/terms"), //TODO
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Name = "Bearer",
                In = ParameterLocation.Header,
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

//TODO Add cors specific to frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll", builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAll"); //TOO Cors specific to frontend
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
