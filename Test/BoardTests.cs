using API.Services;
using System.Collections.Generic;
using Xunit;
using static API.Enums;

namespace Test
{
    public class BoardTests
    {
        [Fact(DisplayName = "Boards_Init_Stoped")]
        public void Boards_Init_Stoped()
        {
            Board board = new Board(new Dice());
            Assert.True(board.Stage.Equals(GAME_STAGES.STOPED));
        }

        [Fact(DisplayName = "Boards_Without_Dice_Is_Stoped")]
        public void Boards_Without_Dice_Is_Stoped()
        {
            Board board = new Board(null);
            Assert.True(board.Stage.Equals(GAME_STAGES.STOPED));
        }

        [Fact(DisplayName = "Game_Only_Can_Play_With_Players_And_Dice")]
        public void Game_Only_Can_Play_With_Players_And_Dice()
        {
            Board board = new Board(new Dice());
            board.Start(null);
            board.Play();
            Assert.True(board.Stage.Equals(GAME_STAGES.STOPED));

            List<PlayerToken> tokens = new List<PlayerToken>();
            board.Start(tokens);
            board.Play();
            Assert.True(board.Stage == GAME_STAGES.STOPED);

            tokens.Add(new PlayerToken());
            board.Play();
            Assert.False(board.Stage.Equals(GAME_STAGES.STOPED));
        }

        [Fact(DisplayName = "Boards_Play_Ends_With_A_Unique_Winner")]
        public void Boards_Play_Ends_With_A_Unique_Winner()
        {
            Board board = new Board(new Dice());
            List<PlayerToken> tokens = new List<PlayerToken>();
            tokens.Add(new PlayerToken());
            board.Start(tokens);
            Assert.True(board.Stage == GAME_STAGES.GAMING);
            board.Play();
            Assert.True(board.Stage.Equals(GAME_STAGES.ENDED));
            Assert.True(tokens.FindAll(x => x.IsWinner(board)).Count.Equals(1));
        }
    }
}
