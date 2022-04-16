using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASP.MVC.Practice4.Models.Adapters;

// Адаптер
internal class TastyCoffeeAdapter : ProductAdapter<TastyCoffee>
{
    private string _template = @"{0} {1}. {2} : {3} и {4}";

    public override Product AdaptationFrom(TastyCoffee value)
    {
        return new Product()
        {
            Id = value.productId,
            Name = value.nameTovar.name,
            Price = value.cardBoxFL[0].priceCbWt + value.cardBoxFL[0].priceCb + " / " + value.cardBoxFL[1].priceCbWt + value.cardBoxFL[1].priceCb,
            Description = string.Format(_template,
                value.nameTovar.processingMethod,
                value.nameTovar.catigory,
                value.description.textTovar,
                value.description.lineCbItem[0].lineCbText + value.description.lineCbItem[0].lineCb,
                value.description.lineCbItem[1].lineCbText + value.description.lineCbItem[1].lineCb),
            ProductUrl = value.nameTovar.href,
            ImagesUrl = value.tovarImg.Select(item => item.src).ToList()
    };
}
}
