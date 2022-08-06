namespace API.Interfaces
{
    public interface IGame
    {
        int NumberSquares { get; }

        void Start(IEnumerable<IPlayerToken> players);
        void Play();
        void Reset();
    }
}
