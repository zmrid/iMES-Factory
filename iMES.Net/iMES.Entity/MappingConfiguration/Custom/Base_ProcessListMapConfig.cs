using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Base_ProcessListMapConfig : EntityMappingConfiguration<Base_ProcessList>
    {
        public override void Map(EntityTypeBuilder<Base_ProcessList>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

