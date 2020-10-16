using ProjectS360.CORE.Entity;
using ProjectS360.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectS360.UI.Areas.Member.Data
{
    public class AppUserVM
    {
        public List<Company> Companies { get; set; }
        public AppUser AppUser { get; set; }



    }
}