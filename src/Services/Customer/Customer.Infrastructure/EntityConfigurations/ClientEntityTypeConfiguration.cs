using Customer.Domain.AggregatesModel.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer.Infrastructure.EntityConfigurations
{
    public class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            // Use Fluent API to configure  

            // Map entities to tables 
            builder.ToTable("clients", CustomerDBContext.DEFAULT_SCHEMA);

            // Configure Primary Keys 
            builder
                .HasKey(o => o.Id)
                .HasName("PK_client");

            builder.OwnsOne(o => o.Address);

            // Configure índexes
            builder
                .HasIndex(p => p.NoDocument)
                .IsUnique(true)
                .HasDatabaseName("Idx_NoDocument");

            // Set fields
            builder
                .Property(b => b.NoDocument)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property<string>("Name")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("name")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property<string>("Phone")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("phone")
                .HasMaxLength(12)
                .IsRequired(false);

            builder
                .Property<string>("Mobile")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("mobile")
                .HasMaxLength(12)
                .IsRequired(false);

            builder
                .Property<string>("Email")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("email")
                .HasMaxLength(75)
                .IsRequired(false);

            builder
                .Property<bool>("IsActive")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("active")
                .HasDefaultValue(true)
                .IsRequired();

            builder
                .Property<string>("Gender")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Gender")
                .HasMaxLength(8)
                .HasDefaultValue("Male")
                .IsRequired(false);

            // One to N relationship.
            builder
                .HasOne(e => e.DocumentType)
                .WithMany(e => e.Customers)
                .HasForeignKey(e => e.DocumentTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
