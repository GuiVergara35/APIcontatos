using ContactListAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactListAPI.Data.Repositories.Map
{
    public class MapGroup : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups");


            builder.HasKey(x => x.Id);
            builder.Property(x => x.GroupName).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Niche).IsRequired();

            //Foreikey
            builder.HasOne(x => x.User).WithMany().HasForeignKey("IdUser");
        }
    }
}
