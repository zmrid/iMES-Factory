using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Base_WorkShopMapConfig : EntityMappingConfiguration<Base_WorkShop>
    {
        public override void Map(EntityTypeBuilder<Base_WorkShop>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

