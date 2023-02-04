using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Quality_TemplateProductMapConfig : EntityMappingConfiguration<Quality_TemplateProduct>
    {
        public override void Map(EntityTypeBuilder<Quality_TemplateProduct>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

