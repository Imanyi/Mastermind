using System;
using System.Collections.Generic;
using System.Linq;

public class Game
{
	private int maxAttmpts;
	private string secretCode;
	private char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
	public Game(string code, int attmpts)
	{
        maxAttmpts = attmpts;
		if(code == null || !isValid(code))
		{
			secretCode = GenerateRandom();
		}
		else
		{
			secretCode = code;
		}
	}
    private string GenerateRandom()
	{
		Random random = new Random();
        char[] code = new char[4];
        HashSet<char> dplic = new HashSet<char>();

        for (int i = 0; i < 4; i++)
        {
            char digit;
            do
            {
                digit = digits[random.Next(digits.Length)];
            } while (!dplic.Add(digit));
            code[i] = digit;
        }
        return new string(code);
    }

	public void Play()
	{
		int wellPlaced;
		int misPlaced;

		Console.WriteLine("Can you break the code? Enter a valid guess.");
		for(int attmpt = 0; attmpt < maxAttmpts; attmpt++)
		{
			string userInput = Console.ReadLine();
			if (userInput == null)
				return;
			if(!isValid(userInput))
			{
				Console.WriteLine("Invalid input.");
				attmpt--;
				continue;
			}

			CheckPieceStatus(userInput, out wellPlaced, out misPlaced);

			if(wellPlaced == 4)
			{
				Console.WriteLine("Congratz! You did it!");
				return;
			}

			Console.WriteLine("Well placed pieces: " + wellPlaced);
			Console.WriteLine("Misplaced pieces: " + misPlaced);

		}

		Console.Write("Maximum attempts reached. Game is over. Correct code was "+ secretCode);
	}
	private bool isValid(string userInput)
	{
		if(userInput.Length != 4 
			|| !userInput.All(char.IsDigit) 
			|| !userInput.All(c => c >= '0' && c <= '8'))
		{
			return false;
		}

        return userInput.Distinct().Count() == 4;
	}

	private void CheckPieceStatus(string userInput,out int wellPlaced, out int misPlaced)
	{
		wellPlaced = 0;
		misPlaced = 0;
		bool[] secretMatch = new bool[4];
		bool[] userMatch = new bool[4];

		for(int i = 0; i < 4; i++)
		{
			//if the number in index i in user input is matching the number in index i of the secret code
			if (userInput[i] == secretCode[i])
			{
				//then we have a correctly placed number
				wellPlaced++;
				secretMatch[i] = true;
				userMatch[i] = true;
			}
		}
		for(int i = 0; i < 4; i++)
		{
			if (userMatch[i]) continue;
			for(int j = 0;  j < 4; j++)
			{
				if (secretMatch[j]) continue;
				if (userInput[i] == secretCode[j])
				{
					misPlaced++;
					secretMatch[j] = true;
					break;
				}
			}
		}


	}
}
