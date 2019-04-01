using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Pusaka.Web.NetCore.Classes.Enum;

namespace Pusaka.Web.NetCore.Models
{
    public class SchoolModel
    {
        public int SchoolID { get; set; }
        public int SchoolType { get; set; }
        public int SchoolStatus { get; set; }
        public SchoolType SchoolTypeName { get; set; }
    }
}
