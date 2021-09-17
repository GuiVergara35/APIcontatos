using ContactListAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactListAPI.Data.Repositories.Map
{
    public class MapMessageSending : IEntityTypeConfiguration<MessageSending>
    {
        public void Configure(EntityTypeBuilder<MessageSending> builder)
        {
            builder.ToTable("MessageSendings");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Sent).IsRequired();

            //Foreignkeys
            builder.HasOne(x => x.Campaign).WithMany().HasForeignKey("IdCampaign");
            builder.HasOne(x => x.Group).WithMany().HasForeignKey("IdGroup");
            builder.HasOne(x => x.Contact).WithMany().HasForeignKey("IdContact");
        }
    }
}
