namespace Games;
public class TreblecrossFile:IGameFile
{   
    private string fileName = "Treblecross.json";
    private static readonly TreblecrossFile instance = new TreblecrossFile();
    static TreblecrossFile(){}

    private TreblecrossFile(){}
    public static TreblecrossFile Instance{
        get{ return instance; }
    }
    public string? Load(){
        if (File.Exists(fileName)) {
           return File.ReadAllText(fileName);
        } else {
            return null;
        }

        
    }
    public void Save(string jsonTreblecross)
    {
        File.WriteAllText(fileName, jsonTreblecross);
    }
}