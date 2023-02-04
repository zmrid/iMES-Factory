using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class View_ProductionReportMapConfig : EntityMappingConfiguration<View_ProductionReport>
    {
        public override void Map(EntityTypeBuilder<View_ProductionReport>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

