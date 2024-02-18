namespace ezBuy.Abstractions.Services;

public interface IValidationService
{
    IList<string> Validate<T>(T entity)
        where T : class;
}