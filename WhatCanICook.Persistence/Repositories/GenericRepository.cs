using Microsoft.EntityFrameworkCore;
using WhatCanICook.Domain.Interfaces;
using WhatCanICook.Persistence.DatabaseContext;

namespace WhatCanICook.Persistence.Repositories; 
public class GenericRepository<T> : IGenericRepository<T> where T : class {

    protected readonly CookDatabaseContext _context;

    public GenericRepository(CookDatabaseContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(T entity) {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id) {
        var obj = _context.Set<T>().Find(id);

        if (obj != null) {
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsById(int id) {
        var obj = _context.Set<T>().Find(id);

        if (obj != null) {
            return true;
        }

        return false;
    }

    public async Task<List<T>> GetAllAsync() {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id) {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task UpdateAsync(T entity) {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}
