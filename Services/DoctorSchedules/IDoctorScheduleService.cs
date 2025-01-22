using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;

namespace Vet_BLL.Services.DoctorSchedules
{
    public interface IDoctorScheduleService: IGenericService<DoctorScheduleDto>
    {
      public IEnumerable<DoctorScheduleDto> GetAvailableSchedules(int doctorId, DateTime appointmentDate);
    }
}
