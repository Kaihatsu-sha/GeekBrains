using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.StructurePatterns;

internal static class AdapterExample
{
    public static void Run()
    {
        StudentsManager manager = new StudentsManager(StudentsSerializer.Xml());
        manager.Add("Иван", "Сидоров", "Андреевич", DateTime.Now.AddYears(-21));
        manager.Add("Андрей", "Сидоров", "Андреевич", DateTime.Now.AddYears(-20));
        manager.Add("Александр", "Сидоров", "Андреевич", DateTime.Now.AddYears(-16));
        manager.Add("Дмитрий", "Сидоров", "Андреевич", DateTime.Now.AddYears(-29));
        manager.Add("Евгений", "Сидоров", "Андреевич", DateTime.Now.AddYears(-19));
        manager.Add("Алексей", "Сидоров", "Андреевич", DateTime.Now.AddYears(-22));
        manager.Add("Степан", "Сидоров", "Андреевич", DateTime.Now.AddYears(-30));
        manager.Add("Василий", "Сидоров", "Андреевич", DateTime.Now.AddYears(-31));
        manager.Add("Николай", "Сидоров", "Андреевич", DateTime.Now.AddYears(-33));
        manager.Add("Артём", "Сидоров", "Андреевич", DateTime.Now.AddYears(-20));

        manager.SaveTo("students.xml");
    }
}
