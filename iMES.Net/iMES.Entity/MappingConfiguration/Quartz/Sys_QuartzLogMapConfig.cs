using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Sys_QuartzLogMapConfig : EntityMappingConfiguration<Sys_QuartzLog>
    {
        public override void Map(EntityTypeBuilder<Sys_QuartzLog>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

