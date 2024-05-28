using FizzBuzzAPI.Constants;
using FizzBuzzAPI.Interfaces;
using FizzBuzzAPI.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace FizzBuzzAPI
{
    public class FizzBuzzService : IFizzBuzzService
    {
        public List<FizzBuzzResponse> GetFizzBuzzListOfValues(string[] values)
        {
            List<FizzBuzzResponse> responseList = new();
            if (values?.Length != 0)
            {
                foreach (var value in values)
                {
                    FizzBuzzResponse response = new();
                    int i;
                    if (int.TryParse(value, out i))
                    {
                        var result = GetFizzBuzzValue(value);
                        if (result == FizzBuzzConstants.FizzBuzz || result == FizzBuzzConstants.Fizz || result == FizzBuzzConstants.Buzz)
                        {
                            response.Result = result;
                        }
                        else
                        {
                            response.Result = value.ToString();
                            response.Operation = new List<string> { $"Divided {value} by 3", $"Divided {value} by 5" };
                        }
                    }
                    else
                    {
                        response.Result = $"Invalid item";
                        response.Operation = new List<string> { FizzBuzzConstants.InvalidItem };
                    }
                    responseList.Add(response);
                }
            }
            else
            {
                FizzBuzzResponse errorResponse = new();
                errorResponse.Result = FizzBuzzConstants.InvalidItem;
                responseList.Add(errorResponse);
            }
            return responseList;
        }
        private string GetFizzBuzzValue(string value)
        {
            int inputValue = Convert.ToInt32(value);

            if (inputValue % 15 == 0) 
                return "FizzBuzz";
            if (inputValue % 3 == 0)
                return "Fizz";
            if (inputValue % 5 == 0) 
                return "Buzz";

            return value.ToString();
        }
    }

}
