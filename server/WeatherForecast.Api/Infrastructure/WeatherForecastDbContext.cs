using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WeatherForecast.Api.Infrastructure.Entity;

namespace WeatherForecast.Api.Infrastructure
{
    public class WeatherForecastDbContext : DbContext
    {
        public DbSet<WeatherForecastDay> WeatherForecastDays { get; set; }
        
        public DbSet<WeatherForecastLocation> WeatherForecastLocations { get; set; }

        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder model)
            => model.ApplyConfigurationsFromAssembly(typeof(WeatherForecastDbContext).Assembly);
    }

    public class WeatherForecastDbContextDesignTimeFactory : IDesignTimeDbContextFactory<WeatherForecastDbContext>
    {
        public WeatherForecastDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WeatherForecastDbContext>();
            optionsBuilder.UseSqlite("Data Source=weather.db");
            return new WeatherForecastDbContext(optionsBuilder.Options);
        }
    }
}