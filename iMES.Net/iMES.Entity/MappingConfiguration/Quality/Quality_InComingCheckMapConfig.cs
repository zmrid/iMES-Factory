using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Quality_InComingCheckMapConfig : EntityMappingConfiguration<Quality_InComingCheck>
    {
        public override void Map(EntityTypeBuilder<Quality_InComingCheck>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

