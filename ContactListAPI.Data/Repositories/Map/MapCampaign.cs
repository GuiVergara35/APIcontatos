using ContactListAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactListAPI.Data.Repositories.Map
{
    public class MapCampaign : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.ToTable("Campaigns");

            ////Propriedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CampaignName).HasMaxLength(150).IsRequired();

            //Foreikey
            builder.HasOne(x => x.User).WithMany().HasForeignKey("IdUser");
        }
    }
}
