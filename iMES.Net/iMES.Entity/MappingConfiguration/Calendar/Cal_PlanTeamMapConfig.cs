using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Cal_PlanTeamMapConfig : EntityMappingConfiguration<Cal_PlanTeam>
    {
        public override void Map(EntityTypeBuilder<Cal_PlanTeam>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

