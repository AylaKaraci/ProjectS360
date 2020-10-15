using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectS360.CORE.Entity.Enum
{
    public enum Status
    {
        None = 0,
        Active = 1,
        Deleted = 3,
        Updated = 5
    }
    //Silme olayını db'de Statulerine göre ayarlanacak. Kaldırılmayacak.
}
