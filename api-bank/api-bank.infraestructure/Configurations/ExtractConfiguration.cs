using api_bank.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_bank.infraestructure.Configurations
{
    public class ExtractConfiguration : IEntityTypeConfiguration<ExtractEntity>
    {
        public void Configure(EntityTypeBuilder<ExtractEntity> builder)
        {
            builder
                .ToTable("Extract");
            builder
                .HasKey(p => p.Id);
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder
                .Property(p => p.DateCreation);

            builder
                .Property(p => p.Describe)
                .IsRequired();
            builder
                .Property(p => p.Loose)
                .IsRequired();
            builder
                .Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            // Relationship with CustomerEntity
            builder.HasOne(extract => extract.CustomerEntity)
              .WithMany(customer => customer.ExtractEntitys)
              .HasForeignKey(extract => extract.CustomerEntityId)
              .OnDelete(DeleteBehavior.NoAction);

            // Relationship with BankEntity
            builder.HasOne(extract => extract.BankEntity)
                   .WithMany(bank => bank.ExtractEntitys)
                   .HasForeignKey(extract => extract.BankEntityId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Enum mapping for EExtractType
            builder.Property(extract => extract.EExtractType)
                   .IsRequired()
                   .HasConversion<int>();

            builder
               .Property(p => p.DateUpdated);
            builder
                .Property(p => p.DateDisabled);
        }
    }
}
