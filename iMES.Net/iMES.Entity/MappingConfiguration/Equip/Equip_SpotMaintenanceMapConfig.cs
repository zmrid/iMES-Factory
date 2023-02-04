using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Equip_SpotMaintenanceMapConfig : EntityMappingConfiguration<Equip_SpotMaintenance>
    {
        public override void Map(EntityTypeBuilder<Equip_SpotMaintenance>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

