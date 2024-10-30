using PlaymoveTechTest.Domain.Model;

namespace PlaymoveTechTest.Domain.Interfaces;

public interface ISupplierRepository : IRepositoryAsync<Supplier>
{
    Task<bool> CheckIfEmailExists(string email);
}