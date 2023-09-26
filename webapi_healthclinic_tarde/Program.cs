using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Adiciona servi�o de autentica��o JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

//Define os par�metros de valida��o do token
.AddJwtBearer("JwtBearer", options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
         {
         //VALIDA��ES DO TOKEN
         //Quem est� solicitando
         ValidateIssuer = true,
         //Quem est� recebendo
         ValidateAudience = true,
         //Define se o tempo de expira��o do token ser� validado
         ValidateLifetime = true,
         //Forma de criptografia e ainda valida��o da chave de autentica��o
         IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("event-chave-autenticacao-webapi-dev")),
         //Tempo de expira��o do token
         ClockSkew = TimeSpan.FromMinutes(30),
         //Nome da issuer, de onde est� vindo
         ValidIssuer = "event.webApi",
         //Nome da audience, de onde est� vindo
         ValidAudience = "event.webApi"
         };
 });

//Adiciona o gerador do Swagger � cole��o de servi�os no Program.cs
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
        {
        Version = "v1",
        Title = "API EventPlus",
        Description = "API para Gerenciamento de Eventos",
        Contact = new OpenApiContact
            {
            Name = "Sampaio",
            Url = new Uri("https://github.com/gsampaiowz")
            },
        });

    //Usando a autentica��o via JWT no swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT"
        });

    //Usando a autentica��o via JWT no swagger
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        }
                },
            Array.Empty<string>()
        }
    });
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
