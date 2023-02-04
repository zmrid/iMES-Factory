using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Equip_SpotMaintWorkOrderMapConfig : EntityMappingConfiguration<Equip_SpotMaintWorkOrder>
    {
        public override void Map(EntityTypeBuilder<Equip_SpotMaintWorkOrder>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

