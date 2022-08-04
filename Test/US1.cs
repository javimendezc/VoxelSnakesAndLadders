using API.Services;
using Xunit;

namespace Test
{
    public class US1
    {
        [Fact(DisplayName = "UAT1: Token_Is_On_Square_1_When_Game_Starts")]
        public void Token_Is_On_Square_1_When_Game_Starts()
        {
            /*
            Given the game is started
            When the token is placed on the board
            Then the token is on square 1
            */
            PlayerToken player = new PlayerToken();
            Assert.True(player.Position == 1);
        }

        [Fact(DisplayName = "UAT2: Token_Is_On_Square_4_When_Moved_3_Spaces")]
        public void Token_Is_On_Square_4_When_Moved_3_Spaces()
        {
            /*
            Given the token is on square 1
            When the token is moved 3 spaces
            Then the token is on square 4
            */
            PlayerToken player = new PlayerToken();
            player.Move(3);
            Assert.True(player.Position == 4);
        }

        [Fact(DisplayName = "UAT3: Token_Is_On_Squere_8_When_Moven_3_And_Then_4")]
        public void Token_Is_On_Squere_8_When_Moven_3_And_Then_4()
        {
            /*
            Given the token is on square 1
            When the token is moved 3 spaces
            And then it is moved 4 spaces
            Then the token is on square 8
            */
            PlayerToken player = new PlayerToken();
            player.Move(3);
            player.Move(4);
            Assert.True(player.Position == 8);

        }
    }
}