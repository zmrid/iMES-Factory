using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Sys_WorkFlowStepMapConfig : EntityMappingConfiguration<Sys_WorkFlowStep>
    {
        public override void Map(EntityTypeBuilder<Sys_WorkFlowStep>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

