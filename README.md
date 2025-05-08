# Lab 3 - Software Testing 1

This project covers Lab 3 in the course GMI2J3 - Software Testing 1. It includes mocking, code coverage, and cyclomatic complexity in both C# and Python, as well as automated GUI testing using Selenium. The lab is divided into three main parts:

# Part 3.1 - Python Mocking

In this part, a Python application called `PreferencesManager` was created. The purpose was to demonstrate mocking of two external systems: a file system and a database.

- `IDBClient` and `IFileReader` are abstract interfaces.
- `DBClient` simulates user existence in a database.
- `FileReader` simulates retrieving user preferences from a file.
- `PreferencesManager` checks if a user exists and fetches preferences using injected dependencies.

Unit tests were written using `unittest` and `unittest.mock.MagicMock`, testing both valid and invalid cases. Code coverage was measured using `coverage`, and cyclomatic complexity was analyzed using `lizard`. All methods were below the threshold (CCN < 10), and code coverage was 100%.

# Part 3.2 - C# Mocking

A C# application was built with the following components:

- Interfaces: `IFileService`, `IApiService`, `ILogger`, `IAppSettings`
- Real implementations: `FileService`, `NetworkClient`, `FileLogger`, and `AppSettings`
- `DataService` orchestrates the functionality and uses dependency injection.

Unit tests were written using xUnit and Moq to mock the interfaces. Code coverage was analyzed using Visual Studio's built-in tools, and cyclomatic complexity was evaluated using both Visual Studio and Lizard. After refactoring, all methods had acceptable complexity levels.

# Part 3.3 - GUI Testing with Selenium (Python)

An automated GUI test was created using Selenium and Python to test an HTML file `prime-assert1.html`. This file allows a user to enter a number and checks whether it is prime.

- The test uses `unittest` and `webdriver-manager` to manage the browser driver.
- Numbers 10 to 19 are entered one by one.
- The program reads the alert text and asserts the correctness of the prime-checking logic.

All expected outputs matched the actual results, and the test passed without errors.

# Tools Used
- Python 3.12.0
- unittest, unittest.mock
- coverage
- lizard
- Selenium 4
- C# (.NET 9)
- xUnit
- Moq
- Visual Studio (Enterprise)

# Code Quality
- All code follows SOLID principles
- Dependency injection is used throughout both Python and C# implementations
- Cyclomatic complexity is low (all CCN < 10)
- Code coverage is complete for core functionality

# Lab Feedback
a) Were the lab relevant and appropriate and what about length etc?
Yes, the lab was relevant and appropriate. It touched on real-world testing practices such as mocking, test coverage, complexity analysis, and GUI testing. The scope was realistic for the time frame, although completing all three parts did require good planning and steady progress.

b) What corrections and/or improvements do you suggest for this lab?
It would be helpful to clarify earlier in the instructions that all three parts (Python mocking, C# mocking, and Selenium testing) are required. Initially, the structure made it seem like you were supposed to choose between Python and C#. Also, including a minimal starter project or templates for each part would help students get started more efficiently, especially for those less familiar with one of the languages.