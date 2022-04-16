using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASP.MVC.Practice4.Models;

internal class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Price { get; set; }
    public string Description { get; set; }
    public string ProductUrl { get; set; }
    public ICollection<string> ImagesUrl { get; set; }

    public override string ToString()
    {
        string imageUrls = string.Empty;
        foreach(string imageUrl in ImagesUrl)
        {
            imageUrls += Environment.NewLine + imageUrl;
        }

        return $"Id - {Id} Name - {Name} - Price {Price}"
            +$"{Environment.NewLine}Description:{Environment.NewLine}{Description}"
            +$"{Environment.NewLine}ProcuctUrl: {ProductUrl} ImageUrls:{imageUrls}";
    }

}
