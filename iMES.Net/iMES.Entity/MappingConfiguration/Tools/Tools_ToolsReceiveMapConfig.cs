using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Tools_ToolsReceiveMapConfig : EntityMappingConfiguration<Tools_ToolsReceive>
    {
        public override void Map(EntityTypeBuilder<Tools_ToolsReceive>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

