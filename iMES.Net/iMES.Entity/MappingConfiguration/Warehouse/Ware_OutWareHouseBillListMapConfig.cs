using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Ware_OutWareHouseBillListMapConfig : EntityMappingConfiguration<Ware_OutWareHouseBillList>
    {
        public override void Map(EntityTypeBuilder<Ware_OutWareHouseBillList>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

