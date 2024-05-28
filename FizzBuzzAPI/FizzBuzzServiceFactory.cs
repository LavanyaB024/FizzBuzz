using FizzBuzzAPI.Interfaces;

namespace FizzBuzzAPI
{
    public class FizzBuzzServiceFactory : IFizzBuzzServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public FizzBuzzServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IFizzBuzzService CreateService()
        {
            return _serviceProvider.GetRequiredService<IFizzBuzzService>();
        }
    }

}
