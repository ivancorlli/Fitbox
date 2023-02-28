using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserContext.Domain.src.Abstractions;
using UserContext.Domain.src.Enum;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Infrastructure.src.Data;

internal class AccountConfiguration : IEntityTypeConfiguration<IAccount>
{
    public void Configure(EntityTypeBuilder<IAccount> builder)
    {
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
            nav.Property(x => x.AreaCode)
            .HasColumnType("smallint");
            nav.Property(x => x.PhoneNumber)
            .HasColumnType("bigint");
            nav.HasIndex(p => p.PhoneNumber)
            .IsUnique();
        });
        // TimeStamps
        builder.OwnsOne(x => x.TimeStamps, nav =>
        {
            nav.Property(x => x.CreatedAt)
                .HasColumnType("datetime");
            nav.Property(x => x.UpdatedAt)
                .HasColumnType("datetime");
        });
        // IsNew
        builder.Property(x => x.IsNew)
                .HasColumnType("tinyint")
                .IsRequired();
        // AccountType
        builder.Property(x => x.AccountType)
            .HasConversion( x=>x.ToString(),x=>(AccountType)Enum.Parse(typeof(AccountType),x)
            );
        // AccountStatus
        builder.Property(x => x.Status)
            .HasConversion(x => x.ToString(),x=>(AccountStatus)Enum.Parse(typeof(AccountStatus),x)
            );
        // EmailVerified
        builder.Property(x => x.EmailVerified)
            .HasColumnType("tinyint")
            .IsRequired();
        // PhoneVerified
        builder.Property(x => x.PhoneVerified)
            .HasColumnType("tinyint")
            .IsRequired();
    }
}
