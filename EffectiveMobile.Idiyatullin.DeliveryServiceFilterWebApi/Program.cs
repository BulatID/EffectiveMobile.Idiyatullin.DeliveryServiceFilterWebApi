namespace EffectiveMobile.Idiyatullin.DeliveryServiceFilterWebApi
{
    /// <summary>
    /// ��������� ����������.
    /// </summary>
    public struct Program
    {
        /// <summary>
        /// ����� �����.
        /// </summary>
        public static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

        /// <summary>
        /// �������� � ������������ ����������.
        /// </summary>
        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}