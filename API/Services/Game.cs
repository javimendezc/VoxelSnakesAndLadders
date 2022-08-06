using API.Interfaces;
using static API.Enums;

namespace API.Services
{
    public class Game: IGame
    {
        private IEnumerable<IPlayerToken>? _players;
        private IDice _idice;
        private GAME_STAGES _stage = GAME_STAGES.STOPED;

        public int NumberSquares { get; } = Constants.BOARD_SQUARES;
        public GAME_STAGES Stage 
        { 
            get 
            { 
                if ((_players == null) || (_players.ToList().Count <= 0)) _stage = GAME_STAGES.STOPED;
                else if(_players.Any(x => x.IsWinner(this))) _stage = GAME_STAGES.ENDED;
                else _stage = GAME_STAGES.GAMING;
                return _stage; 
            } 
        }

        public void Start(IEnumerable<IPlayerToken> players)
        {
            _players = players;
            if (_players != null)
            {
                foreach (IPlayerToken player in _players)
                {
                    player.Position = 1;
                }
                _stage = GAME_STAGES.GAMING;
            }
        }
    }
}
