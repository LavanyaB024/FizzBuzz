namespace FizzBuzzAPI.Interfaces
{
    public interface IFizzBuzzValidator
    {
        bool TryValidate(string value, out int validatedValue);
    }
}
