using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs.DoctorSlotsDTOs;

namespace Vet_BLL.Services.AppointmentStatuses
{
    public interface IDoctorSlotService: IGenericService<DoctorSlotDto>
    {
        void GenerateSlots(SlotGenerationRequestDto request);
        public List<DoctorSlotDto> GetAvailableSlots(int doctorId, DateOnly startDate, DateOnly endDate);

        public List<DateOnly?> GetAvailableSlotDates(int doctorId);

        public List<string> GetAvailableSlotTimes(int doctorId, DateOnly date);
    }
}
