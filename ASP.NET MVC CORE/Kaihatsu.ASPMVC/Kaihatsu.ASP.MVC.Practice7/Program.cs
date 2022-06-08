using Kaihatsu.ASP.MVC.Practice7.Interfaces;
using Kaihatsu.ASP.MVC.Practice7.Models;
using Kaihatsu.ASP.MVC.Practice7.Reports;
using Kaihatsu.ASP.MVC.Practice7.Infrastructure;

namespace Kaihatsu.ASP.MVC.Practice7;
// openXML
//TemplateEngine.Docx

public static class Program
{    
    public static void Main(string[] args)
    {
        int productsCount = 20;
    Random random = new Random(42);//Environment.TickCount - начальное состояние // Random - нелюбит многопоточного доступа
        Product[] products = Enumerable.Range(1, productsCount)
            .Select(item => new Product(item, $"Produts-{item}", $"Description-{item}", (decimal)Math.Round(random.NextDouble() * 1000, 2)) )
            .ToArray();
        //(decimal)(new Random().NextDouble() *1000) - плохо, для быстрых операций создаются объесты Random с одинаковым состоянием
        //(decimal)(new Random.Shared.NextDouble() *1000) - лучше, безопастно для потоков. Доступ к одному объету Random
        //Convert.ChangeType("124", typeof(int)); - использовать осторожно

        var catalog = new ProductsCatalog("Каталог товаров -1", "Описание каталога-1", DateTime.Now, products);

        string templateFilePath = "template.docx";
        IProductsReport report = new ReportWord(templateFilePath);
        string reportFilePath = "report.docx";
        string reportFilePath2 = "report.txt";
        //CreateReport(report, catalog, reportFilePath);

        //1:26:58
        //1:41:15
        CreateReport(new ReportRazor(), catalog, reportFilePath2);
    }

    private static void CreateReport(IProductsReport report, ProductsCatalog catalog, string reportFilePath)
    {
        report.CatalogName = catalog.Name;
        report.CreationDate = catalog.CreationDate;
        report.Description = catalog.Description;
        report.Products = catalog.Products.Select(item => (item.Id, item.Name, item.Description, item.Price));
        report.Creation(reportFilePath).Execute();
    }
}
