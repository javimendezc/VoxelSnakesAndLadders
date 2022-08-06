using API.Interfaces;
using API.Services;
using Moq;
using System.Collections.Generic;
using Xunit;
using static API.Enums;

namespace Test
{
    public class US1
    {
        private IPlayerToken _player;

        public US1()
        {
            _player = new Mock<PlayerToken>().Object;
        }
        

        [Fact(DisplayName = "UAT1: Token_Is_On_Square_1_When_Game_Starts")]
        public void Token_Is_On_Square_1_When_Game_Starts()
        {
            /*
            Given the game is started
            When the token is placed on the game
            Then the token is on square 1
            */
            List<IPlayerToken> listPlayers = new List<IPlayerToken>();
            listPlayers.Add(_player);

            IGame game = new Mock<Game>().Object;
            game.Start(listPlayers);

            Assert.True(game.Stage.Equals(GAME_STAGES.GAMING));
            Assert.True(_player.Position == 1);
            Assert.DoesNotContain(listPlayers, p => p.Position != 1);
        }

        [Fact(DisplayName = "UAT2: Token_Is_On_Square_4_When_Moved_3_Spaces")]
        public void Token_Is_On_Square_4_When_Moved_3_Spaces()
        {
            /*
            Given the token is on square 1
            When the token is moved 3 spaces
            Then the token is on square 4
            */
            _player.Position = 1;
            _player.Move(3);

            Assert.True(_player.Position == 4);
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
            _player.Position = 1;
            _player.Move(3);
            _player.Move(4);

            Assert.True(_player.Position == 8);
        }
    }
}