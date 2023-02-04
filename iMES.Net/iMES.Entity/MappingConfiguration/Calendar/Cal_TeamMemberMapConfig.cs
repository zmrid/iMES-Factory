using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Cal_TeamMemberMapConfig : EntityMappingConfiguration<Cal_TeamMember>
    {
        public override void Map(EntityTypeBuilder<Cal_TeamMember>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

