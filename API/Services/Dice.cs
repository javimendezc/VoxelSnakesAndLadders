using API.Interfaces;

namespace API.Services
{
    public class Dice : IDice
    {
        private int _sides = Constants.DICE_SIDES;

        public int Roll()
        {
            return new Random().Next(1, _sides + 1);
        }
    }
}
