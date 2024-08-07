using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.Results;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);



//Katmanlardan bagimsiz ama projenin calismasina etki eden mod�lleri asagiya "," ile ayirarak ekleyebiliriz.
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors();
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });


builder.Host
       .UseServiceProviderFactory(new AutofacServiceProviderFactory())
       .ConfigureContainer<ContainerBuilder>(builder =>
       {
           builder.RegisterModule(new AutofacBusinessModule());
       });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Autofac,Ninject,CastleWindsor,StructureMap,LightInject,DryInject --->>IoC Container.
//[LogAspcet] --->>AOP  bir metodun �n�nde bir motudun sonunda �al��an kod par�ac�klar�n� biz AOP mimarisi yap�yoruz.[LogAspect]
//AOP
//Postsharp
// builder.Services.AddSingleton<IProductService, ProductManager>();

//biri constractorda IProductService isterse ona ProductManager new ' i ver demektir.
//  builder.Services.AddSingleton<IProductDal,EfProductDal>();
//biri benden IProductDal isterse EfProductDal() '� veriyoruz.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication(); //middleware

app.UseAuthorization();

app.MapControllers();

app.Run();

