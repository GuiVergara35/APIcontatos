using ContactListAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactListAPI.Data.Repositories.Map
{
    public class MapContact : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");

            // Properties
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ContactName).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Telephone).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Niche).IsRequired();

            //Foreignkey
            builder.HasOne(x => x.User).WithMany().HasForeignKey("IdUser");
        }
    }
}
