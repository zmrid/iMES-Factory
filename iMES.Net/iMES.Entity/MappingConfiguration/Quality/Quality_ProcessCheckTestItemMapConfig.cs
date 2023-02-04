using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Quality_ProcessCheckTestItemMapConfig : EntityMappingConfiguration<Quality_ProcessCheckTestItem>
    {
        public override void Map(EntityTypeBuilder<Quality_ProcessCheckTestItem>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

