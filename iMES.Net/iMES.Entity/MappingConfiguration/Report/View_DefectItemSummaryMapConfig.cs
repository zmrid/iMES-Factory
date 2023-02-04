using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class View_DefectItemSummaryMapConfig : EntityMappingConfiguration<View_DefectItemSummary>
    {
        public override void Map(EntityTypeBuilder<View_DefectItemSummary>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

