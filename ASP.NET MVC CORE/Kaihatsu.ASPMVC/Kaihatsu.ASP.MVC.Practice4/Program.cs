// See https://aka.ms/new-console-template for more information
using Kaihatsu.ASP.MVC.Practice4;
using Kaihatsu.ASP.MVC.Practice4.Models;
using Kaihatsu.ASP.MVC.Practice4.Serializers;


Console.WriteLine("Задание к лекции 4:" + Environment.NewLine);

Facade facade = new Facade();

string pathToMonbento = @"C:\Users\User\source\GeekBrains\ASP.NET MVC CORE\Kaihatsu.ASPMVC\Kaihatsu.ASP.MVC.Practice4\bin\Debug\net6.0\monbento_me.json";
string pathTastyCoffee = @"C:\Users\User\source\GeekBrains\ASP.NET MVC CORE\Kaihatsu.ASPMVC\Kaihatsu.ASP.MVC.Practice4\bin\Debug\net6.0\shop_tastycoffee_ru.json";

List<Product> products = facade.GetProductFrom(pathToMonbento, pathTastyCoffee);


foreach (Product product in products)
{
    Console.WriteLine(product.ToString() + Environment.NewLine);
}

Console.WriteLine("Конец. Нажмите любую клафишу для завершения");

Console.ReadLine();
