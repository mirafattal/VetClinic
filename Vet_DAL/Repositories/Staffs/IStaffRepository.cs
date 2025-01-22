using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.Doctors
{
    public interface IStaffRepository: IGenericRepository<Staff>
    {
        public Task<string> GetStaffNameAsync(int doctorId);

        public Task<Staff> GetStaffByIdAsync(int id);
        public Task UpdateStaffAsync(Staff staff);

        //public void SaveCVPath(int staffId, string cvPath);
        //public string GetCVPath(int staffId);

    }
}
