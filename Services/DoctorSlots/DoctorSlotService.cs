using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs.DoctorSlotsDTOs;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;
using Vet_DAL.Repositories.AppointmentStatuses;
using Vet_DAL.Repositories.DoctorSchedules;
using Vet_DAL.Repositories.Pets;

namespace Vet_BLL.Services.AppointmentStatuses
{
    public class DoctorSlotService : GenericService<DoctorSlot, DoctorSlotDto>, IDoctorSlotService
    {
        public readonly IDoctorSlotRepository _doctorSlotRepository;
        public readonly IMapper _mapper;
        public readonly IDoctorScheduleRepository _doctorScheduleRepository;

        public DoctorSlotService(IDoctorSlotRepository doctorSlotRepository,
            IMapper mapper, IDoctorScheduleRepository doctorScheduleRepository) :
            base(doctorSlotRepository, mapper)
        {
            _doctorSlotRepository = doctorSlotRepository;
            _mapper = mapper;
            _doctorScheduleRepository = doctorScheduleRepository;
        }

        public void GenerateSlots(SlotGenerationRequestDto request)
        {
            // Fetch doctor schedules from the repository
            var schedules = _doctorScheduleRepository.GetDoctorSchedule(request.DoctorId);
            var slotsToAdd = new List<DoctorSlot>();
            var slotDuration = TimeSpan.FromMinutes(60); // Slot duration (1 hour)

            // Loop through the requested date range
            for (var date = request.StartDate; date <= request.EndDate; date = date.AddDays(1))
            {
                var dayOfWeek = (int)date.DayOfWeek;

                // Check if the current day matches the requested days of the week
                if (request.DayOfWeek == null || request.DayOfWeek.Contains(dayOfWeek))
                {
                    // Find the doctor schedule for the current day of the week
                    var schedule = schedules.FirstOrDefault(s => s.DayOfWeek == dayOfWeek);

                    if (schedule != null)
                    {
                        var startTime = schedule.StartTimeSchedule;  // Start time from DoctorSchedule
                        var endTime = schedule.EndTimeSchedule;      // End time from DoctorSchedule

                        // Generate slots within the specified time range
                        while (startTime < endTime)
                        {
                            // Check if the slot already exists
                            if (!_doctorSlotRepository.SlotExists(request.DoctorId, date, startTime))
                            {
                                // Create a new DoctorSlot entity
                                var slotEntity = new DoctorSlot
                                {
                                    StaffId = request.DoctorId,
                                    SlotDate = date,
                                    SlotStartTime = startTime,
                                    SlotEndTime = startTime.AddMinutes(60)
                                };

                                // Add the new slot to the list
                                slotsToAdd.Add(slotEntity);
                            }

                            // Increment startTime by the slot duration
                            startTime = startTime.AddMinutes(60);
                        }
                    }
                }
            }

            // Save all generated slots to the database
            if (slotsToAdd.Any())
            {
                _doctorSlotRepository.AddSlots(slotsToAdd);
                _doctorSlotRepository.SaveChanges();
            }
        }



        public List<DoctorSlotDto> GetAvailableSlots(int doctorId, DateOnly startDate, DateOnly endDate)
        {
            // Fetch available slots from repository
            var availableSlots = _doctorSlotRepository.GetAvailableSlotsForMonth(doctorId, startDate, endDate);

            // Map to AvailableSlotDto using AutoMapper
            var availableSlotsDto = _mapper.Map<List<DoctorSlotDto>>(availableSlots);

            return availableSlotsDto;
        }



        public List<DateOnly?> GetAvailableSlotDates(int doctorId)
        {
            return _doctorSlotRepository.GetAvailableSlotDatesByDoctor(doctorId);
        }

        public List<string> GetAvailableSlotTimes(int doctorId, DateOnly date)
        {
            return _doctorSlotRepository.GetAvailableSlotTimesByDoctorAndDate(doctorId, date);
        }



    }
}