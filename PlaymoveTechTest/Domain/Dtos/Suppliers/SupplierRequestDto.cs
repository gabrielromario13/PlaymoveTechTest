using System.ComponentModel.DataAnnotations;

namespace PlaymoveTechTest.Domain.Dtos.Suppliers;

public class SupplierRequestDto
{
    public string Name { get; set; } = string.Empty;
    [EmailAddress(ErrorMessage = "O email informado é inválido.")]
    public string Email { get; set; } = string.Empty;
}