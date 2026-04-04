using Microsoft.EntityFrameworkCore;
using VagabondAPI.Data;
using VagabondAPI.Exceptions;
using VagabondAPI.Models;

namespace VagabondAPI.Repository
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly VagabondAPIContext _context;

        public DestinationRepository(VagabondAPIContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            return await _context.Destination.ToListAsync();
        }
        public async Task<Destination> GetByIdAsync(int id)
        {
            var destination = await _context.Destination.FindAsync(id);
            if (destination == null)
                throw new DestinationNotFoundException(id);
            return destination;
        }

        public async Task AddAsync(Destination destination)
        {
            await _context.Destination.AddAsync(destination);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Destination destination)
        {
            _context.Entry(destination).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var destination = await _context.Destination.FindAsync(id);
            if (destination == null)
                throw new DestinationNotFoundException(id);
            _context.Destination.Remove(destination);
            await _context.SaveChangesAsync();
        }
    }
}
