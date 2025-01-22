using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs.ZLabDTOs;

namespace Vet_BLL.Services.ZLabResults
{
    public interface IZLabResultService: IGenericService<ZLabResultDto>
    {
        public List<ZLabResultDto> GetResultsByAnimalId(int animalId);
        Task<ZLabResultResponseDto> AddLabResultAsync(ZLabResultDto labResultDto);

    }
}
