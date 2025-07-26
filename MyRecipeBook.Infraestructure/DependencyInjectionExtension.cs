using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Infraestructure.DataAcess;
using MyRecipeBook.Infraestructure.DataAcess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Infraestructure
{
    public static class DependencyInjectionExtension 
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddDbContext(services);
            AddRepositories(services);
        }


        private static void AddDbContext(IServiceCollection services)
        {
            var connectionString = " Data Source=PC-THIAGO;Initial Catalog=meulivrodereceitas;Integrated Security=True;";
            // var connectionString = "Data Source = PC-THIAGO; Initial Catalog=meulivrodereceitas; User ID= cli; Password=@Password123; Trusted_Connection=True; Encrypt=True;TrustServerCertificate=True";
            services.AddDbContext<MyRecipeBookDBContext>(dbContextOptions =>
            {
                dbContextOptions.UseSqlServer(connectionString);
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        }
    }
}
