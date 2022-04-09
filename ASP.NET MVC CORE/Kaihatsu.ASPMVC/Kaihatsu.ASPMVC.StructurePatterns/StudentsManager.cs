using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.StructurePatterns;

internal class StudentsManager
{
    private List<Student> _students = new();
    private int _freeId = 1;
    private readonly IStudentsSerializer _serialier;

    // Фасад - агрегатор
    public StudentsManager(IStudentsSerializer serializer)
    {
        _serialier = serializer;
    }

    public Student Add(string firstName, string lastName, string patronymic, DateTime birthday)
    {
        var student = new Student
        {
            Id = _freeId++,
            FirstName = firstName,
            LastName = lastName,
            Patronymic = patronymic,
            Birthday = birthday
        };
        _students.Add(student);

        return student;
    }

    public void SaveTo(string filePath)
    {
        using (var stream = File.Create(filePath))
        {
            _serialier.Serialize(stream, _students);
        }
    }

    public List<Student> LoadFrom(string filePath)
    {
        using (var stream = File.OpenRead(filePath))
        {
            _students = _serialier.Deserialize(stream);
        }

        if(_students.Count == 0)
            return _students;

        _freeId = _students.Select(student => student.Id).Max();
        return _students;
    }
}
