using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASP.MVC.Practice4.Models.Adapters;

// Адаптер
internal class MonbentoAdapter : ProductAdapter<Monbento>
{
    public override Product AdaptationFrom(Monbento value)
    {
        return new Product()
        {
            Id = string.Empty,
            Name = value.catalogName,
            Price = value.catalogPrice,
            Description = value.catalogName,
            ProductUrl = value.href,
            ImagesUrl = new List<string>() { value.img }
        };

    }
}
