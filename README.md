# TDD Workshop
This is the repository used in a workshop for Masters' students of Computer Engineering at the University of Genoa, in their Software Engineering course.

The goal of the Workshop is to teach Test-Driven Development through a hands-on experience using c# as a programming language.

## Setup
- [Download .NET](https://dotnet.microsoft.com/en-us/download), the latest version is fine
- If you don't have it already, [download Visual Studio Code ](https://code.visualstudio.com/)
- Install the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension in VS Code
- Clone this repository and open it in VS Code
- Open a terminal in the repository
- Run `dotnet build`. If the message "Build succeeded" pops up, you are good to go!

## Exercises
There are four exercises in the repository. Their goals are to teach the basics of TDD, refactoring in TDD and bugfixing in TDD.

The unit test projects are set up already for each project, here is a list of commands. Open a terminal in the repository and run the commands.

To run all tests at once, type 
```
dotnet test
```

To run only the tests from the project you are working in, run one of these
```
dotnet test 01-EmailValidator/EmailValidator.Tests/EmailValidator.Tests.csproj
dotnet test 02-Refactoring/LegacyCode.Tests/LegacyCode.Tests.csproj
dotnet test 03-BugFix/BuggyLibrary.Tests/BuggyLibrary.Tests.csproj
dotnet test 04-PromoCalculator/PromoCalculator.Tests/PromoCalculator.Tests.csproj
```
### 1 - Email validator
We want to create our own dummy email validator. These are the requirements:
- the character "@" appears exactly once in the string
- the string doesn't contain any of these special chars (,;:!)
- username is valid (at least one char before the @ sign)
- domain is valid
  - at least one dot after @
  - at least one char after @, then dot, then at least another char

Let's use TDD to write the code!

### 2 - Refactoring with unit tests / TDD
The second project has some working code, which is not readable enough. Since we wrote our code test-first in a TDD way, we are now able to refactor it easily and safely.

### 3 - Bugfix with TDD
My testers told me there is a bug in the crafting system of my game: let's use TDD to fix it!

## 4 Promo calculator
Now, for a more realistic scenario with many classes and conditional checks, let's implement a promo calculator for an e-commerce website.

















These are the requirements:
- if there is no promo applied, the final price is the total of the cart
- If I apply a "two euro coupon", it should remove 2€ from the cart
- 10% if the total is > 100€
- 3x2 in category "shoes"
- fix and variable promo code discount
- you can't apply discounts to products of type "Gift Card" 
- combination of rules, max 20€



