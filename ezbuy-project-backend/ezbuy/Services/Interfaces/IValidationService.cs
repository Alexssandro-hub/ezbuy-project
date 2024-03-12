namespace ezbuy.Services.Interfaces
{
    public interface IValidationService
    {
        IList<string> Validate<T>(T entity)
            where T : class;
    }
}
