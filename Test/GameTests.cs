using API.Services;
using System.Collections.Generic;
using Xunit;
using static API.Enums;

namespace Test
{
    public class GameTests
    {
        [Fact(DisplayName = "Game_Init_Stoped")]
        public void Game_Init_Stoped()
        {
            Game game = new Game(new Dice());
            Assert.True(game.Stage.Equals(GAME_STAGES.STOPED));
        }

        [Fact(DisplayName = "Game_Only_Can_Play_With_Players_And_Dice")]
        public void Game_Only_Can_Play_With_Players_And_Dice()
        {
            Dice dice = null;
            List<PlayerToken> tokens = null;

            Game game = new Game(dice);
            game.Start(tokens);
            game.Play();
            Assert.True(game.Stage.Equals(GAME_STAGES.STOPED));

            dice = new Dice();
            game = new Game(dice);
            game.Start(tokens);
            game.Play();
            Assert.True(game.Stage.Equals(GAME_STAGES.STOPED));

            tokens = new List<PlayerToken>();
            game.Start(tokens);
            game.Play();
            Assert.True(game.Stage == GAME_STAGES.STOPED);

            tokens.Add(new PlayerToken());
            game.Play();
            Assert.False(game.Stage.Equals(GAME_STAGES.STOPED));
        }

        [Fact(DisplayName = "Games_Play_Ends_With_A_Unique_Winner")]
        public void Games_Play_Ends_With_A_Unique_Winner()
        {
            Game game = new Game(new Dice());
            List<PlayerToken> tokens = new List<PlayerToken>();
            tokens.Add(new PlayerToken());
            game.Start(tokens);
            Assert.True(game.Stage == GAME_STAGES.GAMING);
            game.Play();
            Assert.True(game.Stage.Equals(GAME_STAGES.ENDED));
            Assert.True(tokens.FindAll(x => x.IsWinner(game)).Count.Equals(1));
        }
    }
}
