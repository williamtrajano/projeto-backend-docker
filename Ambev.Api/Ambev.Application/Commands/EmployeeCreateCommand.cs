using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ambev.Application.Commands;

public class EmployeeCreateCommand : IRequest<int>
{
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Sobrenome { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public string Documento { get; set; }
    public string Telefone { get; set; }
    public string NomeDoGestor { get; set; }
    [Required]
    public string Senha { get; set; }


}
