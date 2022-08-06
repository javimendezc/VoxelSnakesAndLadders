namespace API.Interfaces
{
    public interface IPlayerToken
    {
        string Name { get; set; }
        int Position { get; set; }

        void Move(int spaces);
        bool IsWinner(IGame game);
    }
}
