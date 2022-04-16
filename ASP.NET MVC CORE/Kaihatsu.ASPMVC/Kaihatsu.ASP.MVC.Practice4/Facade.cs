using Kaihatsu.ASP.MVC.Practice4.Loaders;
using Kaihatsu.ASP.MVC.Practice4.Models;
using Kaihatsu.ASP.MVC.Practice4.Models.Adapters;
using Kaihatsu.ASP.MVC.Practice4.Serializers;

namespace Kaihatsu.ASP.MVC.Practice4;

internal class Facade
{
    private readonly ILoader _loaderFileSystem = Loader.FileSystemInstance;
    private readonly ISerializer<List<Monbento>> _serialierMonbento = Serializer<List<Monbento>>.JsonInstance;
    private readonly ISerializer<List<TastyCoffee>> _serialierTastyCoffee = Serializer<List<TastyCoffee>>.JsonInstance;

    private readonly IProductAdapter<Monbento> _adapterMonbento = ProductAdapter<Monbento>.MonbentoInstance;
    private readonly IProductAdapter<TastyCoffee> _adapterTastyCoffee = ProductAdapter<TastyCoffee>.TastyCoffeeInstance;

    public List<Product> GetProductFrom(string pathToMonbento, string pathTastyCoffee)
    {
        List<Product> product = new();

        product.AddRange(LoadMonbento(pathToMonbento));
        product.AddRange(LoadTastyCoffee(pathTastyCoffee));

        return product;
    }

    private List<Product> LoadMonbento(string path)
    {
        List<Product> product = new();

        string loaded = _loaderFileSystem.LoadFrom(path);
        List<Monbento> monbento = _serialierMonbento.Deserialize(loaded);

        foreach (Monbento item in monbento)
        {
            product.Add(_adapterMonbento.AdaptationFrom(item));
        }

        return product;
    }

    private List<Product> LoadTastyCoffee(string path)
    {
        List<Product> product = new();

        string loaded = _loaderFileSystem.LoadFrom(path);
        List<TastyCoffee> tastyCoffee = _serialierTastyCoffee.Deserialize(loaded);

        foreach (TastyCoffee item in tastyCoffee)
        {
            product.Add(_adapterTastyCoffee.AdaptationFrom(item));
        }

        return product;
    }
}
