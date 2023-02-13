using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Base_DesktopMenuMapConfig : EntityMappingConfiguration<Base_DesktopMenu>
    {
        public override void Map(EntityTypeBuilder<Base_DesktopMenu>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

