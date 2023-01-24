using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserContext.Domain.src.Entity;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Infrastructure.src.Data;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(x => x.Id);
        // Name
        builder.OwnsOne(x => x.Name, nav =>
        {
            nav.Property(x => x.FirstName)
                .HasColumnType("varchar")
                .HasMaxLength(PersonName.MaxLength);
            nav.Property(x => x.LastName)
                .HasColumnType("varchar")
                .HasMaxLength(PersonName.MaxLength);
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
        }
        );
        // Contact
        builder.OwnsOne(x => x.EmergencyContact, nav =>
        {
            //Name
            nav.OwnsOne(x => x.Name, n => {
                n.Property(x=>x.FirstName)
                .HasColumnType("varchar")
                .HasMaxLength(PersonName.MaxLength);
                n.Property(x=>x.LastName)
                .HasColumnType("varchar")
                .HasMaxLength(PersonName.MaxLength);
            });
            // Relation
            nav.Property(x => x.RelationShip);
            // Number
            nav.OwnsOne(x => x.Phone, n =>
            {
                n.Property(x=>x.Number)
                  .HasColumnType("bigint");
                n.Property(x => x.AreaCode)
                 .HasColumnType("int");
            });
        });
        //Bio
        builder.OwnsOne(x => x.Bio, nav =>
        {
            nav.Property(x => x.Value)
                .HasColumnType("varchar")
                .HasMaxLength(Bio.MaxLength);
        });
        // Medical
        builder.OwnsOne(x => x.Medical, nav =>
        {
            nav.Property(x => x.Aptitude)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            nav.Property(x => x.Disabilities)
                .HasColumnType("varchar")
                .HasMaxLength(MedicalInfo.MaxLength);
        });
        //TimeStamps
        builder.OwnsOne(x => x.TimeStamps, nav => {
            nav.Property(x => x.CreatedAt)
                .HasColumnType("date");
            nav.Property(x => x.UpdatedAt)
                .HasColumnType("date");
        });

    }
}