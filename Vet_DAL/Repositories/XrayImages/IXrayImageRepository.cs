using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.XrayImages
{
    public interface IXrayImageRepository: IGenericRepository<XrayImage>
    {
        public Task AddXrayAsync(XrayImage xray);
        public Task<List<XrayImage>> GetXRayByAnimalIdAsync(int animalId);


    }
}
