using System;

namespace ChessMoves
{
    public class ChessBoard : IChessBoard
    {
        private IChessPiece[,] Squares;

        public ChessBoard()
        {
            this.Squares = new IChessPiece[8, 8];
        }

        public bool Place(string position, IChessPiece chessPiece)
        {
            int x, y;
            ParsePosition(position, out x, out y);
            this.Squares[x, y] = chessPiece;
            return true;
        }

        public IChessPiece Square(string position)
        {
            int x, y;
            ParsePosition(position, out x, out y);
            var chessPiece = this.Squares[x, y];

            return chessPiece;
        }

        public bool ParsePosition(string position, out int x, out int y)
        {
            var mapping = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            x = y = 0;
            x = Array.IndexOf(mapping,position[0]);
            if (x < 0)
                return false;

            y = (int)Char.GetNumericValue(position[1]) - 1;
            if (y < 0 || y > 7)
                return false;
            return true;
        }

        //public bool MoveTo(string startPosition, string endPosition)
        //{
        //    int x;
        //    int y;
        //    ParsePosition(startPosition, out x, out y);

        //    int toX, toY;
        //    ParsePosition(endPosition, out toX, out toY);

        //    var piece = Squares[x, y];

        //    piece.CanMoveTo(toX, toY);
        //}

        public bool CanMoveTo(string startingPosition, string endPosition)
        {
            int fromX;
            int fromY;
            ParsePosition(startingPosition, out fromX, out fromY);

            int toX, toY;
            ParsePosition(endPosition, out toX, out toY);

            if (fromX==toX && fromY==toY)
            {
                return false;
            }

            var piece = Squares[fromX, fromY];

            // To Do:
            // Update piece.CanMoveTo() to handle blockers.


            var result = piece.CanMoveTo(fromX, fromY, toX, toY);

            return result;

            //1. if endPosition a valid location

            //2. 

            //var direction = "NE";
            //var distance = 1;
            //int xne = x + distance;
            //int yne = y + distance;

            //var piece = Squares[x, y];

            
            //return piece.MoveTo(endPosition);
        }
    }
}