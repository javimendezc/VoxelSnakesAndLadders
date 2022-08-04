using API.Interfaces;

namespace API.Services
{
    public class PlayerToken : IPlayerToken
    {
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; } = 1;

        public bool IsWinner()
        {
            return this.Position == Constants.BOARD_SQUARES;
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
