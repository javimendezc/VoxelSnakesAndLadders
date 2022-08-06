using static API.Enums;

namespace API.Interfaces
{
    public interface IGame
    {
        int NumberSquares { get; }
        GAME_STAGES Stage { get; }

        void Start(IEnumerable<IPlayerToken> players);
    }
}
