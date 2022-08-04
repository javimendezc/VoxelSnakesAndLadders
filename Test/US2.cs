using API.Services;
using Xunit;

namespace Test
{
    public class US2
    {
        [Fact(DisplayName = "UAT1: Token_Is_On_100_When_Moved_3_From_97_And_Win")]
        public void Token_Is_On_100_When_Moved_3_From_97_And_Win()
        {
            /*
            Given the token is on square 97
            When the token is moved 3 spaces
            Then the token is on square 100
            And the player has won the game
            */
            PlayerToken player = new PlayerToken();
            player.Position = 97;
            player.Move(3);
            Assert.True(player.Position == API.Constants.BOARD_SQUARES);
            Assert.True(player.IsWinner());
        }

        [Fact(DisplayName = "UAT2: Token_Is_On_97_When_Moved_4_From_97_And_Not_Win")]
        public void Token_Is_On_97_When_Moved_4_From_97_And_Not_Win()
        {
            /*
            Given the token is on square 97
            When the token is moved 4 spaces
            Then the token is on square 97
            And the player has not won the game            
             */
            PlayerToken player = new PlayerToken();
            player.Position = 97;
            player.Move(4);
            Assert.True(player.Position == 97);
            Assert.False(player.IsWinner());
        }
    }
}
