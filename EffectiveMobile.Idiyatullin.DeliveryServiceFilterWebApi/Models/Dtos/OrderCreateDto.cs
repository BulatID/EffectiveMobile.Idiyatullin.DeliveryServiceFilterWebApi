namespace EffectiveMobile.Idiyatullin.DeliveryServiceFilterWebApi.Models.Dtos
{
    /// <summary>
    /// Информация для создания нового заказа.
    /// </summary>
    public struct OrderCreateDto
    {
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