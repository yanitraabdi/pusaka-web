using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pusaka.Web.NetCore.Interfaces;

namespace Pusaka.Web.NetCore.Controllers.v1
{
    [Route("v1/api/[controller]/")]
    [ApiController]
    public class LookupController : BaseApiController
    {
        private readonly ILookupService _lookupService;

        public LookupController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        [HttpGet]
        [Route("schooltype")]
        public async Task<IActionResult> GetSchoolTypeAsync()
        {
            var data = await _lookupService.GetSchoolTypeAsync();

            if (data.Count == 0)
                return BadRequest();

            return Ok(data.OrderBy(d => d.Name));
        }

        [HttpGet]
        [Route("religion")]
        public async Task<IActionResult> GetReligionAsync()
        {
            var data = await _lookupService.GetReligionAsync();

            if (data.Count == 0)
                return BadRequest();

            return Ok(data.OrderBy(d => d.Name));
        }

        [HttpGet]
        [Route("gender")]
        public async Task<IActionResult> GetGenderAsync()
        {
            var data = await _lookupService.GetGenderAsync();

            if (data.Count == 0)
                return BadRequest();

            return Ok(data.OrderBy(d => d.Name));
        }
    }
}