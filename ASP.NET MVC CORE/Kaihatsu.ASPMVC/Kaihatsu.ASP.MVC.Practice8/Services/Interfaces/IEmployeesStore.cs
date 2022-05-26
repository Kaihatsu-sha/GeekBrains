using Kaihatsu.ASP.MVC.Practice8.Models;

namespace Kaihatsu.ASP.MVC.Practice8.Services.Interfaces;

public interface IEmployeesStore
{
    public IEnumerable<EmployeeModel> Get(int skip = 0, int take = 0);
    public EmployeeModel? GetById(int id);

    public int Add(EmployeeModel item);
    public bool Update(EmployeeModel item);
    public bool Remove(int id);
}
