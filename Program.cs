using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
