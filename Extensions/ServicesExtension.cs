using Vet_BLL.JWT;
using Vet_BLL.Services.AdoptionQuestionnaires;
using Vet_BLL.Services.AdoptionStatuses;
using Vet_BLL.Services.Appointments;
using Vet_BLL.Services.AppointmentStatuses;
using Vet_BLL.Services.Auth;
using Vet_BLL.Services.Doctors;
using Vet_BLL.Services.DoctorSchedules;
using Vet_BLL.Services.Horses;
using Vet_BLL.Services.Inventories;
using Vet_BLL.Services.Invoices;
using Vet_BLL.Services.MedicalRecords;
using Vet_BLL.Services.Owners;
using Vet_BLL.Services.PetForAdoptions;
using Vet_BLL.Services.Pets;
using Vet_BLL.Services.StaffRoles;
using Vet_BLL.Services.Users;
using Vet_BLL.Services.Vaccinations;
using Vet_BLL.Services.XrayImages;
using Vet_BLL.Services.ZLabResults;
using Vet_BLL.Services.ZTestNormalRanges;

namespace VetClinic.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddService(this IServiceCollection service)
        {
            service.AddScoped<IAppointmentService, AppointmentService>();
            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IStaffService, StaffService>();
            service.AddScoped<IStaffRoleService, StaffRoleService>();
            service.AddScoped<IinventoryService, InventoryService>();
            service.AddScoped<IinvoiceService, InvoiceService>();
            service.AddScoped<IMedicalRecordService, MedicalRecordService>();
            service.AddScoped<IOwnerService, OwnerService>();
            service.AddScoped<IAnimalService, AnimalService>();
            service.AddScoped<IAnimalTypeService, AnimalTypeService>();
            service.AddScoped<IVaccinationService, VaccinationService>();
            service.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            service.AddScoped<IAdoptionQuestionnaireService, AdoptionQuestionnaireService>();
            service.AddScoped<IAdoptionStatusService, AdoptionStatusService>();
            service.AddScoped<IDoctorSlotService, DoctorSlotService>();
            service.AddScoped<IPetForAdoptionService, PetForAdoptionService>();
            service.AddScoped<IDoctorScheduleService, DoctorScheduleService>();
            service.AddScoped<IXrayImagesService, XrayImagesService>();
            service.AddScoped<IZLabResultService, ZLabResultService>();
            service.AddScoped<IZTestNormalRangeService, ZTestNormalRangeService>();



            return service;
        }
    }
}
