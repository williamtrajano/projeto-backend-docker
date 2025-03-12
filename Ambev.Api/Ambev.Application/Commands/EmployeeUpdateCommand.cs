using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ambev.Application.Commands;

public class EmployeeUpdateCommand : IRequest<Unit>
{
 
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Sobrenome { get; set; }

    [EmailAddress]
    public string Email { get; set; }
    public string Documento { get; set; }
    public string Telefone { get; set; }
    public string NomeDoGestor { get; set; }

    public string? Senha { get; set; }
}
