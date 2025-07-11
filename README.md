# Mastermind

## Description

Mastermind is a guessing game where the user attempts to guess the right code. It is a console-based game writtein in C#. The goal is to guess the secret 4-digit code, where each digit is unique and ranges from 0 to 8.
After each guess, the game returns the number of well-placed pieces, and the number of misplaced pieces. The player has limited number of attempts to get the right code. Game ends once all attempts are exhausted.

## Features
- Generates a random 4-digit code by default.
- Supports a custom code via command-line argument.
- Supports custom number of attempts.
- Input validation ensures user input is 4-digit numbers within a range (0-8).
- Provides feedback after each attempt to reach the code.

## Requiremenets
- .NET 8.0 or later
- C# Compiler (e.g., available with Visual Studio)

## How to Run
- Download the repository
- Navigate to the project directory Mastermind
- Build the project ```dotnet build```
- Run the game ```dotnet run```

## Command-Line Arguments
- ```-c <code>```: Specify a custom 4-digit code. The code must have unique digits between 0 to 8. If not specified, random code is generated.
- ```-t <attempts>```: Set the number of attempts. Must be a positive integer. Defaults to 10 if not specified.

### Examples
Default run\
```dotnet run```\
Custom code ```1234```, 10 attempts\
```dotnet run -- -c 1234```\
Random code, 3 attempts\
```dotnet run -- -t 3```\
Custom code ```5678```, 5 attempts\
```dotnet run -- -c 5678 -t 5```

## Code Structure
- Game.cs: Contains the Game class with logic for code generation, input validation, feedback calculation, and gameplay.
- Program.cs: Contains the Main method to parse command-line arguments and start the game.

## Example Output
```
Can you break the code? Enter a valid guess.
1234
Well-placed pieces: 1
Misplaced pieces: 2
6789
Invalid input.
0123
Well-placed pieces: 0
Misplaced pieces: 1
...
Congratz! You did it!
```
