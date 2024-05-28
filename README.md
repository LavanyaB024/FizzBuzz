# FizzBuzz

FizzBuzzAPI is a .NET 8 Web API that accepts an array of values and outputs "Fizz" for multiples of 3, "Buzz" for multiples of 5, and "FizzBuzz" for multiples of both 3 and 5. It also displays the division operations performed at the end of the run.

## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Technologies](#technologies)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Running Tests](#running-tests)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Introduction
FizzBuzzAPI is designed to demonstrate SOLID principles, dependency injection, factory design pattern, and separation of concerns in a .NET 8 Web API.

## Features
- Accepts an array of values via a POST request
- Outputs "Fizz" for multiples of 3, "Buzz" for multiples of 5, and "FizzBuzz" for multiples of both
- Provides details of the division operations performed
- Implements SOLID principles, dependency injection, and factory design pattern

## Technologies
- .NET 8
- ASP.NET Core
- Moq (for unit testing)
- NUnit (for unit testing)
- Swagger (for API documentation)

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A code editor (e.g., [Visual Studio](https://visualstudio.microsoft.com/), [Visual Studio Code](https://code.visualstudio.com/))

### Installation
1. Clone the repository:
    ```sh
    git clone https://github.com/LavanyaB024/FizzBuzz.git
    cd FizzBuzzAPI
    ```

2. Build the project:
    ```sh
    dotnet build
    ```

3. Run the project:
    ```sh
    dotnet run --project FizzBuzzAPI
    ```

4. Open your browser and navigate to `https://localhost:7252/swagger` to view the Swagger documentation and test the API.

## Usage
You can use tools like [Postman](https://www.postman.com/) to send requests to the API.

### Example Request

POST api/FizzBuzz
Content-Type: application/json

```
["1", "3", "5", "15", "A", "23"]
```

**### Example Response**

```
[
  {
    "result": "1",
    "operation": ["Divided 1 by 3", "Divided 1 by 5"]
  },
  {
    "result": "Fizz"
  },
  {
    "result": "Buzz"
  },
  {
    "result": "FizzBuzz"
  },
  {
    "result": "Invalid item",
    "operation": ["Invalid item"]
  }
]
```
