using System.Dynamic;

namespace Games;
public class TreblecrossBoard:IGameBoard
{
    private X?[] boardState;
    private HashSet<int> emptyPositions = new HashSet<int>();

    private Stack<int> steps = new Stack<int>();

    public TreblecrossBoard(X[] boardState)
    {
        this.boardState = boardState;
        for (int i = 0; i < boardState.Length; i++) { 
            this.emptyPositions.Add(i);
        }
    }

    public TreblecrossBoard(int size=11)
    {
        this.boardState = new X[size];
        for (int i = 0; i < size; i++) { 
            this.emptyPositions.Add(i);
        }
    }

    public void Display()
    {
        var marker = @"
            +";
        var element = @"
            |";
        for (int i =0; i < this.boardState.Length; i++)
        {   marker = marker + "---+";
            if (this.boardState[i] != null) {
                element = element + $" {this.boardState[i]?.getSymbol()} |";
            }else{
                element = element + "   |";
            }
        }
        Console.WriteLine(marker + element + marker);
    }

    public bool IsDraw()
    {
        throw new NotImplementedException();
    }

    public bool IsWon()
    {
        for (int i = 0; i < (this.boardState.Length - 2); i++){
            if (this.boardState[i] != null && this.boardState[i+1] != null && this.boardState[i+2] != null) {
                return true;
            }
        }
        return false;
    }

    public void Reset()
    {
        this.boardState = new X[this.boardState.Length];
        for (int i = 0; i < boardState.Length; i++) { 
            this.emptyPositions.Add(i);
        }
    }

    public HashSet<int> validMoves(){
        return this.emptyPositions;
    }

    public void SetPiece(X piece, int position){
        this.boardState[position] = piece;
        this.emptyPositions.Remove(position);
        steps.Push(position);
    }

    public void Undo(){
        int position = steps.Pop();
        this.boardState[position] = null; 
        this.emptyPositions.Add(position);
        Display();
    }
}