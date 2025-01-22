using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_BLL.DTOs.AppointmentDTOs;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;
using Vet_DAL.Repositories.Appointments;
using Vet_DAL.Repositories.AppointmentStatuses;
using Vet_DAL.Repositories.DoctorSchedules;

namespace Vet_BLL.Services.Appointments
{
    public class AppointmentService : GenericService<Appointment, AppointmentDto>, IAppointmentService
    {
        public readonly IAppointmentRepository _appointmentRepository;
        public readonly IMapper _mapper;
        public readonly IDoctorScheduleRepository _doctorScheduleRepository;
        public readonly IDoctorSlotRepository _doctorSlotRepository;

        public AppointmentService(IAppointmentRepository appointmentrepository, IMapper mapper,
            IDoctorScheduleRepository doctorScheduleRepository, IDoctorSlotRepository doctorSlotRepository)
            : base(appointmentrepository, mapper)
        {
            _appointmentRepository = appointmentrepository;
            _mapper = mapper;
            _doctorScheduleRepository = doctorScheduleRepository;
            _doctorSlotRepository = doctorSlotRepository;
        }

        public List<AppointmentDto> GetAppointmentsForCurrentWeek()
        {
            var appointments = _appointmentRepository.GetAppointmentsForCurrentWeek();
            return _mapper.Map<List<AppointmentDto>>(appointments);
        }

        public List<AppointmentDto> GetAppointmentsForCurrentMonth()
        {
            var appointments = _appointmentRepository.GetAppointmentsForCurrentMonth();
            return _mapper.Map<List<AppointmentDto>>(appointments);
        }

        public List<AppointmentDto> GetAppointmentsByAnimalId(int animalId)
        {
            // Get medical records for the given animalId
            var appointments = _appointmentRepository.GetAppointmentByAnimalId(animalId);


            // Map the list of MedicalRecord entities to MedicalRecordDto using AutoMapper
            var appointmentDto = _mapper.Map<List<AppointmentDto>>(appointments);

            return appointmentDto;
        }

       
        public IEnumerable<GetAvailableAppointmentsDto> GetAvailableAppointmentsForMonth(int doctorId, int year, int month)
        {
            var startDate = new DateTime(year, month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            // Get the doctor's weekly schedule
            var schedule =  _doctorScheduleRepository.GetDoctorSchedule(doctorId);

            // Get all booked appointments for the month
            var bookedAppointments =  _appointmentRepository.GetManyBookedAppointments(doctorId, startDate, endDate);

            // Generate available slots for each day of the month
            var availableAppointments = new List<GetAvailableAppointmentsDto>();

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                var dayOfWeek = (int)date.DayOfWeek;

                // Get the doctor's schedule for this day
                var daySchedule = schedule.FirstOrDefault(s => s.DayOfWeek == dayOfWeek);
                if (daySchedule == null) continue;

                // Generate slots for this day
                var time = daySchedule.StartTimeSchedule.ToTimeSpan();
                while (time < daySchedule.EndTimeSchedule.ToTimeSpan())
                {
                    // Check if this slot is booked
                    if (!bookedAppointments.Any(a => a.AppointmentDate.Date == date))
                    {
                        availableAppointments.Add(new GetAvailableAppointmentsDto
                        {
                            AppointmentDate = date,
                        });
                    }
                    time = time.Add(TimeSpan.FromMinutes(60)); // Assuming 30-minute slots
                }
            }

            return availableAppointments;
        }

        public IEnumerable<AppointmentDto> GetManyBookedAppointments(int doctorId, DateTime startDate, DateTime endDate)
        {
            var appointment = _appointmentRepository.GetManyBookedAppointments(doctorId, startDate, endDate);

               return  _mapper.Map<IEnumerable<AppointmentDto>>(appointment);
        }


        public void BookAppointment(BookAppointmentDto request)
        {
            // Check if the slot is available
            if (!_appointmentRepository.IsSlotAvailable(request.DoctorSlotId))
            {
                throw new InvalidOperationException("The selected slot is already booked.");
            }

            // Fetch the slot from the database
            var slot = _doctorSlotRepository.GetById(request.DoctorSlotId);

            if (slot == null)
            {
                throw new InvalidOperationException("The selected slot does not exist.");
            }

            // Map DTO to Appointment entity
            var appointment = _mapper.Map<Appointment>(request);
            appointment.CreatedAt = DateTime.UtcNow;


            // Book the appointment
            _appointmentRepository.BookAppointment(appointment);

        }

        public async Task<IEnumerable<AppoiAnimalNameDto>> GetAllAppointmentsAnimalThisWeekAsync()
        {
            var appointments = await _appointmentRepository.GetAllAppointmentsAnimalThisWeekAsync();
            return _mapper.Map<IEnumerable<AppoiAnimalNameDto>>(appointments);
        }

        public async Task<IEnumerable<AppoiAnimalNameDto>> GetAllAppointmentsAnimalThisMonthAsync()
        {
            var appointments = await _appointmentRepository.GetAllAppointmentsAnimalThisMonthAsync();
            return _mapper.Map<IEnumerable<AppoiAnimalNameDto>>(appointments);
        }

        public async Task<IEnumerable<AppoiAnimalNameDto>> GetAllAppointmentsAnimalNextMonthAsync()
        {
            var appointments = await _appointmentRepository.GetAppointmentsForNextMonthAsync();
            return _mapper.Map<IEnumerable<AppoiAnimalNameDto>>(appointments);
        }

        public async Task<IEnumerable<GetAppointmentByDateDto>> GetAppointmentsByDateAsync(DateTime date)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByDateAsync(date);

            // Assuming you already have your AutoMapper configuration set up
            var appointmentDtos = _mapper.Map<IEnumerable<GetAppointmentByDateDto>>(appointments);

            // You can also enrich the DTO with additional information if necessary, like animal name, owner name, etc.
            return appointmentDtos;
        }



        public int CountTotalAppointmentsSoFar()
        {
            return _appointmentRepository.CountPastAppointments();
        }

    }
}
