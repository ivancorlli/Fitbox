using System.Buffers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserContext.Domain.src.Entity;

namespace UserContext.Infrastructure.src.Data;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        // LLaves primarias
        builder.HasKey(x => x.Id);

        // Propiedades
        builder.Property(x => x.Id)
            .IsRequired();
        // Email
        builder.OwnsOne(x => x.Email, nav =>
        {
            nav.Property(x => x.Value)
            .IsRequired()
            .HasColumnType("varchar");
            nav.HasIndex(x => x.Value)
            .IsUnique();
        });
        // Username
        builder.OwnsOne(x => x.Username, nav =>
        {
            nav.Property(x => x.Value)
            .IsRequired()
            .HasColumnType("varchar");
            nav.HasIndex(u => u.Value)
            .IsUnique()
            .IsDescending();
        });
        // Password
        builder.OwnsOne(x => x.Password, nav =>
        {
            nav.Property(x => x.Value)
            .IsRequired()
            .HasColumnType("varchar");
        });
        // Phone
        builder.OwnsOne(x => x.Phone, nav =>
        {
            // nav.Property(x=>x.AreaCode)
            // .IsRequired()
            // .HasColumnType("varchar");
            nav.HasIndex(p => p.PhoneNumber)
            .IsUnique();
        });
        // TimeStamps
        builder.OwnsOne(x => x.TimeStamps, nav =>
        {
            nav.Property(x => x.CreatedAt)
                .HasColumnType("date");
            nav.Property(x => x.UpdatedAt)
                .HasColumnType("date");
        });
        //builder.Ignore(x => x.TimeStamps);
    }
}