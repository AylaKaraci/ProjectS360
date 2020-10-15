using ProjectS360.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectS360.MODEL.Entities
{
    [Serializable]
    [Flags]
    public enum Role
    {
        None = 0,
        Member = 1,
        Admin = 3
        //bu role'lere göre authentication işlemleri yapılacak.
    }
    public class AppUser : CoreEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public string TitleName { get; set; }
        public Role? Role { get; set; }
        public DateTime? BirthDate { get; set; }
        public int CompanyID { get; set; }

        // Kullanıcının Şirket ile ilişkisi.Bir kullanıcı bir şirkete ait.
        public virtual Company Company { get; set; }

    }
}
