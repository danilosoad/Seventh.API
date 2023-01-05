using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seventh.Domain.Entities.Recycles;

namespace Seventh.Infra.Data.Mapping.Recycles
{
    public class RecycleMap : BaseMappingg<Recycle>
    {
        public override void Configure(EntityTypeBuilder<Recycle> builder)

        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.JobId).IsRequired();
        }
    }
}