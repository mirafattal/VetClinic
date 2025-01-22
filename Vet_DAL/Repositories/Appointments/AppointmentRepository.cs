using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;
using Vet_DAL.Helper;

namespace Vet_DAL.Repositories.Appointments
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly VetClinicContext _context;
        public AppointmentRepository(VetClinicContext vetClinicContext) : base(vetClinicContext)
        {
            _context = vetClinicContext;
        }

        public List<Appointment> GetAppointmentsForCurrentWeek()
        {
            var currentDate = DateTime.Now;
            var startOfWeek = currentDate.StartOfWeek(DayOfWeek.Monday);
            var endOfWeek = startOfWeek.EndOfWeek(DayOfWeek.Monday);

            return _context.Appointments
                .Where(a => a.AppointmentDate >= startOfWeek && a.AppointmentDate <= endOfWeek)
                .ToList();
        }

        public List<Appointment> GetAppointmentsForCurrentMonth()
        {
            var currentDate = DateTime.Now;
            var startOfMonth = currentDate.StartOfMonth();
            var endOfMonth = currentDate.EndOfMonth();

            return _context.Appointments
                .Where(a => a.AppointmentDate >= startOfMonth && a.AppointmentDate <= endOfMonth)
                .ToList();
        }

        public List<Appointment> GetAppointmentByAnimalId(int animalId)
        {
            // Retrieve medical records for the given AnimalId
            return _context.Appointments
                           .Where(a => a.AnimalId == animalId) // Filtering by AnimalId
                           .ToList();
        }

        public  IEnumerable<Appointment> GetManyBookedAppointments(int doctorId, DateTime startDate, DateTime endDate)
        {
            return _context.Appointments
         .Where(a => a.StaffId == doctorId
                     && a.AppointmentDate >= startDate
                     && a.AppointmentDate <= endDate
                     ) // Adding condition to check AppointmentStatus
         .ToList();
        }


        public Appointment GetOneBookedAppointment(int staffId, DateTime appointmentDate)
        {
            return _context.Appointments
                .FirstOrDefault(a =>
                    a.StaffId == staffId &&
                    a.AppointmentDate == appointmentDate); // Status 2 means booked
        }

        public void BookAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public bool IsSlotAvailable(int doctorSlotId)
        {
            return !_context.Appointments.Any(a => a.DoctorSlotId == doctorSlotId);
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAnimalThisWeekAsync()
        {
            var today = DateTime.Now;

            // Get the start and end of the current week
            var startOfWeek = today.StartOfWeek(DayOfWeek.Monday); // Assuming the week starts on Monday
            var endOfWeek = today.EndOfWeek(DayOfWeek.Monday); // Assuming the week ends on Sunday

            // Fetch appointments within this week
            return await _context.Appointments
                .Include(a => a.Animal)
                .ThenInclude(animal => animal.Owner)
                .Include(a => a.DoctorSlot) // Include DoctorSlot entity
                .Where(a => a.AppointmentDate >= startOfWeek && a.AppointmentDate <= endOfWeek)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAnimalThisMonthAsync()
        {
            var today = DateTime.Now;

            // Get the start and end of the current month
            var startOfMonth = today.StartOfMonth();
            var endOfMonth = today.EndOfMonth();

            // Fetch appointments within this month
            return await _context.Appointments
                .Include(a => a.Animal)
                .ThenInclude(animal => animal.Owner)
                .Include(a => a.DoctorSlot) // Include DoctorSlot entity
                .Where(a => a.AppointmentDate >= startOfMonth && a.AppointmentDate <= endOfMonth)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsForNextMonthAsync()
        {
            var today = DateTime.Now;

            // Get the start and end of the next month
            var startOfNextMonth = today.AddMonths(1).StartOfMonth(); // Add 1 month to today and get the start of the month
            var endOfNextMonth = today.AddMonths(1).EndOfMonth();   // Add 1 month to today and get the end of the month

            // Fetch appointments within next month
            return await _context.Appointments
                .Include(a => a.Animal)
                .ThenInclude(animal => animal.Owner)
                .Include(a => a.DoctorSlot) // Include DoctorSlot entity
                .Where(a => a.AppointmentDate >= startOfNextMonth && a.AppointmentDate <= endOfNextMonth)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDateAsync(DateTime date)
        {
            return await _context.Appointments
        .Where(a => a.AppointmentDate.Date == date.Date)
        .Include(a=> a.DoctorSlot)
        .Include(a => a.Animal)      // Include the Animal entity
        .ThenInclude(a => a.Owner)   // Include the Owner entity through Animal
        .Include(a => a.Staff)       // Include the Staff entity (doctor)
        .ToListAsync();

        }



        public int CountPastAppointments()
        {
            var today = DateTime.Today;
            return _context.Appointments
                .Count(appointment => appointment.AppointmentDate <= today);
        }



    }
}
