using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pusaka.Web.NetCore.Interfaces;
using Pusaka.Web.NetCore.Models;
using Pusaka.Web.NetCore.Services;

namespace Pusaka.Web.NetCore.Controllers.v1
{
    [Route("api/v1/school/")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpPost]
        [Route("get")]
        public async Task<IActionResult> GetSiteLevelProjectInformation([FromBody]GetPostParamModel request)
        {
            var data = await _schoolService.GetSchoolAsync(request);

            if (data.Count == 0)
                return BadRequest();

            return Ok(data.OrderBy(d => d.SchoolID));
        }
    }
}