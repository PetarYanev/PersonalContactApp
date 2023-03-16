using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalContactApp.Domain.Models;
using PersonalContactApp.Domain.Models.Entities;
using PersonalContactApp.Domain.Models.ValueObjects;

namespace PersonalContactApp.Infrastructure.Persistence.Configurations;

internal class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder
            .HasKey(d => d.Id);

        builder
            .OwnsOne(c => c.FirstName,
                p =>
                    {
                        p.WithOwner();
                        p.Property(pv => pv.Value)
                        .HasColumnName(nameof(FirstName))
                        .IsRequired()
                        .HasMaxLength(ModelConstants.FirstName.MaxNameLength);
                    });

        builder
            .OwnsOne(c => c.Surname,
                p =>
                    {
                        p.WithOwner();
                        p.Property(pn => pn.Value)
                        .HasColumnName(nameof(Surname))
                        .IsRequired()
                        .HasMaxLength(ModelConstants.Surname.MaxNameLength);
                    });

        builder
            .OwnsOne(c => c.Dob,
                p =>
                    {
                        p.WithOwner();
                        p.Property(pn => pn.Value)
                        .HasColumnName(nameof(Dob));
                    });

        builder
            .OwnsOne(c => c.Address,
                p =>
                    {
                        p.WithOwner();
                        p.Property(pn => pn.Value)
                        .HasColumnName(nameof(Address))
                        .IsRequired(false)
                        .HasMaxLength(ModelConstants.Address.MaxAddressLength);
                    });

        builder
            .OwnsOne(c => c.PhoneNumber,
                p =>
                    {
                        p.WithOwner();
                        p.Property(pn => pn.Value)
                        .HasColumnName(nameof(PhoneNumber))
                        .IsRequired()
                        .HasMaxLength(ModelConstants.PhoneNumber.MaxPhoneNumberLength);
                    });

        builder
            .OwnsOne(c => c.Iban,
                p =>
                    {
                        p.WithOwner();
                        p.Property(pn => pn.Value)
                        .HasColumnName(nameof(Iban))
                        .IsRequired(false);
                    });
    }
}
