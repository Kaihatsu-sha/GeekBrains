using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASP.MVC.Practice4.Serializers;

// Адаптер
public interface ISerializer<T>
    where T : class
{
    public T Deserialize(string inObject);
    public string Serialize(T inObject);
}
