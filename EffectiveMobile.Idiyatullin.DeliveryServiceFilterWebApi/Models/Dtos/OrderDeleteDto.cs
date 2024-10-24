namespace EffectiveMobile.Idiyatullin.DeliveryServiceFilterWebApi.Models.Dtos
{
    /// <summary>
    /// Входная информация для удаления заказа.
    /// </summary>
    public struct OrderDeleteDto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }
    }
}