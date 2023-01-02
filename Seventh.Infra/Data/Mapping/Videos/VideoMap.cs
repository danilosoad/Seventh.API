using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seventh.Domain.Entities.Videos;

namespace Seventh.Infra.Data.Mapping.Videos
{
    public class VideoMap : BaseMappingg<Video>
    {
        public override void Configure(EntityTypeBuilder<Video> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Description).IsRequired();
        }
    }
}