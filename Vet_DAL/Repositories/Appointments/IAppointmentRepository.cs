using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.Appointments
{
    public interface IAppointmentRepository: IGenericRepository<Appointment>
    {
        List<Appointment> GetAppointmentsForCurrentWeek();
        List<Appointment> GetAppointmentsForCurrentMonth();
        List<Appointment> GetAppointmentByAnimalId(int animalId);
        public IEnumerable<Appointment> GetManyBookedAppointments
            (int doctorId, DateTime startDate, DateTime endDate);
        public Appointment GetOneBookedAppointment
            (int staffId, DateTime appointmentDate);
        void BookAppointment(Appointment appointment);
        public bool IsSlotAvailable(int doctorSlotId);
        public Task<IEnumerable<Appointment>> GetAllAppointmentsAnimalThisWeekAsync();
        public Task<IEnumerable<Appointment>> GetAllAppointmentsAnimalThisMonthAsync();
        public Task<IEnumerable<Appointment>> GetAppointmentsForNextMonthAsync();

        public Task<IEnumerable<Appointment>> GetAppointmentsByDateAsync(DateTime date);

        int CountPastAppointments();

    }
}
