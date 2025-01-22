using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_DAL.Models;

namespace Vet_BLL.Services.XrayImages
{
    public interface IXrayImagesService: IGenericService<XrayImageDto>
    {
        public Task<List<XrayImageDto>> GetXRayByAnimalIdAsync(int animalId);

    }
}
