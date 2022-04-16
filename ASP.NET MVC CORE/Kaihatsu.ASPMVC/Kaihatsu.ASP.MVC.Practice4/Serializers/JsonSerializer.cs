using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Kaihatsu.ASP.MVC.Practice4.Serializers;

internal class JsonSerializer<T> : Serializer<T>
    where T : class
{
    public override T Deserialize(string jsonObject)
    {
        return JsonSerializer.Deserialize<T>(jsonObject);
    }

    public override string Serialize(T inObject)
    {
        return JsonSerializer.Serialize(inObject, typeof(T));
    }
}
