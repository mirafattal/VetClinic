using Microsoft.AspNetCore.Mvc;
using Vet_BLL.DTOs;
using Vet_BLL.Services.ZLabResults;
using Vet_BLL.Services.ZTestNormalRanges;

namespace VetClinic.Controllers
{
    public class ZTestNormalRangeController : _GenericController<ZTestNormalRangeDto>
    {
        public readonly IZTestNormalRangeService _zTestNormalRangeService;

        public ZTestNormalRangeController(IZTestNormalRangeService service) : base(service)
        {
            _zTestNormalRangeService = service;

        }
    }
}
