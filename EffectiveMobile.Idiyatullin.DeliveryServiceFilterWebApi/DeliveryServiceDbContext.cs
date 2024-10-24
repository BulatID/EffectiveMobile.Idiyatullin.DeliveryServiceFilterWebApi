using EffectiveMobile.Idiyatullin.DeliveryServiceFilterWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EffectiveMobile.Idiyatullin.DeliveryServiceFilterWebApi
{
    /// <summary>
    /// Контекст базы данных.
    /// </summary>
    public class DeliveryServiceDbContext : DbContext
    {
        /// <summary>
        /// Конфигурация.
        /// </summary>
        private IConfiguration _Configuration { get; }

        /// <summary>
        /// Таблица в базе данных.
        /// </summary>
        public DbSet<Order> Order { get; set; }

        /// <summary>
        /// Экземпляр класса.
        /// </summary>
        /// <param name="configuration">Конфигурация.</param>
        public DeliveryServiceDbContext(IConfiguration configuration)
        {
            Helper.ValidationHelper.IsNull(configuration);

            _Configuration = configuration;
        }

        /// <summary>
        /// Настройка параметров базы данных.
        /// </summary>
        /// <param name="options">Параметры.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(_Configuration["ConnectionStrings:DefaultConnection"]);
        }

        /// <summary>
        /// Настройка модели.
        /// </summary>
        /// <param name="modelBuilder">Создатель модели.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Создает базу данных.
        /// </summary>
        public void EnsureDbCreated()
        {
            Database.EnsureCreated();
        }
    }
}