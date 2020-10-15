using ProjectS360.CORE.Mapping;
using ProjectS360.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectS360.MODEL.Mapping
{
    public class AppUserMap : CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("Users");
            Property(x => x.Name).HasMaxLength(50).IsOptional();
            Property(x => x.LastName).HasMaxLength(50).IsOptional();
            Property(x => x.UserName).HasMaxLength(50).IsRequired();
            Property(x => x.Password).HasMaxLength(50).IsRequired();
            Property(x => x.Email).HasMaxLength(100).IsOptional();
            Property(x => x.Address).IsOptional();
            Property(x => x.TitleName).IsOptional();
            Property(x => x.BirthDate).HasColumnType("date").IsOptional();
            Property(x => x.ImagePath).IsOptional();
            Property(x => x.PhoneNumber).IsOptional();
            Property(x => x.Role).IsOptional();
        }
    }
}
