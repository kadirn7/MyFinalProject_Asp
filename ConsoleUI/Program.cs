using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // //
            //Data Transformation Object
            // ProductTest();
            // CategoryTest();
            ProductGet();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductDetails();
            if (result.Success == true)
            {
                foreach (var product in productManager.GetProductDetails().Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
        private static void ProductGet()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetById(3);
            
            if(result.Success == true)
            {
                Console.WriteLine(result.Data.ProductName + "/" + result.Data.UnitPrice);
            }

        }
    }
}