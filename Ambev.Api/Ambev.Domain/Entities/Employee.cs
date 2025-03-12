using System.Text.Json.Serialization;

namespace Ambev.Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Sobrenome { get; set; }
    public string? Email { get; set; }
    public string? Documento { get; set; }
    public string? Telefone { get; set; }
    public string? NomeDoGestor { get; set; }
    [JsonIgnore]
    public string? Senha { get; set; }
    public DateTime? DataCriacao { get; set; }
    public DateTime? DataAlteracao { get; set; }
    public DateTime? DataExclusao { get; set; }
    public bool Excluido { get; set; } = false;
    public bool Ativo { get; set; } = true;
}
