using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Base_DefectItemMapConfig : EntityMappingConfiguration<Base_DefectItem>
    {
        public override void Map(EntityTypeBuilder<Base_DefectItem>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

