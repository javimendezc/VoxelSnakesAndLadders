﻿using API;
using API.Interfaces;
using API.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class US2
    {
        private Mock<IGame> _mockGame;

        public US2()
        {
            _mockGame = new Mock<IGame>();
            _mockGame.SetupGet(x => x.NumberSquares).Returns(Constants.BOARD_SQUARES);
        }

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
            Assert.True(player.Position == Constants.BOARD_SQUARES);
            Assert.True(player.IsWinner(_mockGame.Object));
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
            Assert.False(player.IsWinner(_mockGame.Object));
        }
    }
}
