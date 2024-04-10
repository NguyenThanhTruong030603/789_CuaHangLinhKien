using Microsoft.EntityFrameworkCore;
using CuaHangLinhKien.Dataaccess;
using CuaHangLinhKien.Models;

namespace CuaHangLinhKien.Repositories
{
    
    public class EFOrderRepository : IOrderRepository
    {
        public readonly ApplicationDbContext _context;

        public EFOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
            .Include(p => p.OrderDetails) // Include thông tin về category
            .ToListAsync();
        }
    }
}
