using Microsoft.EntityFrameworkCore;
using PlaymoveTechTest.Data.Context;
using PlaymoveTechTest.Domain.Interfaces;
using PlaymoveTechTest.Domain.Model;

namespace PlaymoveTechTest.Data.Repositories;

public class SupplierRepository
    : RepositoryAsync<Supplier>, ISupplierRepository
{
    private readonly IQueryable<Supplier> _query;

    public SupplierRepository(AppDbContext context)
        : base(context)
    {
        _query = _dbSet.AsNoTracking();
    }

    public async Task<bool> CheckIfEmailExists(string email) =>
        await _query.AnyAsync(x => x.Email == email);
}