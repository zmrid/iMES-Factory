using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class View_DefectItemDistributeMapConfig : EntityMappingConfiguration<View_DefectItemDistribute>
    {
        public override void Map(EntityTypeBuilder<View_DefectItemDistribute>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

