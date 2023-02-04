using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class View_StockBalanceMapConfig : EntityMappingConfiguration<View_StockBalance>
    {
        public override void Map(EntityTypeBuilder<View_StockBalance>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

