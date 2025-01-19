using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vet_BLL._GenericService;
using Vet_BLL.Rapping;

namespace VetClinic.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class _GenericController<Dto> : Controller where Dto : class
    {
        public readonly IGenericService<Dto> _service;

        public _GenericController(IGenericService<Dto> service)
        {
            _service = service;
        }
        //[Authorize(Roles = "Manager,Pet Doctor,Horse Doctor, Nurse, Receptionist")]
        [HttpGet("GetAll")]
        public ApiResponse<IEnumerable<Dto>> GetAll()
        {
            return _service.GetAll();
        }

        //[Authorize(Roles = "Manager,Pet Doctor,Horse Doctor, Nurse, Receptionist")]
        [HttpGet("GetById")]
        public ApiResponse<Dto> GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpPost("Add")]
        public ApiResponse<Dto> Add(Dto dto)
        {
            return _service.Add(dto);
        }

        //[Authorize(Roles = "Manager,Pet Doctor,Horse Doctor, Nurse, Receptionist")]
        [HttpPut("Update")]
        public ApiResponse<Dto> Update(Dto dto)
        {
            return _service.Update(dto);
        }

        //[Authorize(Roles = "Manager")]
        [HttpDelete("DeleteById")]
        public ApiResponse<bool> Delete(int id)
        {
            return _service.Delete(id);
        }

        //[Authorize(Roles = "Manager")]
        [HttpDelete("Delete")]
        public ApiResponse<bool> Delete(Dto dto)
        {
            return _service.Delete(dto);
        }
    }
}
