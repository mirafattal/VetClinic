using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_DAL.Models;
using Vet_DAL.Repositories.Pets;
using Vet_DAL.Repositories.XrayImages;

namespace Vet_BLL.Services.XrayImages
{
    public class XrayImagesService: GenericService<XrayImage, XrayImageDto>, IXrayImagesService
    {
        public readonly IXrayImageRepository _xrayImageRepository;
        public readonly IMapper _mapper;

        public XrayImagesService(IXrayImageRepository xrayImageRepository, IMapper mapper) :
            base(xrayImageRepository, mapper)
        {
            _xrayImageRepository = xrayImageRepository;
            _mapper = mapper;
        }

        public async Task<List<XrayImageDto>> GetXRayByAnimalIdAsync(int animalId)
        {
            var xrayImages = await _xrayImageRepository.GetXRayByAnimalIdAsync(animalId);

            return _mapper.Map<List<XrayImageDto>>(xrayImages);  // Use AutoMapper to map the entities to DTOs
        }
    }
}
