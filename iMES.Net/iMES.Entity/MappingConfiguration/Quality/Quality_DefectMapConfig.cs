using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Quality_DefectMapConfig : EntityMappingConfiguration<Quality_Defect>
    {
        public override void Map(EntityTypeBuilder<Quality_Defect>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

