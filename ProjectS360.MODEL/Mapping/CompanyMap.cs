using ProjectS360.CORE.Mapping;
using ProjectS360.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectS360.MODEL.Mapping
{
    public class CompanyMap : CoreMap<Company>
    {
        public CompanyMap()
        {
            ToTable("Companies");
            Property(x => x.CompanyName).IsOptional();
            Property(x => x.CompanyFullName).IsOptional();
            Property(x => x.Logo).IsOptional();
            Property(x => x.CompanyAddres).IsOptional();
            Property(x => x.CompanyEmail).IsOptional();

            HasMany(sub => sub.AppUsers)
              .WithRequired(cat => cat.Company)
              .HasForeignKey(x => x.CompanyID);
        }
    }
}
