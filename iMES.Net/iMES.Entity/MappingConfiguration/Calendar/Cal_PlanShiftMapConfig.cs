using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Cal_PlanShiftMapConfig : EntityMappingConfiguration<Cal_PlanShift>
    {
        public override void Map(EntityTypeBuilder<Cal_PlanShift>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

