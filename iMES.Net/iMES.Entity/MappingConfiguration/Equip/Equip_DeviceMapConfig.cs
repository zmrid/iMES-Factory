using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Equip_DeviceMapConfig : EntityMappingConfiguration<Equip_Device>
    {
        public override void Map(EntityTypeBuilder<Equip_Device>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

