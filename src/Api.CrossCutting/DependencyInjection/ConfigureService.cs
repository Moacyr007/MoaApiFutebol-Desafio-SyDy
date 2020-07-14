using Domain.Interfaces.Services.Campeonato;
using Domain.Interfaces.Services.Partida;
using Domain.Interfaces.Services.PontuacaoCampeonato;
using Domain.Interfaces.Services.Time;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    {

        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ITimeService, TimeService>();
            serviceCollection.AddTransient<ICampeonatoService, CampeonatoService>();
            serviceCollection.AddTransient<IPartidaService, PartidaService>();
            serviceCollection.AddTransient<IPontuacaoCampeonatoService, PontuacaoCampeonatoService>();
        }
    }
}
