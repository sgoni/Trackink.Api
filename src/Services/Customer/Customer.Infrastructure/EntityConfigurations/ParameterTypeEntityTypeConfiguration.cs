using Customer.Domain.AggregatesModel.ParameterAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer.Infrastructure.EntityConfigurations
{
    public class ParameterTypeEntityTypeConfiguration : IEntityTypeConfiguration<Parameter>
    {
        public void Configure(EntityTypeBuilder<Parameter> builder)
        {
            // Use Fluent API to configure  

            // Map entities to tables 
            builder
                .ToTable("parameters", CustomerDBContext.DEFAULT_SCHEMA);

            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property<string>("Category")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("category")
                .HasMaxLength(45)
                .IsRequired();

            builder
                .Property<string>("Description")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("description")
                .HasMaxLength(45)
                .IsRequired();

            builder
                 .Property<string>("Name")
                 .UsePropertyAccessMode(PropertyAccessMode.Field)
                 .HasColumnName("name")
                 .HasMaxLength(45)
                 .IsRequired();
        }
    }
}
