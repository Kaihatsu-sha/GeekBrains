using Lesson5.Interfaces;

namespace Lesson5
{
    public class Person : IPerson
    {
        int _age = 18;
        readonly string _firstName = "";
        readonly string _lastName = "";
        readonly string _patronymic = "";

        public int Age 
        { 
            get { return _age; } 
            set { _age = value > _age ? value : _age; } 
        }

        public string FirstName { get { return _firstName; } }
        public string LastName { get { return _lastName; } }
        public string Patronymic { get { return _patronymic; } }

        public Person(string firstName, string lastName, string patronymic, int age)
        {
            _firstName = firstName;
            _lastName = lastName;
            _patronymic = patronymic;
            _age = age;
        }

        public string FullName()
        {
            return $"{_lastName} {_firstName} {_patronymic}";
        }

        public string ShortName()
        {
            return $"{_lastName} {_firstName} {_patronymic[0]}.";
        }

    }
}
