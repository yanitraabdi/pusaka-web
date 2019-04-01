using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pusaka.Web.NetCore.Classes
{
    public class Enum
    {
        public enum Status
        {
            Inactive = 0,
            Active,
            Delete = 99
        }

        public enum SchoolType
        {
            Undefined = 0,
            Negeri,
            Swasta
        }
    }
}
