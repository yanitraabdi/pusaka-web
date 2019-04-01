using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Pusaka.Web.NetCore.Classes.Enum;

namespace Pusaka.Web.NetCore.Models
{
    public class BaseModel
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int Status { get; set; }
        public Status StatusName { get; set; }
    }
}
