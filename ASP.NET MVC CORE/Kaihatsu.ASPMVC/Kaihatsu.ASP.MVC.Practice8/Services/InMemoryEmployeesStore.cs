using Kaihatsu.ASP.MVC.Practice8.Models;
using Kaihatsu.ASP.MVC.Practice8.Services.Interfaces;

namespace Kaihatsu.ASP.MVC.Practice8.Services;

public class InMemoryEmployeesStore : IEmployeesStore
{
    private List<EmployeeModel> _employees;
    private readonly ILogger<InMemoryEmployeesStore> _logger;
    private int _nextId;

    public InMemoryEmployeesStore(ILogger<InMemoryEmployeesStore> logger)
    {
        _logger = logger;
        _employees = Enumerable.Range(1, 10)
            .Select(i => new EmployeeModel
            {
                Id = i,
                LastName = $"Фамилия - {i}",
                FirstName = $"Имя - {i}",
                Patronymic = $"Отчество - {i}",
                Birthday = DateTime.Now.AddYears(-(18 + i))
            })
            .ToList();
        _nextId = _employees.Max(i => i.Id) + 1;
    }

    public int Add(EmployeeModel item)
    {
        item.Id = _nextId;
        _nextId++;
        _employees.Add(item);

        return item.Id;
    }

    public bool Remove(int id)
    {
        EmployeeModel employee = GetById(id);
        if (employee is null)
            return false;

        _employees.Remove(employee);

        return true;
    }

    public bool Update(EmployeeModel item)
    {
        EmployeeModel employee = GetById(item.Id);
        if (employee is null)
            return false;

        employee.LastName = item.LastName;
        employee.FirstName = item.FirstName;
        employee.Patronymic = item.Patronymic;
        employee.Birthday = item.Birthday;

        return true;
    }

    public IEnumerable<EmployeeModel> Get(int skip = 0, int take = 0)
    {
        if (take != 0)
        {
            return _employees.Skip(skip).Take(take);
        }

        return _employees.Skip(skip);
    }

    public EmployeeModel? GetById(int id)
    {
        return _employees.FirstOrDefault(item => item.Id == id);
    }
}
