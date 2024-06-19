using ExternalForms_Data.Repositories;
using ExternalForms_Domain.Agreements.Repositories;
using ExternalForms_Domain.Services;

namespace ExternalForms_API.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<FormModelService>();
            services.AddScoped<IFormModelRepository, FormModelRepository>();
            
            services.AddScoped<FieldTypeService>();
            services.AddScoped<IFieldTypeRepository, FieldTypeRepository>();

            services.AddScoped<CustomFieldService>();
            services.AddScoped<ICustomFieldRepository, CustomFieldRepository>();

            services.AddScoped<AnswerService>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();

            services.AddScoped<IMultipleSelectionRepository, MultipleSelectionRepository>();
            
            services.AddScoped<IAnswerFieldRepository, AnswerFieldRepository>();
        }
    }
}
