using Lesson5.Interfaces;
using System;

namespace Lesson5
{
    class Employee: IEmployee
    {
        string _phone= "";
        string _email = "";
        string _position = "";
        float _salary = 0f;

        IPerson _person = null;

        public string Phone { get { return _phone; }  set { _phone = value; } }
        public string EMail { get { return _email; } }
        public string Position { get { return _position; } set { _position = value; } }
        public float Salary { get { return _salary; } set { _salary = value; } }
        public IPerson Person { get { return _person; } }

        public Employee(IPerson person, string phone, string email, string position, float salary)
        {
            _person = person;
            _phone = phone;
            _email = email;
            _position = position;
            _salary = salary;
        }

        public Employee(string firstName, string lastName, string patronymic, int age, string phone, string email, string position, float salary) 
            : this(new Person(firstName,lastName,patronymic, age), phone, email, position, salary)
        {             
        }

        public void OutputToConsole()
        {
            Console.WriteLine($"Ф.И.О: {_person.FullName()}\n" +
                $"Возраст: {_person.Age}\n" +
                $"Должность: {_position}\n" +
                $"Зарплата: {_salary}\n" +
                $"Телефон: {_phone}\n" +
                $"Электронная почта: {_email}\n");
        }
    }
}
