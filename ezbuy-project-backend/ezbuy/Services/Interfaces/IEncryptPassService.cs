namespace ezbuy.Services.Interfaces
{
    public interface IEncryptPassService
    {
        string Encrypt(string userRegisterPassword);
        bool VerifyPassword(string pass, string hashDb);
    }
}
