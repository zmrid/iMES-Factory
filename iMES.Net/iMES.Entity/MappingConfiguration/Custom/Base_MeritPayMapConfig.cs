using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Base_MeritPayMapConfig : EntityMappingConfiguration<Base_MeritPay>
    {
        public override void Map(EntityTypeBuilder<Base_MeritPay>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

