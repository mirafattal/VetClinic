using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.SignalR.Protocol;
using Vet_BLL.DTOs;
using Vet_BLL.DTOs.AdoptionDTOs;
using Vet_BLL.DTOs.AnimalDTOs;
using Vet_BLL.DTOs.AppointmentDTOs;
using Vet_BLL.DTOs.DoctorDTOs;
using Vet_BLL.DTOs.DoctorSlotsDTOs;
using Vet_BLL.DTOs.InvoiceDTOs;
using Vet_BLL.DTOs.OwnerDTOs;
using Vet_BLL.DTOs.StaffDTOs;
using Vet_BLL.DTOs.ZLabDTOs;
using Vet_DAL.Models;

namespace Vet_BLL.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Staff, StaffDto>().ReverseMap();
            CreateMap<Inventory, InventoryDto>().ReverseMap();
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
            CreateMap<Invoice, WeeklyRevenueDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<MedicalRecord, MedicalRecordDto>().ReverseMap();
            CreateMap<Owner, OwnerDto>().ReverseMap();
            CreateMap<Animal, AnimalDto>().ReverseMap();
            CreateMap<AnimalType, AnimalTypeDto>().ReverseMap();
            CreateMap<StaffRole, StaffRoleDto>().ReverseMap();
            CreateMap<Vaccination, VaccinationDto>().ReverseMap();
            CreateMap<DoctorSlot, DoctorSlotDto>().ReverseMap();
            CreateMap<AdoptionQuestionnaire, AdoptionQuestionnaireDto>().ReverseMap();
            CreateMap<AdoptionStatus, AdoptionStatusDto>().ReverseMap();
            CreateMap<PetForAdoption, PetForAdoptionDto>().ReverseMap();
            CreateMap<DoctorSchedule, DoctorScheduleDto>().ReverseMap();
            CreateMap<XrayImage, XrayImageDto>().ReverseMap();
            CreateMap<Appointment, GetAvailableAppointmentsDto>().ReverseMap();
            CreateMap<Appointment, BookAppointmentDto>().ReverseMap();
            CreateMap<Staff, GetStaffNamesdto>().ReverseMap();
            CreateMap<Animal, GetAnimalbyOwnerIDdto>().ReverseMap();
            CreateMap<ZlabResult, ZLabResultDto>().ReverseMap();
            CreateMap<ZtestNormalRange, ZTestNormalRangeDto>().ReverseMap();
            CreateMap<Zzrating, ZZratingDto>().ReverseMap();
            CreateMap<ZzvaccineType, ZZVaccineTypeDto>().ReverseMap();
            CreateMap<Animal, AnimalSearchDto>()
             .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Owner.FullName))
             .ForMember(dest => dest.AnimalId, opt => opt.MapFrom(src => src.AnimalId))
             .ForMember(dest => dest.AnimalName, opt => opt.MapFrom(src => src.AnimalName))
             .ForMember(dest => dest.Species, opt => opt.MapFrom(src => src.Species))
             .ForMember(dest => dest.Breed, opt => opt.MapFrom(src => src.Breed))
             .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.OwnerId))
             .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Owner));




            CreateMap<Animal, AnimalImageDto>().ReverseMap();
            CreateMap<AdoptionQuestionnaire, GetAllAdoptionQuestwithPetNameDto>().ReverseMap();
            CreateMap<Owner, GetAnimalbyOwnerIDdto>().ReverseMap()
            .ForMember(dest => dest.Animals, opt => opt.MapFrom(src => src.Animals));

            CreateMap<ZLabResultDto, ZlabResult>()
             .ForMember(dest => dest.TestNormalRangeId, opt => opt.MapFrom(src => src.TestNormalRangeId))
             .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.Result));

            CreateMap<ZlabResult, ZLabResultResponseDto>()
                .ForMember(dest => dest.LabResultId, opt => opt.MapFrom(src => src.LabResultId))
                .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.Result))
                .ForMember(dest => dest.isNormal, opt => opt.MapFrom(src => src.IsNormal));
                

            CreateMap<ZtestNormalRange, ZLabResultResponseDto>()
                .ForMember(dest => dest.UnitMeasurements, opt => opt.MapFrom(src => src.UnitOfMeasurement));

            CreateMap<Vaccination, VaccinationWithVaccineTypeDto>()
           .ForMember(dest => dest.VaccineName, opt => opt.MapFrom(src => src.VaccineType!.VaccineName))
           .ForMember(dest => dest.Dose, opt => opt.MapFrom(src => src.VaccineType!.Dose));


            CreateMap<AdoptionQuestionnaire, PetQuestionnaireCountDto>()
           .ForMember(dest => dest.QuestionnaireCount, opt => opt.MapFrom(src => 1)); // This is for demonstration

            CreateMap<PetForAdoption, AddPetForAdoptionDto>().ReverseMap();

            CreateMap<AddAdoptionQuestWithOwnerDTO, AdoptionQuestionnaire>().ReverseMap();

            CreateMap<Appointment, AppoiAnimalNameDto>()
            .ForMember(dest => dest.AnimalName, opt => opt.MapFrom(src => src.Animal.AnimalName))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Animal.Owner.FullName))
            .ForMember(dest => dest.SlotStartTime, opt => opt.MapFrom(src => src.DoctorSlot.SlotStartTime)); // Map StartSlotTime


            CreateMap<AddOwnerAndAnimalDto, Owner>()
            .ForMember(dest => dest.Animals, opt => opt.MapFrom(src => new List<Animal> 
            { new Animal { AnimalName = src.Animals.AnimalName, Species = src.Animals.Species,
            Breed = src.Animals.Breed,
            AnimalBirthDate = src.Animals.AnimalBirthDate, Weight = src.Animals.Weight,
            AnimalTypeId = src.Animals.AnimalTypeId, Gender = src.Animals.Gender,
            OwnerId = src.Animals.OwnerId} }));


            CreateMap<Staff, StaffWithRoleDTO>()
            .ForMember(dest => dest.RoleName, opt => opt.Ignore()); // RoleName is manually added in service


            CreateMap<Animal, GetAnimalOwnerTable>()
           .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Owner.FullName))
           .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Owner.Phone))
           .ForMember(dest => dest.OwnerEmail, opt => opt.MapFrom(src => src.Owner.OwnerEmail))
           .ForMember(dest => dest.OwnerBirthDate, opt => opt.MapFrom(src => src.Owner.OwnerBirthDate))
           .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Owner.Address))
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Owner.UserId));

            CreateMap<Appointment, GetAppointmentByDateDto>()
           .ForMember(dest => dest.AppointmentId, opt => opt.MapFrom(src => src.AppointmentId))
           .ForMember(dest => dest.AppointmentReason, opt => opt.MapFrom(src => src.AppointmentReason))
           .ForMember(dest => dest.AppointmentDate, opt => opt.MapFrom(src => src.AppointmentDate))
           .ForMember(dest => dest.SlotStartTime, opt => opt.MapFrom(src => src.DoctorSlot.SlotStartTime))
           .ForMember(dest => dest.AnimalName, opt => opt.MapFrom(src => src.Animal.AnimalName))
           .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Animal.Owner.FullName))
           .ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => src.Staff.FullName));
        }
    }
}
