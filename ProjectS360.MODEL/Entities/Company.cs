using ProjectS360.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectS360.MODEL.Entities
{
    #region Properties
    public class Company : CoreEntity
    {
        public string Logo { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyFullName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyAddres { get; set; }
        public virtual List<AppUser> AppUsers { get; set; }

        //bir şirketin birden fazla kullanıcısı olur.
    } 
    #endregion
}
