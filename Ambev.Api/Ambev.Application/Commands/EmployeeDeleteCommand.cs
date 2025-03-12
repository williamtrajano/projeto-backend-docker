using MediatR;

namespace Ambev.Application.Commands
{
    public class EmployeeDeleteCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
