namespace EffectiveMobile.Idiyatullin.DeliveryServiceFilterWebApi.Models.Dtos
{
    /// <summary>
    /// Входные параметры для получения информации о заказах.
    /// </summary>
    public struct OrderInputDto
    {
        /// <summary>
        /// Район.
        /// </summary>
        public string CityDistrict { get; set; }

        /// <summary>
        /// Время первой доставки.
        /// </summary>
        public DateTime FirstDeliveryDateTime { get; set; }
    }
}