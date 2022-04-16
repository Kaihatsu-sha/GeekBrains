using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Kaihatsu.ASPMVC.StructurePatterns;

internal class StudentXmlSerializer : StudentsSerializer
{
    private static XmlSerializer _xmlSerializer = new XmlSerializer(typeof(List<Student>));

    public override List<Student> Deserialize(Stream stream)
    {
        return (List<Student>)_xmlSerializer.Deserialize(stream);
    }

    public override void Serialize(Stream stream, List<Student> students)
    {
        _xmlSerializer.Serialize(stream, students);
    }
}
