using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_BLL.DTOs.AppointmentDTOs;


namespace Vet_BLL.Services.Appointments
{
    public interface IAppointmentService: IGenericService<AppointmentDto>
    {
        List<AppointmentDto> GetAppointmentsForCurrentWeek();
        List<AppointmentDto> GetAppointmentsForCurrentMonth();
        List<AppointmentDto> GetAppointmentsByAnimalId(int animalId);
        IEnumerable<GetAvailableAppointmentsDto> GetAvailableAppointmentsForMonth
           (int doctorId, int year, int month);

        public IEnumerable<AppointmentDto> GetManyBookedAppointments
            (int doctorId, DateTime startDate, DateTime endDate);

        public void BookAppointment(BookAppointmentDto request);

        public Task<IEnumerable<AppoiAnimalNameDto>> GetAllAppointmentsAnimalThisMonthAsync();

        public Task<IEnumerable<AppoiAnimalNameDto>> GetAllAppointmentsAnimalThisWeekAsync();
        public Task<IEnumerable<AppoiAnimalNameDto>> GetAllAppointmentsAnimalNextMonthAsync();

        public Task<IEnumerable<GetAppointmentByDateDto>> GetAppointmentsByDateAsync(DateTime date);
        int CountTotalAppointmentsSoFar();

    }
}
