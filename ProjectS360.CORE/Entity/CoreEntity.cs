using ProjectS360.CORE.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProjectS360.CORE.Entity
{
    public class CoreEntity : IEntity<int>
    {

        #region Constructor
        public CoreEntity()
        {
            this.Status = Status.Active;
            this.CreatedDate = DateTime.Now;
            this.CreatedADUserName = WindowsIdentity.GetCurrent().Name;
            this.CreatedIP = "123";
            this.CreatedBy = 1;
        }
        #endregion

        #region Properties
        public int ID { get; set; }
        public int? MasterID { get; set; }
        public Status Status { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedIP { get; set; }
        public string CreatedADUserName { get; set; }
        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public string ModifiedComputerName { get; set; }
        public string ModifiedIP { get; set; }
        public string ModifiedADUserName { get; set; }
        public int? ModifiedBy { get; set; } 
        #endregion

    }
}
