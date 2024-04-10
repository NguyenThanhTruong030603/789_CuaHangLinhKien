using CuaHangLinhKien.Models;

namespace CuaHangLinhKien.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
    }
}
