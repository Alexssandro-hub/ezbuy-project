using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ezBuy.Abstractions.DTOs.Requests;
using ezBuy.Business.Layer.Services.Custom;
using ezBuy.Business.Layer.Services.Interfaces;
using ezBuy.Business.Services.Validation;
using ezBuy.DAO.Layer;
using EzBuy.Interfaces;
using EzBuy.Models;

namespace ezBuy.Business.Layer.Services
{
    public class LoginService : ILoginService<LoginRequest, User>
    {
        private readonly FluentValidationService _validationService;
        private readonly EncryptPassService _encryptPassService;

        public List<string> Errors { get; set; }

        public LoginService(
            FluentValidationService validationService,
            EncryptPassService encryptPassService)
        {
            _validationService = validationService;
            _encryptPassService = encryptPassService;
        }

        public async Task<User> Register(UserRegisterRequest userRegister)
        {
            var user = new User
            {
                Id = 0,
                Name = userRegister.Name,
                LastName = userRegister.LastName,
                FullName = userRegister.FullName,
                Email = userRegister.Email,
                Password = _encryptPassService.Encrypt(userRegister.Password),
                UserName = userRegister.UserName, 
            };

            Errors = Validate(user); 
            if (Errors.Count > 0) return null;

            return null;
            //return await _userRepository.Add(user);
        }

        public async Task<LoginRequest> Login(LoginRequest login)
        {
            throw new NotImplementedException();
        }


        private List<string> Validate(User entity)
        {
            var errorList = new List<string>();
            ValidateRequiredFields(entity, errorList);

            return errorList;
        }

        private void ValidateRequiredFields(User entity, List<string> errorList)
        {
            if (string.IsNullOrWhiteSpace(entity.Name)) errorList.Add(SetMessage("Nome"));
            if (string.IsNullOrWhiteSpace(entity.LastName)) errorList.Add(SetMessage("Sobrenome"));
            if (string.IsNullOrWhiteSpace(entity.FullName)) errorList.Add("Nome completo");
            if (string.IsNullOrWhiteSpace(entity.Email)) errorList.Add("Email");
            if (string.IsNullOrWhiteSpace(entity.Password)) errorList.Add("Senha");
            if (string.IsNullOrEmpty(entity.UserName)) errorList.Add("Nome de usuário");
              
            errorList.AddRange(_validationService.Validate<User>(entity));   
        }

        private static string SetMessage(string fieldName) => $"Campo '{fieldName}' é obrigatório.";
    }
}
