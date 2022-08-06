namespace API.Interfaces
{
    public interface IPlayerToken
    {
        public void Move(int spaces);
        public bool IsWinner(IGame game);
    }
}
