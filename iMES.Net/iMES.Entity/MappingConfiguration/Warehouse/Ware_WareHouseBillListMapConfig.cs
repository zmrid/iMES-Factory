using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Ware_WareHouseBillListMapConfig : EntityMappingConfiguration<Ware_WareHouseBillList>
    {
        public override void Map(EntityTypeBuilder<Ware_WareHouseBillList>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

