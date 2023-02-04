using iMES.Entity.MappingConfiguration;
using iMES.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iMES.Entity.MappingConfiguration
{
    public class Quality_TemplateTestItemMapConfig : EntityMappingConfiguration<Quality_TemplateTestItem>
    {
        public override void Map(EntityTypeBuilder<Quality_TemplateTestItem>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

