using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Equip_SpotMaintPlanDeviceMapConfig : EntityMappingConfiguration<Equip_SpotMaintPlanDevice>
    {
        public override void Map(EntityTypeBuilder<Equip_SpotMaintPlanDevice>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

