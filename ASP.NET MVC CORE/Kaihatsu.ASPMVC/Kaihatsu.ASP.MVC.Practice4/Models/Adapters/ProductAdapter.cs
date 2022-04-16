using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASP.MVC.Practice4.Models.Adapters;

// Фабричные методы
internal abstract class ProductAdapter<T> : IProductAdapter<T>
{
    public static ProductAdapter<Monbento> MonbentoInstance => new MonbentoAdapter();
    public static ProductAdapter<TastyCoffee> TastyCoffeeInstance => new TastyCoffeeAdapter();

    public abstract Product AdaptationFrom(T value);
}
