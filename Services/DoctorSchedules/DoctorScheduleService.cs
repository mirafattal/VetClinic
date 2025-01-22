using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;
using Vet_DAL.Repositories.DoctorSchedules;

namespace Vet_BLL.Services.DoctorSchedules
{
    public class DoctorScheduleService: GenericService<DoctorSchedule, DoctorScheduleDto>, IDoctorScheduleService
    {
        public readonly IDoctorScheduleRepository _doctorScheduleRepository;
        public readonly IMapper _mapper;

        public DoctorScheduleService(IDoctorScheduleRepository doctorScheduleRepository, IMapper mapper) 
            : base(doctorScheduleRepository, mapper)
        {
            _doctorScheduleRepository = doctorScheduleRepository;
            _mapper = mapper;
        }


        public IEnumerable<DoctorScheduleDto> GetAvailableSchedules(int doctorId, DateTime appointmentDate)
        {
            int dayOfWeek = (int)appointmentDate.DayOfWeek; // Convert to int
            var schedules = _doctorScheduleRepository.GetSchedulesByDoctorAndDay(doctorId, dayOfWeek);

            return _mapper.Map<IEnumerable<DoctorScheduleDto>>(schedules);
        }
    }
}
