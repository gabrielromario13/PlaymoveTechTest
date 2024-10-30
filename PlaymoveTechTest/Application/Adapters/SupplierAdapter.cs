using PlaymoveTechTest.Domain.Dtos.Suppliers;
using PlaymoveTechTest.Domain.Model;

namespace PlaymoveTechTest.Application.Adapters;

public static class SupplierAdapter
{
    public static Supplier ToDomain(SupplierRequestDto param) =>
        new(param.Name,
            param.Email);

    public static SupplierResponseDto FromDomain(Supplier param) =>
        param is null ? default : new()
        {
            Id = param.Id,
            Name = param.Name,
            Email = param.Email
        };
}