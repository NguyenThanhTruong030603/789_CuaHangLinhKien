using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CuaHangLinhKien.Models;
using CuaHangLinhKien.Repositories;
using Microsoft.AspNetCore.Authorization;


namespace CuaHangLinhKien.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderAdminController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OrderAdminController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IActionResult> Index()
        {
            var orders = await _orderRepository.GetAllAsync();
            return View(orders);
        }
    }
}
