using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Protocol;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.ZLabResults
{
    public interface IZLabResultRepository: IGenericRepository<ZlabResult>
    {
        public List<ZlabResult> GetResultByAnimalId(int animalId);
        Task<ZlabResult> AddLabResultAsync(ZlabResult labResult);

    }
}
