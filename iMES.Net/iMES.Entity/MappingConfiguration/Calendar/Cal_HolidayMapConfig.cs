using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Cal_HolidayMapConfig : EntityMappingConfiguration<Cal_Holiday>
    {
        public override void Map(EntityTypeBuilder<Cal_Holiday>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

