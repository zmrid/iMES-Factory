using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Base_NumberRuleMapConfig : EntityMappingConfiguration<Base_NumberRule>
    {
        public override void Map(EntityTypeBuilder<Base_NumberRule>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

