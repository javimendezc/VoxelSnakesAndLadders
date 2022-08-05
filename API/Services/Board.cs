using API.Interfaces;
using static API.Enums;

namespace API.Services
{
    public class Board: IBoard
    {
        private IEnumerable<IPlayerToken>? _players;
        private IDice _idice;
        private GAME_STAGES _stage = GAME_STAGES.STOPED;

        public int NumberSquares { get; } = Constants.BOARD_SQUARES;
        public GAME_STAGES Stage 
        { 
            get 
            { 
                if ((_players == null) || (_players.ToList().Count <= 0) || (_idice == null)) _stage = GAME_STAGES.STOPED;
                else if(_players.Any(x => x.IsWinner(this))) _stage = GAME_STAGES.ENDED;
                else _stage = GAME_STAGES.GAMING;
                return _stage; 
            } 
        }

        public Board(IDice dice)
        {
            _idice = dice;
        }

        public void Start(IEnumerable<IPlayerToken> players)
        {
            _players = players;
            _stage = GAME_STAGES.GAMING;
        }

        public void Play()
        {
            if (Stage == GAME_STAGES.GAMING)
            {
                while(Stage != GAME_STAGES.ENDED)
                {
                    foreach (var player in _players)
                    {
                        int spacesToMove = _idice.Roll();
                        player.Move(spacesToMove);
                        if (player.IsWinner(this))
                        {
                            _stage = GAME_STAGES.ENDED;
                            break;
                        }
                    }
                }
            }
        }

        public void Reset()
        {
            _players = null;
            _stage = GAME_STAGES.STOPED;
        }
    }
}
