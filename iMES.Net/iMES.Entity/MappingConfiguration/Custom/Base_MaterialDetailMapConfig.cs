using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Base_MaterialDetailMapConfig : EntityMappingConfiguration<Base_MaterialDetail>
    {
        public override void Map(EntityTypeBuilder<Base_MaterialDetail>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

