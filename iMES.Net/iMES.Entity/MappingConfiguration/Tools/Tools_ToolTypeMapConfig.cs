using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Tools_ToolTypeMapConfig : EntityMappingConfiguration<Tools_ToolType>
    {
        public override void Map(EntityTypeBuilder<Tools_ToolType>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

