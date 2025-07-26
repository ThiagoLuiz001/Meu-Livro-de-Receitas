using MyRecipeBook.Application.Services.AutoMapper;
using MyRecipeBook.Application.Services.Cryptography;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Exceptions.ExceptionsBase;
using MyRecipeBook.Domain.Repositories.User;


namespace MyRecipeBook.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        private readonly IUserWriteOnlyRepository _writeOnlyRepository;
        private readonly IUserReadOnlyRepository _readeOnlyRepository;

        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
        {
            var cryptographyPassword = new PasswordEncripter();

            var autoMapper = new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper();

            Validate(request);
            
            var user = autoMapper.Map<Domain.Entities.User>(request);

            user.Password = cryptographyPassword.Encrypt(request.Password);

            await _writeOnlyRepository.Add(user);

            return new ResponseRegisteredUserJson
            {
                Name = request.Name,
            };
        }

        private void Validate(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            if(result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
