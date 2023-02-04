using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Cal_TeamMapConfig : EntityMappingConfiguration<Cal_Team>
    {
        public override void Map(EntityTypeBuilder<Cal_Team>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

