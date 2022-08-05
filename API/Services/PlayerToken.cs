using API.Interfaces;

namespace API.Services
{
    public class PlayerToken : IPlayerToken
    {
        public string Name { get; set; } = $"Player_{Guid.NewGuid()}";
        public int Position { get; set; } = 1;

        public bool IsWinner(IBoard board) 
        {
            return this.Position == board.NumberSquares;
        }

        public void Move(int spaces)
        {
            int finalPos = this.Position + spaces;
            if (finalPos <= Constants.BOARD_SQUARES)
            {
                this.Position = finalPos;
            }
        }
    }
}
