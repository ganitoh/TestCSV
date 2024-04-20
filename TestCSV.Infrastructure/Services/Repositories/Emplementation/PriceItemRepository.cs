using TestCSV.Domain.Models;
using TestCSV.Infrastructure.Services.Repositories.Abstracton;

namespace TestCSV.Infrastructure.Services.Repositories.Emplementation
{
    public class PriceItemRepository : IPriceItemRepository
    {
        private readonly ApplicationContext _context;

        public PriceItemRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(PriceItem entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            await _context.PriceItem.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
