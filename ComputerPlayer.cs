using System.Numerics;

namespace Games;
public class ComputerPlayer: Player
{
    private Random rnd = new Random();
    public ComputerPlayer(): base("Computer", 2, new X()){}

    public int RandomMove(HashSet<int> validMoves){
        int[] asArray = validMoves.ToArray();
        return asArray[rnd.Next(asArray.Length)];
    }

    public override bool IsComputer()
    {
        return true;
    }
}