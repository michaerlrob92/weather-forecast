using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherForecast.Api.Infrastructure.Entity;

namespace WeatherForecast.Api.Infrastructure.EntityConfiguration
{
    public class WeatherForecastDayEntityConfiguration : IEntityTypeConfiguration<WeatherForecastDay>
    {
        public void Configure(EntityTypeBuilder<WeatherForecastDay> builder)
        {
            builder.ToTable("WeatherForecastDays");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.WeatherStateName)
                .HasMaxLength(128)
                .IsRequired();
            
            builder.Property(m => m.WeatherStateAbbr)
                .HasMaxLength(128)
                .IsRequired();
            
            builder.Property(m => m.WindDirectionCompass)
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}