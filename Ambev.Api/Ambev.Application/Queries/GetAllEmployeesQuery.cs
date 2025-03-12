using Ambev.Domain.Entities;
using MediatR;

namespace Ambev.Application.Queries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<Employee>> { }
}
