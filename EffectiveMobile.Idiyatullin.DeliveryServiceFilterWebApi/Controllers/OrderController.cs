using EffectiveMobile.Idiyatullin.DeliveryServiceFilterWebApi.Models.Dtos;
using EffectiveMobile.Idiyatullin.DeliveryServiceFilterWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EffectiveMobile.Idiyatullin.DeliveryServiceFilterWebApi.Controllers
{
    /// <summary>
    /// Управление заказами.
    /// </summary>
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        /// <summary>
        /// Сервис работы с заказами.
        /// </summary>
        private readonly OrderService _orderService;

        /// <summary>
        /// Экземпляр класса.
        /// </summary>
        /// <param name="orderService">Сервис работы с заказами.</param>
        public OrderController(OrderService orderService)
        {
            Helper.ValidationHelper.IsNull(orderService);

            _orderService = orderService;
        }

        /// <summary>
        /// Фильтрирует заказы.
        /// </summary>
        /// <param name="orderParams">Входные параметры.</param>
        /// <returns>Список отфильтрованных заказов.</returns>
        [HttpPost("Filter")]
        public async Task<IActionResult> FilterOrders([FromBody] OrderInputDto orderParams)
        {
            if (string.IsNullOrEmpty(orderParams.CityDistrict))
            {
                return BadRequest(new { response = "Передан пустой параметр." });
            }

            var result = await _orderService.FilterOrdersAsync(orderParams);

            if (result == null || result.Count == 0)
            {
                return NotFound(new { response = "Заказы не найдены." });
            }

            return Ok(result.Select(o => new OrderOutputDto
            {
                Id = o.Id,
                Weight = o.Weight,
                District = o.District,
                DeliveryTime = o.DeliveryTime
            }).ToList());
        }

        /// <summary>
        /// Удаляет заказ по его идентификатору.
        /// </summary>
        /// <param name="orderParams">Входные параметры.</param>
        /// <returns>Статус операции.</returns>
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteOrder([FromBody] OrderDeleteDto orderParams)
        {
            Helper.ValidationHelper.IsNull(orderParams);

            var result = await _orderService.DeleteOrder(orderParams);

            if (result == false)
            {
                return BadRequest(new { response = "Заказ не найден." });
            }

            return Ok(new { response = "Заказ удален." });
        }

        /// <summary>
        /// Создает новый заказ по входным параметрам.
        /// </summary>
        /// <param name="orderParams">Входные параметры.</param>
        /// <returns>Статус операции.</returns>
        [HttpPost("Create")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto orderParams)
        {
            Helper.ValidationHelper.IsNull(orderParams);

            var result = await _orderService.AddOrder(orderParams);

            if (result == false)
            {
                return BadRequest(new { response = "Не удалось создать." });
            }

            return Ok(new { response = "Заказ создан." });
        }

        /// <summary>
        /// Обновляет существующий заказ.
        /// </summary>
        /// <param name="orderParams">Входные параметры.</param>
        /// <returns>Статус операции.</returns>
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderUpdateDto orderParams)
        {
            Helper.ValidationHelper.IsNull(orderParams);

            var result = await _orderService.UpdateOrder(orderParams);

            if (result == false)
            {
                return BadRequest(new { response = "Не удалось изменить информацию." });
            }

            return Ok(new { response = "Заказ изменен." });
        }
    }
}