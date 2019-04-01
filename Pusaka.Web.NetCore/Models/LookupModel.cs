using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pusaka.Web.NetCore.Models
{
    public class LookupModel
    {
        public int Id { set; get; }
        public string Category { set; get; }
        public string Name { set; get; }
        public string Code { set; get; }
        public string Value { set; get; }
        public string Remarks { set; get; }
        public string UpdateBy { set; get; }
        public DateTime UpdateAt { set; get; }
    }
}
