using Games;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Messages.Instance.Welcome();

        if (TreblecrossFile.Instance.Load() != null)
        {
            Messages.Instance.Continue();
            string? input = Console.ReadLine();
            if (input != null && (input == "Y" || input == "yes"))
            {
                // To do deserialisatio of json file to game object
                throw new NotImplementedException();
            } else {
               NewGame();
            }
        }
        else { 
            NewGame();
        }
    }

    private static void NewGame(){
        Player playerOne;
        Player playerTwo = new Player("Player 2", 2, new X());;
        Console.WriteLine("Enter Player one name: ");
        string? playerOneName = Console.ReadLine();
        if (playerOneName != null)
        {
            playerOne = new Player(playerOneName, 1, new X());
        }
        else
        {
            playerOne = new Player("Player 1", 1, new X());
        }
        Console.WriteLine("Do you want to play againts computer (Y:yes, N:no)?: ");
        string? computerOpponent = Console.ReadLine();
        if (computerOpponent != null)
        {
            if (computerOpponent == "Y" || computerOpponent == "yes")
            {
                playerTwo = new ComputerPlayer();
            }
            else if (computerOpponent == "N" || computerOpponent == "no")
            {
                Console.WriteLine("Enter Player two name: ");
                string? playerTwoName = Console.ReadLine();
                if (playerTwoName != null)
                {
                    playerTwo.SetName(playerTwoName);
                }
            }else{
                System.Environment.Exit(0);
            }
        }

        TreblecrossGame treblecrossGame = new TreblecrossGame(playerOne, otherPlayer: playerTwo);
        treblecrossGame.Play();
    }
}