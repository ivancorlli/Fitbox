using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserContext.Domain.src.Entity;
using UserContext.Domain.src.Entity.Account;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Infrastructure.src.Data;

internal class GymProfileConfiguration : IEntityTypeConfiguration<GymProfile>
{
    public void Configure(EntityTypeBuilder<GymProfile> builder)
    {
        // Name
        builder.OwnsOne(x => x.Name,nav =>
        {
            nav.Property(x => x.Value)
            .HasColumnType("varchar")
            .HasMaxLength(30)
            .IsRequired();
        });

        // Address
        builder.OwnsOne(x => x.Address, nav =>
        {
            nav.Property(x => x.Country)
                .HasMaxLength(Address.MaxLength)
                .HasColumnType("varchar");
            nav.Property(x => x.City)
                .HasMaxLength(Address.MaxLength)
                .HasColumnType("varchar");
            nav.Property(x => x.State)
                .HasMaxLength(Address.MaxLength)
                .HasColumnType("varchar");
            nav.OwnsOne(x => x.ZipCode, n =>
            {
                n.Property(x => x.Value)
                    .HasMaxLength(ZipCode.MaxLength)
                    .HasColumnType("varchar");
            });
        });

        // TimeStamps
        builder.OwnsOne(x => x.TimeStamps, nav =>
        {
            nav.Property(x => x.CreatedAt)
                .HasColumnType("datetime");
            nav.Property(x => x.UpdatedAt)
                .HasColumnType("datetime");
        });

        //Bio
        builder.OwnsOne(x => x.Bio, nav =>
        {
            nav.Property(x => x.Value)
                .HasColumnType("varchar")
                .HasMaxLength(Bio.MaxLength);
        });
        // Account
        builder.Property(x => x.AccountId);
        // Profile
        builder.HasOne(x => x.Account)
           .WithOne(x => x.Profile)
           .HasForeignKey<GymProfile>(x => x.AccountId)
           .IsRequired(false);
    }
}
