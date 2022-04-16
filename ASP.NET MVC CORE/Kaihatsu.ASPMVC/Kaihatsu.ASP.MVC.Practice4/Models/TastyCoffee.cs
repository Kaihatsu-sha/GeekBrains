using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASP.MVC.Practice4.Models;

internal class TastyCoffee
{
    public string productId { get; set; }
    public CardBoxH cardBoxH { get; set; }
    public NameTovar nameTovar { get; set; }
    public List<TovarImg> tovarImg { get; set; }
    public Description description { get; set; }
    public List<CardBoxFL> cardBoxFL { get; set; }
}
internal class CardBoxH
{
    public string ratingCard { get; set; }
    public string countComment { get; set; }
}

internal class NameTovar
{
    public string catigory { get; set; }
    public string processingMethod { get; set; }
    public string name { get; set; }
    public string href { get; set; }
}

internal class TovarImg
{
    public string src { get; set; }
    public string alt { get; set; }
}

internal class LineCbItem
{
    public string lineCb { get; set; }
    public string lineCbText { get; set; }
}

internal class Description
{
    public string textTovar { get; set; }
    public List<LineCbItem> lineCbItem { get; set; }
}

internal class CardBoxFL
{
    public string id { get; set; }
    public string priceCbWt { get; set; }
    public string priceCb { get; set; }
}
