using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Tools_ToolMapConfig : EntityMappingConfiguration<Tools_Tool>
    {
        public override void Map(EntityTypeBuilder<Tools_Tool>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

