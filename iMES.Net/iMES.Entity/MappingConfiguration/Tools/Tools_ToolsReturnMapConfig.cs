using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Tools_ToolsReturnMapConfig : EntityMappingConfiguration<Tools_ToolsReturn>
    {
        public override void Map(EntityTypeBuilder<Tools_ToolsReturn>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

