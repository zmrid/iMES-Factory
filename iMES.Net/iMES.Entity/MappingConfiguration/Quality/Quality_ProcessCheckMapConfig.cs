using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Quality_ProcessCheckMapConfig : EntityMappingConfiguration<Quality_ProcessCheck>
    {
        public override void Map(EntityTypeBuilder<Quality_ProcessCheck>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

