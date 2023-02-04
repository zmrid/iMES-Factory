using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Sys_WorkFlowTableStepMapConfig : EntityMappingConfiguration<Sys_WorkFlowTableStep>
    {
        public override void Map(EntityTypeBuilder<Sys_WorkFlowTableStep>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

