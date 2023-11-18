using api_bank.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_bank.infraestructure.Configurations
{
    public class BankConfiguration : IEntityTypeConfiguration<BankEntity>
    {
        public void Configure(EntityTypeBuilder<BankEntity> builder)
        {
            builder
                .ToTable("Bank");
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
                .IsRequired()
                .HasMaxLength(255); 
            builder
                .Property(p => p.Number)
                .IsRequired();

            builder
                .HasMany(bank => bank.ExtractEntitys)
                .WithOne(extract => extract.BankEntity)
                .HasForeignKey(extract => extract.BankEntityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(bank => bank.CustomerEntitys)
                .WithOne(customer => customer.BankEntity)
                .HasForeignKey(customer => customer.BankEntityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
               .Property(p => p.DateUpdated);
            builder
               .Property(p => p.DateDisabled);
        }
    }
}