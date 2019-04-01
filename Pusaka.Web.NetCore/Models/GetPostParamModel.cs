using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pusaka.Web.NetCore.Models
{
    public class GetPostParamModel
    {
        public string Page { get; set; }
        public string Size { get; set; }
        public string Keyword { get; set; }
        public string OrderBy { get; set; }
        public string Sort { get; set; }
    }
}
