using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ODataWithEFCore.Entity;

namespace ODataWithEFCore.Infra
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(60);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(60);
            builder.Property(p => p.Document).IsRequired().HasMaxLength(60);
        }
    }
}
