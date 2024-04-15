using System.Numerics;

namespace Games;
public class Player
{
    private string name;
    private int code;

    private Piece piece;

    public virtual bool IsComputer()
    {
        return false;
    }

    public Player( string name, int code, Piece piece){
        this.name = name;
        this.code = code;
        this.piece = piece;
    }

    public string? PlayerInput(){
        Messages.Instance.ValidInput();
        return Console.ReadLine();
    }

    public string GetName(){
        return name;
    }

    public void SetName(string name){
        this.name = name;
    }

    public int GetCode(){
        return code;
    }

    public Piece GetPiece(){
        return piece;
    }   
}