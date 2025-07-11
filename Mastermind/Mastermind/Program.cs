using System;
class Program
{
    public static void Main(string[] argmnts)
    {
        //to store the value of the code that the user will input
        string secretCode = null;
        //maxiumum attempts of guessing correct code (default)
        int maxAttmpts = 10;
        //to store the value of attempts that user specifiess
        int atmpts;

        //while i is within the array
        for (int i = 0; i < argmnts.Length; i++)
        {
            //checking that the user put -c and what's after is not the end of the array
            if (argmnts[i] == "-c" && i + 1 < argmnts.Length)
                //the value after -c is now stored in secretCode
                secretCode = argmnts[i + 1];

            //checking that the user put -t and what's after is not the end of the array and the after value is string converted to integer
            if (argmnts[i] == "-t" && i + 1 < argmnts.Length && int.TryParse(argmnts[i + 1], out atmpts))
                //the attempt value put by user is now the maximum
                maxAttmpts = atmpts;
        }
        //Console.WriteLine(argmnts.Length);
        Game game = new Game(secretCode, maxAttmpts);
        game.Play();
    }
}
