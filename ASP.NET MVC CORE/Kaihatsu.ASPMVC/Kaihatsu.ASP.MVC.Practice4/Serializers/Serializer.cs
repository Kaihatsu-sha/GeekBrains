using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASP.MVC.Practice4.Serializers;

// Фабричный метод
internal abstract class Serializer<T> : ISerializer<T>
    where T : class
{
    public static ISerializer<T> JsonInstance => new JsonSerializer<T>();


    public abstract T Deserialize(string inObject);

    public abstract string Serialize(T inObject);
}
