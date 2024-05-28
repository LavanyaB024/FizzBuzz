using FizzBuzzAPI.Models;

namespace FizzBuzzAPI.Interfaces
{
    public interface IFizzBuzzService
    {
        List<FizzBuzzResponse> GetFizzBuzzListOfValues(string[] values);
    }

}
