using API.Interfaces;

namespace API.Services
{
    public class Dice : IDice
    {
        private int _sides = 6;

        public int Throw()
        {
            return new Random().Next(1, this._sides + 1);
        }
    }
}
