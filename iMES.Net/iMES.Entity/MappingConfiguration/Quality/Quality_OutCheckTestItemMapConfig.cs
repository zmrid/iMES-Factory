using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Quality_OutCheckTestItemMapConfig : EntityMappingConfiguration<Quality_OutCheckTestItem>
    {
        public override void Map(EntityTypeBuilder<Quality_OutCheckTestItem>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

