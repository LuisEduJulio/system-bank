using api_bank.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_bank.infraestructure.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder
                .ToTable("Customer");
            builder
                .HasKey(p => p.Id);
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder
                .Property(p => p.DateCreation);

            builder
                .Property(p => p.Name)
                .IsRequired();
            builder
                .Property(p => p.LastName)
                .IsRequired();
            builder
                 .Property(p => p.Email)
                 .IsRequired();

            builder
                .HasMany(p => p.ExtractEntitys)
                .WithOne(p => p.CustomerEntity)
                .HasForeignKey(p => p.CustomerEntityId);
            builder
                .HasOne(customer => customer.BankEntity)
                .WithMany(bank => bank.CustomerEntitys)
                .HasForeignKey(customer => customer.BankEntityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
               .Property(p => p.DateUpdated);
            builder
                .Property(p => p.DateDisabled);
        }
    }
}
