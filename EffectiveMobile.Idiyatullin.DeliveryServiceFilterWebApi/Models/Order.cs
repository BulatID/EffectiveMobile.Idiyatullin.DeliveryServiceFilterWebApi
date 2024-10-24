namespace EffectiveMobile.Idiyatullin.DeliveryServiceFilterWebApi.Models
{
    /// <summary>
    /// Таблица для работы с заказами.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Вес в килограммах.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Район.
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// Время доставки.
        /// </summary>
        public DateTime DeliveryTime { get; set; }

        /// <summary>
        /// Последнее обновление.
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Время создания.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}