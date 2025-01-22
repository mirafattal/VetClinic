using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.AppointmentStatuses
{
    public interface IDoctorSlotRepository: IGenericRepository<DoctorSlot>
    {
        void AddSlots(IEnumerable<DoctorSlot> slots);
        bool SlotExists(int doctorId, DateOnly date, TimeOnly startTime);
        void SaveChanges();
        public List<DoctorSlot> GetAvailableSlotsForMonth(int doctorId, DateOnly startDate, DateOnly endDate);

        public List<DateOnly?> GetAvailableSlotDatesByDoctor(int doctorId);
        public List<string> GetAvailableSlotTimesByDoctorAndDate(int doctorId, DateOnly date);
    }
}
