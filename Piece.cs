namespace Games;
public class Piece{
  
  char Symbol;
  string Description;

 public Piece(char symbol, string description){
    Symbol = symbol;
    Description = description;
 }
  public char getSymbol(){
    return Symbol;
  }

  public string getDescription(){
    return Description;
  }
}