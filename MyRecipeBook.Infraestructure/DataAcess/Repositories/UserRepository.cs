using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities;
using MyRecipeBook.Domain.Repositories.User;

namespace MyRecipeBook.Infraestructure.DataAcess.Repositories
{
    public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
    {
        private readonly MyRecipeBookDBContext _dbcontext;
        public UserRepository(MyRecipeBookDBContext dbcontext) => _dbcontext = dbcontext;


        public async Task Add(User user) => await _dbcontext.Users.AddAsync(user);

        public async Task<bool> ExistActiveUserWithEmail(string email) => await _dbcontext.Users.AnyAsync(x => x.Email.Equals(email) && x.Active);

        public Task<bool> ExistsActiveUserWithEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
