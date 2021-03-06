using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
    movement of the snake 
    how to snake grows whe ninterating with snack
    how to snake dies case 1 when it hits it s self
                      case 2 when it hits a wall
    clear snake if it dies
 */
namespace SnakeGameLozaTadesse
{
    class Player
    {
        public Player(ref ushort[,] board, int boardSizeX, int boardSizeY, Point startPosition)
        {
            Board = board;
            BoardSizeX = boardSizeX;
            BoardSizeY = boardSizeY;
            SnakeParts = new List<SnakePart>()
            {
                new SnakePart("SnakeHead", startPosition),
                new SnakePart("SnakePart", new Point(startPosition.X - 1, startPosition.Y)), 
                new SnakePart("SnakePart", new Point(startPosition.X - 2, startPosition.Y)), 
            };
            moveCoordinate = new Point(0, 0);
        }

        ushort[,] Board;
        public List<SnakePart> SnakeParts;
        int BoardSizeX;
        int BoardSizeY;
        Point moveCoordinate; 
        public int Direction;
        int ProposedDirection = -1;

        int toGrow = 0;
        public int ScoreToAdd = 0;

        public void SetDirection(int newDirection)
        { //add new direction to proposed direction
            ProposedDirection = newDirection;
        }

        private void ChangeDirection()
        {
            if (ProposedDirection != Direction)
            {
                
                bool change = false;

                if (ProposedDirection == 1 && Direction != 2) { moveCoordinate = new Point(-1, 0); change = true; }
                else if (ProposedDirection == 2 && Direction != 1) { moveCoordinate = new Point(1, 0); change = true; }
                else if (ProposedDirection == 3 && Direction != 4) { moveCoordinate = new Point(0, -1); change = true; }
                else if (ProposedDirection == 4 && Direction != 3) { moveCoordinate = new Point(0, 1); change = true; }

                if (change)
                {
                    Direction = ProposedDirection;
                }
            }
        }

        private void EatCurrentFood(ushort FoodBoardValue, Point position)//apple count
        {
            Food CurrentFoodFake = FoodService.NewFood(FoodBoardValue, position);
            toGrow += CurrentFoodFake.Snack;
            ScoreToAdd += CurrentFoodFake.Snack * 100;
        }

        public string Move()
        {
            //change direction if scheduled
            ChangeDirection();

            Point newPosition = new Point(
                SnakeParts[0].Position.X + moveCoordinate.X,
                SnakeParts[0].Position.Y + moveCoordinate.Y); //new position for the head
            
            //check the next tile

            ushort nextValue = Board[newPosition.X, newPosition.Y];
           
            //NOT SO SPECIAL CASE: check if next value is a wall or snake part
           switch (nextValue)
            {
                case (int)BoardValue.SnakePart:
                    //SPECIAL CASE: if next tile is the last snake part, don't crash but continue moving
                    if (!(newPosition.X == SnakeParts[SnakeParts.Count - 1].Position.X && newPosition.Y == SnakeParts[SnakeParts.Count - 1].Position.Y))
                    {
                        //die
                        return Die("Intersection");
                    }
                    break;
                case (int)BoardValue.Wall:
                    //die
                    return Die("Wall");
            }
           
            if (FoodService.IsBoardValueFruit(nextValue))
            {
                EatCurrentFood(nextValue, newPosition);
            }
          
            //move the whole body
            Point prevPosition = SnakeParts[0].Position;
            SnakeParts[0].Position = newPosition;
            Board[newPosition.X, newPosition.Y] = (int)BoardValue.SnakeHead;

            for (int i = 1; i < SnakeParts.Count; ++i)
            {
                Point currPosition = SnakeParts[i].Position;
                SnakeParts[i].Position = prevPosition;
                Board[prevPosition.X, prevPosition.Y] = (int)BoardValue.SnakePart;
                prevPosition = currPosition;
            }

            //grow if you can
            if (toGrow > 0)
            {
                SnakeParts.Add(new SnakePart("SnakePart", prevPosition));
                Board[prevPosition.X, prevPosition.Y] = (int)BoardValue.SnakePart;
                toGrow--;
            }
            else
            { //cant't grow so set last board value to 0
                Board[prevPosition.X, prevPosition.Y] = 0;
            }

            //didn't die
            return "";
        }

        public string Die(string reason = "")
        {
            //Clear all body parts
            while (SnakeParts.Count > 0)
            {
                Board[SnakeParts[0].Position.X, SnakeParts[0].Position.Y] = 0;
                SnakeParts.RemoveAt(0);
            }

            return reason;
        }
    }
}
