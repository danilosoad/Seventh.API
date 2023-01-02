using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seventh.Domain.Entities.Servers;

namespace Seventh.Infra.Data.Mapping.Servers
{
    public class ServerMap : BaseMappingg<Server>
    {
        public override void Configure(EntityTypeBuilder<Server> builder)

        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.EnderecoIp).IsRequired();
            builder.Property(x => x.PortaIp).IsRequired();

            builder.HasMany(x => x.Videos).WithOne().HasForeignKey(x => x.ServerId);
        }
    }
}