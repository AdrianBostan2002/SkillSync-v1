using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSync.Domain.DTOs.Order;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Extensions;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.WebServer.Extensions;

namespace SkillSync.WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [Authorize(Roles = "Admin,Freelancer,SkillScout")]
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] PlaceOrderDto request)
        {
            var email = HttpContext.GetUserEmailWithCheck();
            request.CustomerEmail = email;

            var orderId = await _orderService.AddOrderAsync(request);

            return Created(string.Empty, new { orderId });
        }

        [Authorize(Roles = "Admin,Freelancer,SkillScout")]
        [HttpPatch]
        [Route("{id}/status")]
        public async Task<IActionResult> UpdateOrderStatus([FromRoute] Guid id, [FromBody] OrderStatus status)
        {
            await _orderService.UpdateOrderStatus(id, status);

            return NoContent();
        }

        [Authorize(Roles = "Admin,Freelancer,SkillScout")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOrdersById([FromRoute] Guid id)
        {
            var result = await _orderService.GetOrderById(id);

            return Ok(result);
        }

        [Authorize(Roles = "Admin,Freelancer,SkillScout")]
        [HttpGet]
        [Route("by-status/{status}")]
        public async Task<IActionResult> GetOrdersByStatus([FromRoute] OrderStatus status)
        {
            var email = HttpContext.GetUserEmailWithCheck();
            var role = HttpContext.GetUserRole().ToRoleType();

            var result = await _orderService.GetOrdersPreviewByStatus(email, status, role);

            return Ok(result);
        }

        [Authorize(Roles = "Admin,Freelancer")]
        [HttpPatch]
        [DisableRequestSizeLimit]
        [Route("media-content/{orderId}/{purpose}")]
        public async Task<IActionResult> UpsertOrderContentMedia([FromForm] UpsertOrderContentDto request, [FromRoute] Guid orderId, [FromRoute] OrderContentPurpose purpose)
        {
            await _orderService.UpsertOrderContetMediaAsync(request, orderId, purpose);

            return NoContent();
        }
    }
}