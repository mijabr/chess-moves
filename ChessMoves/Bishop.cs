using System;

namespace ChessMoves
{
    public class Bishop : IChessPiece
    {
        public Bishop(Colour colour)
        {
            Colour = colour;
        }

        public Colour Colour { get; set; }
        public string Name { get; } = "Bishop";

        public bool CanMoveTo(int fromX, int fromY, int toX, int toY)
        {
            return Math.Abs(toX - fromX) == Math.Abs(toY - fromY);
        }
    }
}