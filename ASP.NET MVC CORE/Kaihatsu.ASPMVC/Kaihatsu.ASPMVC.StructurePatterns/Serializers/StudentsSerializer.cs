using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.StructurePatterns;

internal abstract class StudentsSerializer : IStudentsSerializer
{
    // Фабричный метод
    public static IStudentsSerializer Xml() => new StudentXmlSerializer();
    // Фабричный метод
    public static IStudentsSerializer Json() => new StudenJsonlSerializer();
    // Простая фабрика
    public static IStudentsSerializer Create(StudentSerializerType type)
    {
        return type switch
        {
            StudentSerializerType.Xml => Xml(),
            StudentSerializerType.Json => Json(),
            _ => throw new ArgumentException(nameof(type))
        };
    }
    public abstract void Serialize(Stream stream, List<Student> students);
    public abstract List<Student> Deserialize(Stream stream);
}
