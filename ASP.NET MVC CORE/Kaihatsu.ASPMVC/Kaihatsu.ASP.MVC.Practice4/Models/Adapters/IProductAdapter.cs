using Kaihatsu.ASP.MVC.Practice4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASP.MVC.Practice4.Models.Adapters;

internal interface IProductAdapter<T>
{
    public Product AdaptationFrom(T value);
}
