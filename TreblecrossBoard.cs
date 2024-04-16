using System.Dynamic;

namespace Games;
public class TreblecrossBoard:IGameBoard
{
    private X?[] boardState;
    private HashSet<int> emptyPositions = new HashSet<int>();

    private Stack<int> steps = new Stack<int>();
    private Stack<int> redo = new Stack<int>();
    private Stack<X> redoX = new Stack<X>();
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

    public bool Undo(){
        if(steps.Count > 0){
            int position = steps.Pop();
            X? popedPiece = this.boardState[position];
            if(popedPiece != null){
                this.redo.Push(position);
                this.redoX.Push(popedPiece);
            }
            this.boardState[position] = null; 
            this.emptyPositions.Add(position);
            Display();
            return true;
        }
        return false;
    }

    public bool Redo(){
        if(redo.Count > 0){
            int position = redo.Pop();
            X popedPiece = this.redoX.Pop();
            this.boardState[position] = popedPiece; 
            this.emptyPositions.Remove(position);
            Display();
            return true;
        }
        return false;
    }
}