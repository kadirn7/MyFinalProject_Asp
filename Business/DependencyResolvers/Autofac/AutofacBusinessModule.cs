using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // builder.Services.AddSingleton<IProductService, ProductManager>();    //program cs.de koştuğumuz bu kodun karşılığıdır.
            // builder.Services.AddSingleton<IProductDal, EfProductDal>();
            //singleInstance tek bir Instance tutar. Herkese aynı Instance'ı verir. //newleme işlemlerini bunlar yapar.
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
        }
    }
}
