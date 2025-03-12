using Ambev.Domain.Entities;
using System.Linq.Expressions;

namespace Ambev.Domain.Repositories;

public interface IEmployeeRepository
{
    Task<int> AddAsync(Employee employee);
    Task DeleteAsync(int id);
    Task<IEnumerable<Employee>> GetAllAsync(Expression<Func<Employee, bool>> predicate);
    Task<Employee> GetByIdAsync(int id);
    Task<IEnumerable<Employee>> GetAllAsync();
    Task UpdateAsync(Employee employee);
}
