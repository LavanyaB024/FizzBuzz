using FizzBuzzAPI.Constants;
using FizzBuzzAPI.Interfaces;

namespace FizzBuzzAPI
{
    public class FizzBuzzProcessor : IFizzBuzzProcessor
    {
        public string GetFizzBuzzValue(int value)
        {
            if (value % 15 == 0)
                return FizzBuzzConstants.FizzBuzz;
            if (value % 3 == 0)
                return FizzBuzzConstants.Fizz;
            if (value % 5 == 0)
                return FizzBuzzConstants.Buzz;

            return value.ToString();
        }
    }
}
