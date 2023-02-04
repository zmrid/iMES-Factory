using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Base_ProcessLineListMapConfig : EntityMappingConfiguration<Base_ProcessLineList>
    {
        public override void Map(EntityTypeBuilder<Base_ProcessLineList>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

