using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.SignalR.Protocol;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs.ZLabDTOs;
using Vet_DAL.Models;
using Vet_DAL.Repositories.Pets;
using Vet_DAL.Repositories.ZLabResults;
using Vet_DAL.Repositories.ZTestNormalRanges;

namespace Vet_BLL.Services.ZLabResults
{
    public class ZLabResultService: GenericService<ZlabResult, ZLabResultDto>, IZLabResultService
    {
        public readonly IZLabResultRepository _zlabResultRepository;
        public readonly IMapper _mapper;
        public readonly IZTestNormalRangeRepository _ztestNormalRangeRepository;

        public ZLabResultService(IZLabResultRepository zlabResultRepository, IMapper mapper,
          IZTestNormalRangeRepository zTestNormalRangeRepository  ) : base(zlabResultRepository, mapper)
        {
            _zlabResultRepository = zlabResultRepository;
            _mapper = mapper;
            _ztestNormalRangeRepository = zTestNormalRangeRepository;
        }

        public List<ZLabResultDto> GetResultsByAnimalId(int animalId)
        {
            var lab = _zlabResultRepository.GetResultByAnimalId(animalId);

            var labdto = _mapper.Map<List<ZLabResultDto>>(lab);

            return labdto;
        }

        public async Task<ZLabResultResponseDto> AddLabResultAsync(ZLabResultDto labResultDto)
        {
            // Fetch the normal range details
            var normalRange = await _ztestNormalRangeRepository.GetTestNormalRangeByIdAsync(labResultDto.TestNormalRangeId);
            if (normalRange == null)
            {
                throw new KeyNotFoundException("Test normal range not found.");
            }

            // Determine if the result is normal
            string isNormal = labResultDto.Result >= normalRange.MinRange && labResultDto.Result <= normalRange.MaxRange
                ? "Normal"
                : "Abnormal";

            // Map DTO to Entity using AutoMapper
            var labResult = _mapper.Map<ZlabResult>(labResultDto);

            // Set additional properties manually
            labResult.IsNormal = isNormal;  // Set the normal flag
            labResult.TestDate = DateTime.UtcNow;
            labResult.TestName = normalRange.TestName; // Automatically add TestName from TestNormalRange

            // Save to the database
            var savedResult = await _zlabResultRepository.AddLabResultAsync(labResult);


            // Map the saved entity to response DTO using AutoMapper
            var responseDto = _mapper.Map<ZLabResultResponseDto>(savedResult);

            responseDto.UnitMeasurements = normalRange.UnitOfMeasurement;

            // The TestName is already set in the labResult, so no need to set it explicitly in the response
            return responseDto;
        }


    }
}
