using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Kaihatsu.Timesheets.WebAPI.Core;
using Kaihatsu.Timesheets.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryService<Employee> _repositoryService;
        private readonly IRepositoryService<User> _userRepository;

        public EmployeeService(IRepositoryService<Employee> repository, IRepositoryService<User> userRepository)
        {
            _repositoryService = repository;
            _userRepository = userRepository;
        }

        public async Task CreateAsync(Employee entity, CancellationToken cancellationToken = default)
        {
            await CheckingUser(entity, cancellationToken);

            await _repositoryService.CreateAsync(entity, cancellationToken);
        }

        public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            IQueryable<Employee> employees = await _repositoryService.ReadAllAsync(cancellationToken);
            Employee deleteEmployee = employees.FirstOrDefault(item => item.Id == id);
            await _repositoryService.DeleteAsync(deleteEmployee, cancellationToken);
        }

        public async Task<IReadOnlyCollection<Employee>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            IQueryable<Employee> allEmployees = await _repositoryService.ReadAllAsync(cancellationToken);
            IReadOnlyCollection<Employee> employees = allEmployees.Where(item => item.Id == id).ToList();

            return employees;
        }

        public async Task<IReadOnlyCollection<Employee>> GetFromPaginationAsync(int skip, int take, CancellationToken cancellationToken = default)
        {
            IQueryable<Employee> allEmployees = await _repositoryService.ReadAllAsync(cancellationToken);
            IReadOnlyCollection<Employee> employees = allEmployees
                .Skip(skip)
                .Take(take)
                .ToList();

            return employees;
        }

        public async Task<IReadOnlyCollection<Employee>> SearchByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            IQueryable<Employee> allEmployees = await _repositoryService.ReadAllAsync(cancellationToken);
            IReadOnlyCollection<Employee> employees = allEmployees
                .Where(employee => employee.User.FirstName.ToLower().Contains(name)
                    || employee.User.MiddleName.ToLower().Contains(name)
                    || employee.User.LastName.ToLower().Contains(name))
                .ToList();

            return employees;
        }

        public async Task UpdateAsync(Employee entity, CancellationToken cancellationToken = default)
        {
            await CheckingUser(entity, cancellationToken);

            await _repositoryService.UpdateAsync(entity, cancellationToken);
        }

        private async Task CheckingUser(Employee entity, CancellationToken cancellationToken)
        {
            IQueryable<User> users = await _userRepository.ReadAllAsync(cancellationToken);
            User user = users.FirstOrDefault(item => item.Id == entity.UserId);
            _ = user ?? throw new NullReferenceException(nameof(user) + " not found in DB");
        }
    }
}
