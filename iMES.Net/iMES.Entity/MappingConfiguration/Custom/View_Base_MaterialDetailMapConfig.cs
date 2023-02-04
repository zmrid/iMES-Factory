using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class View_Base_MaterialDetailMapConfig : EntityMappingConfiguration<View_Base_MaterialDetail>
    {
        public override void Map(EntityTypeBuilder<View_Base_MaterialDetail>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

