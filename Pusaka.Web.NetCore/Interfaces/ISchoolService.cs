using Pusaka.Web.NetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pusaka.Web.NetCore.Interfaces
{
    public interface ISchoolService
    {
        Task<List<SchoolModel>> GetSchoolAsync(GetPostParamModel param);
    }
}
