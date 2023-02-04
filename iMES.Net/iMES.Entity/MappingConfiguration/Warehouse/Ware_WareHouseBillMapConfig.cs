using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Ware_WareHouseBillMapConfig : EntityMappingConfiguration<Ware_WareHouseBill>
    {
        public override void Map(EntityTypeBuilder<Ware_WareHouseBill>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

