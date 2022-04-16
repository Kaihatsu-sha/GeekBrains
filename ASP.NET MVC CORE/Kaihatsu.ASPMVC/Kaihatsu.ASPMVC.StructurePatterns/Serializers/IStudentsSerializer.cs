using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.StructurePatterns;

// Адаптер
internal interface IStudentsSerializer
{
    public void Serialize(Stream stream, List<Student> students);
    public List<Student> Deserialize(Stream stream);
}
