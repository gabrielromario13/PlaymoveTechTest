using PlaymoveTechTest.Application.Adapters;
using PlaymoveTechTest.Domain.Dtos.Suppliers;
using PlaymoveTechTest.Domain.Interfaces;

namespace PlaymoveTechTest.Application.Services.Suppliers;

public class SupplierService(ISupplierRepository repository)
    : ISupplierService
{
    private readonly ISupplierRepository _repository = repository;

    public async Task<int?> Create(SupplierRequestDto request)
    {
        var emailExists = await _repository.CheckIfEmailExists(request.Email);

        if (emailExists)
            return null;

        var supplier = SupplierAdapter.ToDomain(request);

        await _repository.Create(supplier);

        return supplier.Id;
    }

    public async Task<IEnumerable<SupplierResponseDto>> Get()
    {
        var suppliers = await _repository.Get();

        return suppliers.Select(SupplierAdapter.FromDomain);
    }

    public async Task<SupplierResponseDto> GetById(int id)
    {
        var supplier = await _repository.GetById(id);

        return SupplierAdapter.FromDomain(supplier);
    }

    public async Task<bool> Update(int id, SupplierRequestDto request)
    {
        var supplierFromDb = await _repository.GetById(id);

        if (supplierFromDb is null)
            return false;

        supplierFromDb.Update(request.Name, request.Email);

        await _repository.Update(supplierFromDb);
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var supplierFromDb = await _repository.GetById(id);

        if (supplierFromDb is null)
            return false;

        await _repository.Delete(id);
        return true;
    }
}