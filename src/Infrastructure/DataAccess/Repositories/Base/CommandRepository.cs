using Domain.Repositories.Command.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories.Base
{
    public class CommandRepository<T> : ICommandRepository<T> where T : class
    {
        protected readonly ExchangeContext _context;        

        public CommandRepository(ExchangeContext exchangeContext)
        {
            this._context = exchangeContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
