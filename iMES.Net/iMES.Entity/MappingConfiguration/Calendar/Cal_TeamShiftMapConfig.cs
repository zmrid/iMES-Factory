using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Cal_TeamShiftMapConfig : EntityMappingConfiguration<Cal_TeamShift>
    {
        public override void Map(EntityTypeBuilder<Cal_TeamShift>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

