using HR.LeaveManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.DatabaseContext.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly HrDatabaseContext _context;

    public GenericRepository(HrDatabaseContext context)
    {
        this._context = context;
    }
    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);

        await _context.SaveChangesAsync();

        //return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public Task<IReadOnlyList<T>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);

    }

    public async Task<T> UpdateAsync(T entity)
    {
        //_context.Update(entity);

        _context.Entry(entity).State= EntityState.Modified;

        await _context.SaveChangesAsync();

        return entity;

    }
}
