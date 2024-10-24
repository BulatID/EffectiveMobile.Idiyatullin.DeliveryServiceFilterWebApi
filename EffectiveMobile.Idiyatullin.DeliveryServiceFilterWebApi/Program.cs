namespace EffectiveMobile.Idiyatullin.DeliveryServiceFilterWebApi
{
    /// <summary>
    /// Запускает приложение.
    /// </summary>
    public struct Program
    {
        /// <summary>
        /// Точка входа.
        /// </summary>
        public static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

        /// <summary>
        /// Создание и конфигурация приложения.
        /// </summary>
        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}