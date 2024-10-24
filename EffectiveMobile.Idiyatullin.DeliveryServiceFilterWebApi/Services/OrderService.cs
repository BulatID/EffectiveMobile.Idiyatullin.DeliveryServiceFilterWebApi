using EffectiveMobile.Idiyatullin.DeliveryServiceFilterWebApi.Models;
using EffectiveMobile.Idiyatullin.DeliveryServiceFilterWebApi.Models.Dtos;

using Microsoft.EntityFrameworkCore;

namespace EffectiveMobile.Idiyatullin.DeliveryServiceFilterWebApi.Services
{
    /// <summary>
    /// Работа с заказами.
    /// </summary>
    public class OrderService
    {
        /// <summary>
        /// Конфигурация.
        /// </summary>
        private IConfiguration _configuration { get; }

        /// <summary>
        /// Контекст базы данных.
        /// </summary>
        private readonly DeliveryServiceDbContext _context;

        /// <summary>
        /// Логгер.
        /// </summary>
        private readonly ILogger<OrderService> _logger;

        /// <summary>
        /// Временной интервал в минутах для фильтрации.
        /// </summary>
        private const int TimeRange = 30;

        /// <summary>
        /// Минимальное значение веса заказа.
        /// </summary>
        private const double MinWeightCount = 0;

        /// <summary>
        /// Экземпляр класса.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер.</param>
        public OrderService(DeliveryServiceDbContext context, ILogger<OrderService> logger, IConfiguration configuration)
        {
            Helper.ValidationHelper.IsNull(context);
            Helper.ValidationHelper.IsNull(logger);
            Helper.ValidationHelper.IsNull(configuration);

            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        /// <summary>
        /// Фильтрация заказов в зависимости от района и времени.
        /// </summary>
        /// <param name="order">Входные данные.</param>
        /// <returns>Список заказов, которые соответствуют требованиям.</returns>
        public async Task<List<Order>> FilterOrdersAsync(OrderInputDto order)
        {   
            Helper.ValidationHelper.IsNull(order);

            var result = await _context.Order
                .Where(
                    o => o.District.ToLower() == order.CityDistrict.ToLower() 
                    && o.DeliveryTime >= order.FirstDeliveryDateTime
                    && o.DeliveryTime <= order.FirstDeliveryDateTime.AddMinutes(TimeRange))
                .ToListAsync();

            _logger.LogInformation("Filtered: {Count}", result.Count);

            File.WriteAllText(
                _configuration["Result:FileName"], string.Join(Environment.NewLine, result.Select(o =>
                    $"{o.Id},{o.Weight},{o.District},{o.DeliveryTime}")));

            return result;
        }

        /// <summary>
        /// Удаляет заказ по идентификатору.
        /// </summary>
        /// <param name="order">Объект, в котором идентификатор.</param>
        /// <returns>true, если успешно. Иначе false.</returns>
        public async Task<bool> DeleteOrder(OrderDeleteDto order)
        {
            Helper.ValidationHelper.IsNull(order);

            var orderToDelete = await _context.Order.FirstOrDefaultAsync(o => o.Id == order.Id);

            if (orderToDelete == null)
            {
                return false;
            }

            _context.Remove(orderToDelete);

            await _context.SaveChangesAsync();

            _logger.LogInformation("Deleted order Id: {Id}", order.Id);

            return true;
        }

        /// <summary>
        /// Добавляет новый заказ.
        /// </summary>
        /// <param name="order">Входные параметры в виде объекта.</param>
        /// <returns>true, если успешно. Иначе false.</returns>
        public async Task<bool> AddOrder(OrderCreateDto order)
        {
            Helper.ValidationHelper.IsNull(order);

            if (string.IsNullOrEmpty(order.District) || order.Weight <= MinWeightCount)
            {
                return false;
            }

            await _context.Order.AddAsync(new Order
            {
                District = order.District,
                DeliveryTime = order.DeliveryTime,
                Weight = order.Weight
            });

            await _context.SaveChangesAsync();

            _logger.LogInformation(
                "Created order: {District}, {DeliveryTime}, {Weight}", 
                order.District, order.DeliveryTime, order.Weight);

            return true;
        }

        /// <summary>
        /// Обновляет существующий заказ.
        /// </summary>
        /// <param name="order">Входные параметры в виде объекта.</param>
        /// <returns>true, если успешно. Иначе false.</returns>
        public async Task<bool> UpdateOrder(OrderUpdateDto order)
        {
            Helper.ValidationHelper.IsNull(order);

            if (string.IsNullOrEmpty(order.District) || order.Weight <= MinWeightCount)
            {
                return false;
            }

            var orderToUpdate = await _context.Order.FirstOrDefaultAsync(o => o.Id == order.Id);

            if (orderToUpdate == null)
            {
                return false;
            }

            orderToUpdate.District = order.District;
            orderToUpdate.Weight = order.Weight;
            orderToUpdate.DeliveryTime = order.DeliveryTime;
            orderToUpdate.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            _logger.LogInformation("Updated order: {Id}", order.Id);

            return true;
        }
    }
}