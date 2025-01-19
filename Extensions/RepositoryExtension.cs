using Vet_DAL.Repositories.AdoptionQuestionnaires;
using Vet_DAL.Repositories.AdoptionStatuses;
using Vet_DAL.Repositories.Appointments;
using Vet_DAL.Repositories.AppointmentStatuses;
using Vet_DAL.Repositories.Doctors;
using Vet_DAL.Repositories.DoctorSchedules;
using Vet_DAL.Repositories.Horses;
using Vet_DAL.Repositories.Inventories;
using Vet_DAL.Repositories.Invoices;
using Vet_DAL.Repositories.MedicalRecords;
using Vet_DAL.Repositories.Owners;
using Vet_DAL.Repositories.PetForAdoptions;
using Vet_DAL.Repositories.Pets;
using Vet_DAL.Repositories.StaffRoles;
using Vet_DAL.Repositories.Users;
using Vet_DAL.Repositories.Vaccinations;
using Vet_DAL.Repositories.XrayImages;
using Vet_DAL.Repositories.ZLabResults;
using Vet_DAL.Repositories.ZTestNormalRanges;

namespace VetClinic.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection service)
        {
            service.AddScoped<IAppointmentRepository, AppointmentRepository>();
            service.AddScoped<IStaffRepository, StaffRepository>();
            service.AddScoped<IStaffRoleRepository, StaffRoleRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IOwnerRepository, OwnerRepository>();
            service.AddScoped<IVaccinationRepository, VaccinationRepository>();
            service.AddScoped<IAnimalRepository, AnimalRepository>();
            service.AddScoped<IAnimalTypeRepository, AnimalTypeRepository>();
            service.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
            service.AddScoped<IinventoryRepository, InventoryRepository>();
            service.AddScoped<IinvoiceRepository, InvoiceRepository>();
            service.AddScoped<IDoctorSlotRepository, DoctorSlotRepository>();
            service.AddScoped<IAdoptionQuestionnaireRepository, AdoptionQuestionnaireRepository>();
            service.AddScoped<IAdoptionStatusRepository, AdoptionStatusRepository>();
            service.AddScoped<IPetForAdoptionRepository, PetForAdoptionRepository>();
            service.AddScoped<IDoctorScheduleRepository, DoctorScheduleRepository>();
            service.AddScoped<IXrayImageRepository, XrayImageRepository>();
            service.AddScoped<IZLabResultRepository, ZLabResultRepository>();
            service.AddScoped<IZTestNormalRangeRepository, ZTestNormalRangeRepository>();


            return service;
        }
    }
}
