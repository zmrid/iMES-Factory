using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class View_EmployeePerformanceMapConfig : EntityMappingConfiguration<View_EmployeePerformance>
    {
        public override void Map(EntityTypeBuilder<View_EmployeePerformance>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

