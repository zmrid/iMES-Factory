using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Ware_OutWareHouseBillMapConfig : EntityMappingConfiguration<Ware_OutWareHouseBill>
    {
        public override void Map(EntityTypeBuilder<Ware_OutWareHouseBill>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

