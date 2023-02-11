using Microsoft.AspNetCore.Mvc;
using BookStore.Models.ViewModels;
using BookStore.Models.Models;
using BookStore.Repository;
using System.Linq;
using System.Net;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("api/Role")]
    public class RoleController : ControllerBase
    {
        RoleRepository _roleRepository = new RoleRepository();

        [HttpGet]
        [Route("list")]

        public IActionResult GetRoles(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var role = _roleRepository.GetRoles(pageIndex, pageSize, keyword);

            ListResponse<RoleModel> listResponse = new ListResponse<RoleModel>()
            {
                Records = role.Records.Select(c => new RoleModel(c)),
                TotalRecords = role.TotalRecords,
            };
            return Ok(listResponse);
        }
    }
}
