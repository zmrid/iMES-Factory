using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Quality_InComingCheckTestItemMapConfig : EntityMappingConfiguration<Quality_InComingCheckTestItem>
    {
        public override void Map(EntityTypeBuilder<Quality_InComingCheckTestItem>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

