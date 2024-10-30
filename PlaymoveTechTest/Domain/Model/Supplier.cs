using System.ComponentModel.DataAnnotations;

namespace PlaymoveTechTest.Domain.Model;

public class Supplier(string name, string email) : BaseEntity
{
    public string Name { get; protected set; } = name;

    [EmailAddress(ErrorMessage = "O email informado é inválido.")]
    public string Email { get; protected set; } = email;

    public void Update(string name, string email)
    {
        Name = name;
        Email = email;
    }
}