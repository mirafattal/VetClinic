using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.AppointmentStatuses
{
    public class DoctorSlotRepository : GenericRepository<DoctorSlot> ,
        IDoctorSlotRepository
    {
        private readonly VetClinicContext _context;

        public DoctorSlotRepository(VetClinicContext vetClinicContext) : base(vetClinicContext)
        {
            _context = vetClinicContext;
        }

        public void AddSlots(IEnumerable<DoctorSlot> slots)
        {
            _context.DoctorSlots.AddRange(slots);
        }

        public bool SlotExists(int doctorId, DateOnly date, TimeOnly startTime)
        {
            return _context.DoctorSlots.Any(s => s.StaffId == doctorId && s.SlotDate == date && s.SlotStartTime == startTime);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<DoctorSlot> GetAvailableSlotsForMonth(int doctorId, DateOnly startDate, DateOnly endDate)
        {
            // Query to get available slots for the month, excluding those with existing appointments
            var availableSlots = _context.DoctorSlots
                .Where(slot => slot.StaffId == doctorId
                            && slot.SlotDate >= startDate
                            && slot.SlotDate <= endDate
                            && !_context.Appointments.Any(a => a.DoctorSlotId == slot.DoctorSlotId)) // Check for existing appointments
                .ToList();

            return availableSlots;
        }


        public List<DateOnly?> GetAvailableSlotDatesByDoctor(int doctorId)
        {
            var slotDates = _context.DoctorSlots
                .Where(slot => slot.StaffId == doctorId)
                .Select(slot => slot.SlotDate)
                .Distinct()
                .ToList();

            return slotDates;
        }

        public List<string> GetAvailableSlotTimesByDoctorAndDate(int doctorId, DateOnly date)
        {
            var slotTimes = _context.DoctorSlots
                .Where(slot => slot.StaffId == doctorId && slot.SlotDate == date)
                .Select(slot => slot.SlotStartTime.HasValue
                    ? slot.SlotStartTime.Value.ToString("HH:mm")  // Format TimeOnly if not null
                    : string.Empty)  // Return an empty string if the value is null
                .Distinct()
                .ToList();

            return slotTimes;
        }
    }
}
