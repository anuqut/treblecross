namespace Games;
using System.Text.Json;

public class TreblecrossGame:Game
{
    private Player currentPlayer;
    private Player otherPlayer;
    private TreblecrossBoard treblecrossBoard;

    public override void SwapTurns(){
        Player temp = this.currentPlayer;
        this.currentPlayer = this.otherPlayer;
        this.otherPlayer = temp;
    }

    public TreblecrossGame(Player player, Player otherPlayer){
        this.currentPlayer = player;
        this.otherPlayer = otherPlayer;
        this.treblecrossBoard = new TreblecrossBoard();
    }

    public override void QuitGame() {
        SaveGame();
        System.Environment.Exit(0);
    }

    public override void SaveGame(){
        TreblecrossFile.Instance.Save(JsonSerializer.Serialize(this));
        Messages.Instance.GameSaved();
    }

    public override void SetOpponent(Player player)
    {
        this.otherPlayer = player;
    }

    public override void Play(){

        while(!treblecrossBoard.IsWon()){
            Messages.Instance.PromptPlayerTurn(currentPlayer);
            treblecrossBoard.Display();
            if (currentPlayer.IsComputer()){
               ComputerPlayer cp = (ComputerPlayer) currentPlayer;
               int position = cp.RandomMove(treblecrossBoard.validMoves());
               treblecrossBoard.SetPiece((X)cp.GetPiece(), position);
               SwapTurns();
            }else{
                var input = currentPlayer.PlayerInput();

                if (input == "Q" || input == "Quit") {
                    QuitGame();
                }

                if (input == "S" || input == "save") {
                    SaveGame();
                    continue;
                }

                if (input == "I" || input == "instructions") {
                    Messages.Instance.TreblecrossInstructions();
                    continue;
                }

                if (input == "U" || input == "undo") {
                    treblecrossBoard.Undo();
                    SwapTurns();
                    if (currentPlayer.IsComputer()){
                        treblecrossBoard.Undo();
                        SwapTurns();
                    }
                    continue;
                }

                if (input == "R" || input == "reset") {
                    treblecrossBoard.Reset();
                    if (otherPlayer.GetCode() == 1){
                        SwapTurns();
                    }
                    continue;
                }

                int position;
                bool isNumeric = int.TryParse(input, out position);
                if(isNumeric && treblecrossBoard.validMoves().Contains(position - 1)){
                    treblecrossBoard.SetPiece((X)currentPlayer.GetPiece(), position - 1);
                    SwapTurns();
                }else{
                    Messages.Instance.InvalidMove();
                    
                }
            }
          
        }
        treblecrossBoard.Display();
        if(otherPlayer.IsComputer()){
            Messages.Instance.GameOver();
        }else{
            Messages.Instance.CongratulateWinner(otherPlayer);
        }
    }
}