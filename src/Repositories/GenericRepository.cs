
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class GenericRepository
{
    private readonly DriveDbContext _DBContext;

    public GenericRepository (DriveDbContext dbContext)
    {
        _DBContext = dbContext;
    }

    public async Task<List<T>> ListAsync<T>(T _) where T: class
    {
        List<T> query = await _DBContext.Set<T>().ToListAsync();

        return query;
    }
    public async Task<T> InsertAsync<T>(T obj)where T: class
    {
        EntityEntry<T> query = await _DBContext.Set<T>().AddAsync(obj);
        await _DBContext.SaveChangesAsync();
        return query.Entity;
    }

    public async Task ChangeAsync<T>(T currentObjRegistry, T updatedObj)where T: class
    {
        _DBContext.Entry(currentObjRegistry).CurrentValues.SetValues(updatedObj);
        await _DBContext.SaveChangesAsync();
    }

    public async Task<T?> GetById<T>(int id) where T: class
    {
        T? query = await _DBContext.Set<T>().FindAsync(id);
        return query;
    }

    internal async Task DeleteAsync<T>(T obj) where T: class
    {            
        _DBContext.Set<T>().Remove(obj);
        await _DBContext.SaveChangesAsync();
    }
}
