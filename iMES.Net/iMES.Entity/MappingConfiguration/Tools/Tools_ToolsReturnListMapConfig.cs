using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Tools_ToolsReturnListMapConfig : EntityMappingConfiguration<Tools_ToolsReturnList>
    {
        public override void Map(EntityTypeBuilder<Tools_ToolsReturnList>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

