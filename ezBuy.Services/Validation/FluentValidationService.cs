using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ezBuy.BusinessCore.Validation
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

            if (validator is not null)
                return validator.Validate(entity).Errors.Select(e => e.ErrorMessage).ToList();

            return new List<string>();
        }
    }
}
