using API;
using API.Interfaces;
using API.Services;
using Moq;
using System;
using Xunit;

namespace Test
{
    public class US3
    {
        [Fact(DisplayName = "UAT1 - Dice_Result_Between_1_6_Included")]
        public void Dice_Result_Between_1_6_Included()
        {
            /*
            Given the game is started
            When the player rolls a die
            Then the result should be between 1-6 inclusive             
             */
            bool invalidResult = false;
            bool[] flagsValues = { false, false, false, false, false, false };

            Dice dice = new Dice();

            int i = 0;
            //Do 100 rolls in order to ensure enought amount of data
            while ((!invalidResult) && (i < 100))
            {
                i++;
                int result = dice.Roll();
                flagsValues[result - 1] = true;
                invalidResult = (result < 1) || (result > Constants.DICE_SIDES);
            }

            Assert.DoesNotContain(false, flagsValues);
            Assert.False(invalidResult);
        }

        [Fact(DisplayName = "UAT2: Token_Moved_4_When_Dice_Result_4")]
        public void Token_Moved_4_When_Dice_Result_4()
        {
            /*
             Given the player rolls a 4
            When they move their token
            Then the token should move 4 spaces
             */
            var mockDice = new Mock<IDice>();
            mockDice.Setup(x => x.Roll()).Returns(4);

            int spacesToMove = mockDice.Object.Roll();
            
            int initPosition = new Random().Next(1, Constants.BOARD_SQUARES - spacesToMove);

            PlayerToken player = new PlayerToken();
            player.Position = initPosition;
            player.Move(spacesToMove);

            Assert.True((player.Position - initPosition).Equals(spacesToMove));
        }
    }
}
