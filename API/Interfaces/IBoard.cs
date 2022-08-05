namespace API.Interfaces
{
    public interface IBoard
    {
        public int NumberSquares { get; }

        void Start(IEnumerable<IPlayerToken> players);
        void Play();
        void Reset();
    }
}
