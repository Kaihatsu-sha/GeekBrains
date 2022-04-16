using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.StructurePatterns;

internal class StudenJsonlSerializer : StudentsSerializer
{
    public override List<Student> Deserialize(Stream stream)
    {
        return JsonSerializer.Deserialize<List<Student>>(stream);
    }

    public override void Serialize(Stream stream, List<Student> students)
    {
        JsonSerializer.Serialize(stream, students);
    }
}
