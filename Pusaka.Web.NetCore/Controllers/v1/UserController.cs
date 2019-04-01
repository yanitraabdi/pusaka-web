using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pusaka.Web.NetCore.Interfaces;
using Pusaka.Web.NetCore.Models;

namespace Pusaka.Web.NetCore.Controllers.v1
{
    [Route("v1/api/[controller]/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("get")]
        public async Task<IActionResult> GetUserAsync([FromBody]GetPostParamModel request)
        {
            var data = await _userService.GetUserAsync(request);

            if (data.Count == 0)
                return BadRequest();

            return Ok(data.OrderBy(d => d.UserID));
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertUserAsync([FromBody]UserModel payload)
        {
            var data = await _userService.InsertUserAsync(payload);

            return Ok(data);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateUserAsync([FromBody]UserModel payload)
        {
            var data = await _userService.UpdateUserAsync(payload);

            return Ok(data);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var data = await _userService.DeleteUserAsync(id);

            return Ok(data);
        }
    }
}