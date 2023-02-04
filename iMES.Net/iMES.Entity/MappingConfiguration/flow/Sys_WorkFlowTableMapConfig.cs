using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Sys_WorkFlowTableMapConfig : EntityMappingConfiguration<Sys_WorkFlowTable>
    {
        public override void Map(EntityTypeBuilder<Sys_WorkFlowTable>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

