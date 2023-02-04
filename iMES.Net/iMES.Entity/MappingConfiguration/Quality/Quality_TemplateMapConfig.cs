using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Quality_TemplateMapConfig : EntityMappingConfiguration<Quality_Template>
    {
        public override void Map(EntityTypeBuilder<Quality_Template>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

