using ezBuy.Abstractions.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ezBuy.Business.Services.Validation;

public class FluentValidationService : IValidationService
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