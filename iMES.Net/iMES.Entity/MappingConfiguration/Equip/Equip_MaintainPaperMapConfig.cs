using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Equip_MaintainPaperMapConfig : EntityMappingConfiguration<Equip_MaintainPaper>
    {
        public override void Map(EntityTypeBuilder<Equip_MaintainPaper>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

