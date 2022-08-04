using API.Interfaces;
using API.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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
            while ((!invalidResult) && (i<100))
            {
                i++;
                int result = dice.Throw();
                flagsValues[result - 1] = true;
                invalidResult = (result < 1) || (result > 6);
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
            mockDice.Setup(x => x.Throw()).Returns(4);

            int spacesToMove = mockDice.Object.Throw();
            
            int initPosition = new Random().Next(1, 100 - spacesToMove);

            PlayerToken player = new PlayerToken();
            player.Position = initPosition;
            player.Move(spacesToMove);

            Assert.True((player.Position - initPosition).Equals(spacesToMove));
        }
    }
}
