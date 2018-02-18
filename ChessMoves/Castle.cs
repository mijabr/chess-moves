using System;

namespace ChessMoves
{
    public class Castle : IChessPiece
    {
        private Colour black;

        public Castle(Colour black)
        {
            this.black = black;
        }

        public Colour Colour { get; set; }
        public string Name { get; } = "Castle";

        public bool CanMoveTo(int fromX, int fromY, int toX, int toY)
        {
            if ((fromX != toX) && (fromY != toY))
            {
                return false;
            }

            return (fromX == toX) || (fromY == toY);
        }
    }
}