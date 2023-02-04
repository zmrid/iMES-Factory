using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Quality_OutCheckMapConfig : EntityMappingConfiguration<Quality_OutCheck>
    {
        public override void Map(EntityTypeBuilder<Quality_OutCheck>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

