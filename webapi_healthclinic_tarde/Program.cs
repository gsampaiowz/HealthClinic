using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(x =>
 x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Adiciona serviço de autenticação JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

//Define os parâmetros de validação do token
.AddJwtBearer("JwtBearer", options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
         {
         //VALIDAÇÕES DO TOKEN
         //Quem está solicitando
         ValidateIssuer = true,
         //Quem está recebendo
         ValidateAudience = true,
         //Define se o tempo de expiração do token será validado
         ValidateLifetime = true,
         //Forma de criptografia e ainda validação da chave de autenticação
         IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("healthclinic-chave-autenticacao-webapi-dev")),
         //Tempo de expiração do token
         ClockSkew = TimeSpan.FromMinutes(30),
         //Nome da issuer, de onde está vindo
         ValidIssuer = "healthclinic.webApi",
         //Nome da audience, de onde está vindo
         ValidAudience = "healthclinic.webApi"
         };
 });

//Adiciona o gerador do Swagger à coleção de serviços no Program.cs
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
        {
        Version = "v1",
        Title = "API HealthClinic",
        Description = "API para Gerenciamento de Consultas",
        Contact = new OpenApiContact
            {
            Name = "Sampaio",
            Url = new Uri("https://github.com/gsampaiowz")
            },
        });

    //Usando a autenticação via JWT no swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT"
        });

    //Usando a autenticação via JWT no swagger
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
