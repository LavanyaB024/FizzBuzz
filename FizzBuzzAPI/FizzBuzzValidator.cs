using FizzBuzzAPI.Interfaces;

namespace FizzBuzzAPI
{
    public class FizzBuzzValidator : IFizzBuzzValidator
    {
        public bool TryValidate(string value, out int validatedValue)
        {
            return int.TryParse(value, out validatedValue);
        }
    }
}
