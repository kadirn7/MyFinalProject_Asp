using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Host
       .UseServiceProviderFactory(new AutofacServiceProviderFactory())
       .ConfigureContainer<ContainerBuilder>(builder =>
       {
           builder.RegisterModule(new AutofacBusinessModule());
       });
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
 