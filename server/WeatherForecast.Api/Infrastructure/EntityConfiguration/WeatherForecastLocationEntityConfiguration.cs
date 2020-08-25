using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherForecast.Api.Infrastructure.Entity;

namespace WeatherForecast.Api.Infrastructure.EntityConfiguration
{
    public class WeatherForecastLocationEntityConfiguration : IEntityTypeConfiguration<WeatherForecastLocation>
    {
        public void Configure(EntityTypeBuilder<WeatherForecastLocation> builder)
        {
            builder.ToTable("WeatherForecastLocations");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Title)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(m => m.LocationType)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(m => m.TimezoneName)
                .HasMaxLength(128)
                .IsRequired();

            builder.HasMany(m => m.WeatherForecastDays)
                .WithOne()
                .HasForeignKey(m => m.WeatherForecastLocationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}