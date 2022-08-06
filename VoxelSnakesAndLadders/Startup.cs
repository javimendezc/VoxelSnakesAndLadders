using API.Services;
using API.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace VoxelSnakesAndLadders
{
    public static class Startup
    {
        public static IServiceCollection ConfigServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<IPlayerToken, PlayerToken>();
            services.AddTransient<IDice, Dice>();
            services.AddTransient<IGame, Game>();

            return services;
        }
    }
}
