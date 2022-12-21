using Domain.src.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.src.Data;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        // LLaves primarias
        builder.HasKey(x=>x.Id);
        // LLaves secundarias
        // Unicos
        builder.HasIndex(u=>u.Username)
            .IsUnique()
            .IsDescending();
        builder.HasIndex(e=>e.Email)
            .IsUnique();
        builder.HasIndex(p=>p.Phone)
            .IsUnique();
        // Propiedades
        builder.Property(x=>x.Id)
            .IsRequired();
        builder.Property(x=>x.Username)
            .IsRequired();
        builder.Property(x=>x.Email)
            .IsRequired();
        builder.Property(x=>x.Phone)
            .IsRequired();
        builder.Property(x=>x.Password)
            .IsRequired();

        builder.Property(x=>x.Id);
    }
}