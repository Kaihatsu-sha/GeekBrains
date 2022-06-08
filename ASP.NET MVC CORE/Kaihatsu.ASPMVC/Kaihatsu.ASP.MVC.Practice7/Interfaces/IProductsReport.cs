
using Kaihatsu.ASP.MVC.Practice7.Models;

namespace Kaihatsu.ASP.MVC.Practice7.Interfaces;

public interface IProductsReport // Абстрактная фабрика
{
    public string CatalogName { get; set; }
    public DateTime CreationDate { get; set; }
    public string Description { get; set; }
    public IEnumerable<(int Id, string Name, string Description, decimal Price)> Products {get;set;}

    public FileInfo Creation(string reportTemplateFile);// Фабричный метод
}
