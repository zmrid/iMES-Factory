using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Equip_SpotMaintPlanProjectMapConfig : EntityMappingConfiguration<Equip_SpotMaintPlanProject>
    {
        public override void Map(EntityTypeBuilder<Equip_SpotMaintPlanProject>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

