using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserContext.Domain.src.Entity;
using UserContext.Domain.src.Entity.Account;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Infrastructure.src.Data;

public class PersonAccountConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        // LLaves primarias

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
        // IsNew
        builder.Property(x =>x.IsNew)
                .HasColumnType("tinyint")
                .IsRequired();
        // EmailVerified
        builder.Property(x => x.EmailVerified)
            .HasColumnType("tinyint")
            .IsRequired();
        // PhoneVerified
        builder.Property(x => x.PhoneVerified)
            .HasColumnType("tinyint")
            .IsRequired();
        // Profile
        builder.HasOne(x => x.Profile)
           .WithOne(x => x.Account)
           .HasForeignKey<PersonProfile>(x => x.Id)
           .IsRequired(false);
    }
}