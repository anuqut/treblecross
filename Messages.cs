namespace Games;

internal class Messages {
    private static readonly Messages instance = new Messages();
    static Messages(){}

    private Messages(){}
    internal static Messages Instance{
        get{ return instance; }
    }
    internal void Welcome(){
        var welcome = @"Welcome!";
        Console.WriteLine(welcome);
    }

    internal void TreblecrossInstructions(){
        var instuctions = @"Playing Rules,
            1. Players take turns placing one X piece into the row.
            2. The X piece can be placed in any empty position in the board.
            3. The game is won if a player on their turn makes a line of three pieces.";
        Console.WriteLine(instuctions);
    }

    internal void Continue(){
        Console.WriteLine("Do you want to continue with saved game (Y:yes)?\n");
    }
    internal void InvalidMove(){
        Console.WriteLine("Invalid move, please enter a valid position to make a move!\n");
    }
    internal void CongratulateWinner(Player player){
        Console.WriteLine($"Congratulations! {player.GetName()} you won.");
    }
    internal void GameOver() {
        Console.WriteLine("You lost, game over!!");
    }

    internal void ValidInput(){
        var validInput = @"Enter a valid position between 1 to 11 to move or 
enter a valid choice(Q:quit, S:save, I:instructions, U:undo, R:reset): ";
        Console.WriteLine(validInput);
    }

    internal void PromptPlayerTurn(Player player){
        Console.WriteLine($"{player.GetName()}'s turn!\n");
    }

    internal void GameSaved()
    {
        Console.WriteLine("Gamed saved successfully.\n");
    }
}
