using EffectiveMobile.Idiyatullin.DeliveryServiceFilterWebApi.Services;

namespace EffectiveMobile.Idiyatullin.DeliveryServiceFilterWebApi
{
    /// <summary>
    /// Логгер для записи действий с заказом.
    /// </summary>
    public class Logger : ILogger<OrderService>
    {
        /// <summary>
        /// Конфигурация.
        /// </summary>
        private IConfiguration _configuration { get; }

        /// <summary>
        /// Экземпляр класса.
        /// </summary>
        /// <param name="configuration">Конфигурация.</param>
        public Logger(IConfiguration configuration)
        {
            Helper.ValidationHelper.IsNull(configuration);

            _configuration = configuration;
        }

        /// <summary>
        /// Область логгирования.
        /// </summary>
        /// <typeparam name="TState">Тип состояния.</typeparam>
        /// <param name="state">Состояние области</param>
        public IDisposable BeginScope<TState>(TState state) => null;

        /// <summary>
        /// Проверка на включение логирования указанного уровня.
        /// </summary>
        /// <param name="logLevel">Уровень логирования.</param>
        /// <returns>true, если логирование включено.</returns>
        public bool IsEnabled(LogLevel logLevel) => true;

        /// <summary>
        /// Записывает в файл лог.
        /// </summary>
        /// <typeparam name="TState">Тип состояния.</typeparam>
        /// <param name="logLevel">Уровень логирования.</param>
        /// <param name="eventId">Идентификатор события.</param>
        /// <param name="state">Состояние сообщения.</param>
        /// <param name="exception">Исключение.</param>
        /// <param name="formatter">Форматирование сообщения.</param>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            File.AppendAllText(
                _configuration["Logging:FileName"], 
                string.Concat(DateTime.UtcNow, 
                    ": ", 
                    formatter(state, exception), 
                    Environment.NewLine));
        }
    }
}