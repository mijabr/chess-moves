namespace ChessMoves
{
    public interface IChessPiece
    {
        string Name { get; }
        Colour Colour { get; set; }
        bool CanMoveTo(int fromX, int fromY, int toX, int toY);
    }
}