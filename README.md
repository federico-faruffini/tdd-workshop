# TDD Workshop

This repository is used in a workshop for Master's students of Computer Engineering at the University of Genoa, in their Software Engineering course.

The goal of the workshop is to teach Test-Driven Development (TDD) through hands-on experience using C# as the programming language.

## Setup

1. [Download .NET](https://dotnet.microsoft.com/en-us/download) (the latest version is fine)
2. If you don't have it already, [download Visual Studio Code](https://code.visualstudio.com/)
3. Install the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension in VS Code
4. Clone this repository and open it in VS Code
5. Open a terminal in the repository
6. Run `dotnet build`. If you see "Build succeeded", you are good to go!

## Exercises

There are four exercises in the repository. Their goals are to teach the basics of TDD, refactoring in TDD, and bug fixing in TDD.

The unit test projects are already set up for each project. Here is a list of commands to run the tests. Open a terminal in the repository and run the commands below.

To run all tests at once:
```sh
dotnet test
```

To run only the tests from the project you are working on:
```sh
dotnet test 01-WordCounter/WordCounterTests/WordCounter.Tests.csproj
dotnet test 02-Refactoring/LegacyCode.Tests/LegacyCode.Tests.csproj
dotnet test 03-BugFix/BuggyLibrary.Tests/BuggyLibrary.Tests.csproj
dotnet test 04-PromoCalculator/PromoCalculator.Tests/PromoCalculator.Tests.csproj
dotnet test 05-EmailValidator/EmailValidator.Tests/EmailValidator.Tests.csproj
```

For this workshop, we will use .NET with XUnit as the testing framework. See the [Unit Testing Notes](#unit-testing-notes) section to learn more about XUnit and the code conventions we will use.

---
### 1. Email Validator

We want to create our own dummy email validator. These are the requirements:

- The character `@` appears **exactly once** in the string
- The string **doesn't contain** any of these special chars: `, ; : !`
- Username is valid (**at least one char before the @ sign**)
- Domain is valid:
  - **At least one dot** after `@`
  - **At least one char after @**, then dot, then **at least another char**

Let's use TDD to write the code!

---

### 2. Refactoring with Unit Tests / TDD

The second project has some working code, which is not readable enough. Since we wrote our code test-first in a TDD way, we are now able to refactor it easily and safely.

---

### 3. Bugfix with TDD

My testers told me there is a bug in the crafting system of my game: let's use TDD to fix it!

---

### 4. Promo Calculator

Now, for a more realistic scenario with many classes and conditional checks, let's implement a promo calculator for an e-commerce website.

**Requirements:**
- If there is no promo applied, the final price is the total of the cart
- If I apply a "two euro coupon for tshirts", it should remove 2€ from the cart if the cart contains a tshirt
- 10% off if the total is > 100€
- You can't apply discounts to products of type "Gift Card"
- 3x2 in category "shoes"
- A combination of promotions will always gave max 20€ discount
- The total can't be negative

## Unit Testing Notes

### Unit Testing in XUnit

There are two kinds of tests in XUnit:

#### Fact

A Fact is used for tests that have no parameters and always run the same way.

```csharp
[Fact]
public void Add_TwoNumbers_ReturnsCorrectResult()
{
    var calculator = new Calculator();

    var result = calculator.Add(2, 3);

    Assert.Equal(5, result);
}
```

#### Theory

A Theory is used for parameterized tests, allowing you to run the same test logic with different input data.

```csharp
[Theory]
[InlineData(2, 3, 5)]
[InlineData(-1, 1, 0)]
[InlineData(0, 0, 0)]
public void Add_MultipleInputs_ReturnsExpectedResult(int a, int b, int expected)
{
    var calculator = new Calculator();

    var result = calculator.Add(a, b);

    Assert.Equal(expected, result);
}
```

#### Assertions

Assertions are used to check that the code under test behaves as expected. They compare actual results to expected values and will fail the test if the condition is not met.

The most common assertions in XUnit are:

```csharp
Assert.Equal(expected, actual)
Assert.True(condition)
Assert.False(condition)
Assert.NotNull(obj)
```

---

### Unit Testing Conventions

The **Given-When-Then** and **Arrange-Act-Assert** patterns help structure your unit tests for clarity.

#### Given-When-Then

Describes the scenario:

- **Given** some initial context,
- **When** an action occurs,
- **Then** a particular result is expected.

```csharp
[Fact]
public void GivenEmptyString_WhenAdd_ThenReturnsZero()
{
    var calculator = new Calculator();
    var input = "";

    var result = calculator.Add(input);

    Assert.Equal(0, result);
}
```

#### Arrange-Act-Assert

A practical way to organize test code:

- **Arrange**: set up the objects and data needed,
- **Act**: perform the action being tested,
- **Assert**: check that the outcome matches expectations.

```csharp
[Fact]
public void GivenEmptyString_WhenAdd_ThenReturnsZero()
{
    // Arrange
    var calculator = new Calculator();
    var input = "";

    // Act
    var result = calculator.Add(input);

    // Assert
    Assert.Equal(0, result);
}
```