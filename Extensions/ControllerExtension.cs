using VetClinic.Filters;

namespace VetClinic.Extensions
{
    public static class ControllerExtension
    {
        public static IServiceCollection AddController(this IServiceCollection service)
        {
            service.AddControllers(options =>
            {
                options.Filters.Add(new GlobalExceptionFilter());
            });
            return service;
        }
    }
}
