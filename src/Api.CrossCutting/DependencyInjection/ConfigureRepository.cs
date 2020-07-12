using Microsoft.Extensions.DependencyInjection;
using Data.Repository;
using Domain.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IReposotory<>), typeof(BaseRepository<>));

             serviceCollection.AddDbContext<MyContext>                 (
                 options => options.UseSqlServer("Server=.\\SQLEXPRESS2017;Database=sdAPI;User Id=sa;Password=senha")
             );
        }
    }
}
