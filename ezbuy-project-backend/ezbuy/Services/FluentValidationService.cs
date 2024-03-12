using FluentValidation;

namespace ezbuy.Services
{
    public class FluentValidationService
    { 
        private readonly IServiceProvider _serviceProvider;

        public FluentValidationService(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public IList<string> Validate<T>(T entity)
            where T : class
        {
            var validator = _serviceProvider.GetService<IValidator<T>>();

            if (validator != null)
            {
                var result = validator.Validate(entity);
                return result.Errors.Select(e => e.ErrorMessage).ToList();
            }

            return new List<string>();
        }
    }
}
