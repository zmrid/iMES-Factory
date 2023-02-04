using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Base_ProcessLineMapConfig : EntityMappingConfiguration<Base_ProcessLine>
    {
        public override void Map(EntityTypeBuilder<Base_ProcessLine>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

