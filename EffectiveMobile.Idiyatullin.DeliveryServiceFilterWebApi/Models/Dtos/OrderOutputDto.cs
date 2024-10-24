namespace EffectiveMobile.Idiyatullin.DeliveryServiceFilterWebApi.Models.Dtos
{
    /// <summary>
    /// Вывод информации о заказе.
    /// </summary>
    public struct OrderOutputDto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

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
    }
}