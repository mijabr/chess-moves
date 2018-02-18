using System;
using NUnit.Framework;
using ChessMoves;
using Shouldly;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessMovesTest
{
    [TestFixture]
    public class ChessMovesTest
    {
        [Test]
        public void CanCreateChessBoard()
        {
            IChessBoard board = new ChessBoard();
        }

        [Test]
        public void CanCreateBishop()
        {
            Bishop b = new Bishop(Colour.White);
            b.Name.ShouldBe("Bishop");
            b.Colour.ShouldBe(Colour.White);
        }

        [Test]
        [TestCase("c5")]
        [TestCase("g1")]
        [TestCase("a7")]
        [TestCase("a1")]
        public void CanPlaceSingleBishopAnywhere(string position)
        {
            IChessBoard board = new ChessBoard();
            board.Place(position, new Bishop(Colour.White)).ShouldBe(true);
            board.Square(position).Name.ShouldBe("Bishop");
        }

        [Test]
        [TestCase("c5", 2, 4)]
        [TestCase("g1", 6, 0)]
        [TestCase("a7", 0, 6)]
        [TestCase("a1", 0, 0)]
        public void CanParsePosition(string position, int x, int y)
        {
            var board = new ChessBoard();
            int row = 0;
            int col = 0;
            board.ParsePosition(position, out row, out col);
            row.ShouldBe(x);
            col.ShouldBe(y);
        }

        [Test]
        [TestCase("h9", 2, 4)]
        public void GivenInvalidPositionThenCanReturnParse(string position, int x, int y)
        {
            var board = new ChessBoard();
            int row = 0;
            int col = 0;
            board.ParsePosition(position, out row, out col).ShouldBeFalse();
        }


        [Test]
        [TestCase("b6", new string[] { "a5", "c7", "d8", "a7", "c5", "d4", "e3", "f2", "g1" })]
        public void BishopCanMoveTo(string startingPosition, string[] validMoveDestinations)
        {
            IChessPiece bishop = new Bishop(Colour.Black);
            IChessBoard board = new ChessBoard();
            board.Place(startingPosition, bishop);

            foreach (var pos in validMoveDestinations)
            {
                board.CanMoveTo(startingPosition, pos).ShouldBeTrue();
            }

        }

        [Test]
        [TestCase("b6", new string[] { "b6", "i8", "a4", "c6", "d7", "a6", "b5", "c4", "d3", "g2", "h1" })]
        public void BishopCanMoveToInvalid(string startingPosition, string[] invalidMoveDestinations)
        {
            IChessPiece bishop = new Bishop(Colour.Black);
            IChessBoard board = new ChessBoard();
            board.Place(startingPosition, bishop);

            foreach (var pos in invalidMoveDestinations)
            {
                board.CanMoveTo(startingPosition, pos).ShouldBeFalse();
            }
        }

        [Test]
        [TestCase("b6", new string[] { "b1", "b2", "b3", "b8", "a6", "c6", "e6", "f6", "g6" })]
        public void CastleCanMoveTo(string startingPosition, string[] validMoveDestinations)
        {
            IChessPiece castle = new Castle(Colour.Black);
            IChessBoard board = new ChessBoard();
            board.Place(startingPosition, castle);

            foreach (var pos in validMoveDestinations)
            {
                board.CanMoveTo(startingPosition, pos).ShouldBeTrue();
            }

        }

        [Test]
        [TestCase("b6", new string[] { "a1", "a2", "i7", "h9" })]
        public void CastleCannotMoveTo(string startingPosition, string[] validMoveDestinations)
        {
            IChessPiece castle = new Castle(Colour.Black);
            IChessBoard board = new ChessBoard();
            board.Place(startingPosition, castle);

            foreach (var pos in validMoveDestinations)
            {
                board.CanMoveTo(startingPosition, pos).ShouldBeFalse();
            }
        }

        [Test]
        [TestCase("b6", "b7", new string[] { "b8" })]
        public void CastleCannotMoveToWhenPieceObstruction(string startingPosition, string obstructedPiecePosition, string[] validMoveDestinations)
        {
            IChessPiece castle = new Castle(Colour.Black);
            var bishop = new Bishop(Colour.Black);

            IChessBoard board = new ChessBoard();
            board.Place(startingPosition, castle);
            board.Place(obstructedPiecePosition, bishop);

            foreach (var pos in validMoveDestinations)
            {
                board.CanMoveTo(startingPosition, pos).ShouldBeFalse();
            }
        }
    }
}
