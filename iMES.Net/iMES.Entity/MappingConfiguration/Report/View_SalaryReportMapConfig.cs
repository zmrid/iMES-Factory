using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class View_SalaryReportMapConfig : EntityMappingConfiguration<View_SalaryReport>
    {
        public override void Map(EntityTypeBuilder<View_SalaryReport>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

