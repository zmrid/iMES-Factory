using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class View_OutputStatisticsMapConfig : EntityMappingConfiguration<View_OutputStatistics>
    {
        public override void Map(EntityTypeBuilder<View_OutputStatistics>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

