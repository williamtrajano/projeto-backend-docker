using Ambev.Domain.Entities;
using MediatR;

namespace Ambev.Application.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id { get; set; }
    }
}
