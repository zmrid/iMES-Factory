using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class View_WareInOutDetailMapConfig : EntityMappingConfiguration<View_WareInOutDetail>
    {
        public override void Map(EntityTypeBuilder<View_WareInOutDetail>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

