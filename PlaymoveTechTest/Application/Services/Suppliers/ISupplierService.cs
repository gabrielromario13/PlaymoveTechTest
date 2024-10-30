using PlaymoveTechTest.Domain.Dtos.Suppliers;

namespace PlaymoveTechTest.Application.Services.Suppliers;

public interface ISupplierService
{
    Task<int?> Create(SupplierRequestDto request);
    Task<SupplierResponseDto> GetById(int id);
    Task<IEnumerable<SupplierResponseDto>> Get();
    Task<bool> Update(int id, SupplierRequestDto request);
    Task<bool> Delete(int id);
}