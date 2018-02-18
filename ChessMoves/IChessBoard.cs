namespace ChessMoves
{
    public interface IChessBoard
    {
        bool Place(string position, IChessPiece chessPiece);
        IChessPiece Square(string position);
        bool ParsePosition(string position, out int row, out int col);
        bool CanMoveTo(string startingPosition, string pos);
    }
}