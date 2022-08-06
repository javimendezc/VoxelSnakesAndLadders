namespace API.Interfaces
{
    public interface IPlayerToken
    {
        string Name { get; set; }
        int Position { get; set; }

        public void Move(int spaces);
        public bool IsWinner(IGame game);
    }
}
