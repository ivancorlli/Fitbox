using System.Buffers;

using Domain.src.Entity;
using Domain.src.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.src.Data;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        // Name
        builder.OwnsOne(x => x.Name, nav =>{
            nav.Property(x=>x.FirstName)
                .HasColumnType("varchar")
                .HasMaxLength(PersonName.MaxLength);
            nav.Property(x=>x.LastName)
                .HasColumnType("varchar")
                .HasMaxLength(PersonName.MaxLength);
        });
        // Address
        builder.OwnsOne(x => x.Address, nav => {
            nav.Property(x => x.Country)
                .HasMaxLength(Address.MaxLength)
                .HasColumnType("varchar");
            nav.Property(x => x.City)
                .HasMaxLength(Address.MaxLength)
                .HasColumnType("varchar");
            nav.Property(x => x.State)
                .HasMaxLength(Address.MaxLength)
                .HasColumnType("varchar");
            nav.OwnsOne(x => x.ZipCode,n => {
                    n.Property(x => x.Value)
                        .HasMaxLength(ZipCode.MaxLength)
                        .HasColumnType("varchar");
                });
        }
        );
        // Contact
        builder.OwnsOne(x => x.EmergencyContact,nav =>{
            nav.OwnsOne(x => x.Name);
            nav.Property(x => x.RelationShip)
                .HasColumnType("varchar");
            nav.OwnsOne(x => x.Name);
            nav.OwnsOne(x => x.Phone,n=>{
               // n.Property(x=>x.Number)
                 //   .HasColumnType("bigint")
                   // .HasMaxLength(12)
                    //.IsRequired();
                //n.Property(x => x.AreaCode)
                  //  .HasColumnType("int")
                   // .IsRequired();
            });
        });
        //Bio
        builder.OwnsOne(x => x.Biography, nav => {
            nav.Property(x => x.Value)
                .HasColumnType("varchar");
        });
        // Meical
        builder.OwnsOne(x => x.Medical, nav => {
            nav.Property(x=>x.Aptitude)
                .HasColumnType("varchar");
            nav.Property(x => x.Disabilities)
                .HasColumnType("varchar");
        });
        // TimeStamps
        builder.OwnsOne(x => x.TimeStamps, nav => {
            nav.Property(x => x.CreatedAt)
                .HasColumnType("date");
            nav.Property(x => x.UpdatedAt)
                .HasColumnType("date");
        });
        
    }
}