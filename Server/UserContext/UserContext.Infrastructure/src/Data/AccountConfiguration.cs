using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserContext.Domain.src.Entity.Account;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Infrastructure.src.Data;

public class AccountConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
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
            .HasColumnType("varchar")
            .HasMaxLength(Email.MaxLength);
            nav.HasIndex(x => x.Value)
            .IsUnique();
        });
        // Username
        builder.OwnsOne(x => x.Username, nav =>
        {
            nav.Property(x => x.Value)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(Username.MaxLength);
            nav.HasIndex(u => u.Value)
            .IsUnique()
            .IsDescending();
        });
        // Password
        builder.OwnsOne(x => x.Password, nav =>
        {
            nav.Property(x => x.Value)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(80);
        });
        // Phone
        builder.OwnsOne(x => x.Phone, nav =>
        {
            nav.Property(x=>x.AreaCode)
            .HasColumnType("smallint");
            nav.Property(x=>x.PhoneNumber)
            .HasColumnType("bigint");
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
    }
}