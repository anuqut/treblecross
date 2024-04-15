namespace Games;
public abstract class Game {
   public abstract void QuitGame();
   public abstract void SaveGame();
   public abstract void SetOpponent(Player player);
   public abstract void Play();
   public abstract void SwapTurns();
}
