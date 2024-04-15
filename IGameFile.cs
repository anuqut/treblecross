namespace Games;
interface IGameFile {
    void Save(string gameJson);
    string? Load();
}
