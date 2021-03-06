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
  controls most activites done in the game form the score to the snake motion and the apple placement.   
 */
namespace SnakeGameLozaTadesse
{
    enum Directions
    {
        Left = 1,
        Right = 2,
        Up = 3,
        Down = 4,
    }

    enum BoardValue
    {
        Background = 0,
        SnakeHead = 1,
        SnakePart = 2,
        Wall = 3,
        Apple = 4,
      
    }

    class Game
    {
        public Game(ref Panel gamePanel, ref ToolStripMenuItem _scoreTSMI, ref ToolStripMenuItem _timeTSMI, ref System.Windows.Forms.Timer _timer, ref System.Windows.Forms.Timer _foodTimer)
        { //ctor
            scoreTSMI = _scoreTSMI;
            timeTSMI = _timeTSMI;
            timer = _timer;
            foodTimer = _foodTimer;
            timer.Interval = TickSpeed;
            Board = new ushort[BoardSizeX, BoardSizeY];
            drawArea = new DrawArea(ref gamePanel);
            random = new Random();
            Walls = new List<Wall>();
        }
        

        //Windows form controls and some utilities
        ToolStripMenuItem scoreTSMI;
        ToolStripMenuItem timeTSMI;
        System.Windows.Forms.Timer timer;
        System.Windows.Forms.Timer foodTimer;
        Random random;

        //Graphics
        const int BoardSizeX = 36;
        const int BoardSizeY = 22;

        //Actual game stuff
        public int CurrentScore = 0;
       // int TimeSurvived = 0;
        ushort[,] Board;
        DrawArea drawArea;
        Player player;
        Food CurrentFood;
        List<Wall> Walls;

        //Tick and time counting
        const int TickSpeed = 100; //Time (ms) between ticks
       
     
        public void New() //restart with creating new setting for new game
        {
            timer.Stop();
            foodTimer.Stop();

            drawArea.Clear();

            CurrentScore = 0;
          //  TimeSurvived = 0;


            scoreTSMI.Text = String.Format("Score: {0}", CurrentScore);

            if (player != null)
            {
                player.Die();
            }

            MakeWalls();

            SpawnFood();

            player = new Player(ref Board, BoardSizeX, BoardSizeY, new Point(BoardSizeX / 2 - 3, BoardSizeY / 2));
            SetPlayerDirection((int)Directions.Right);

            timer.Start();
        }
        
        private void UpdateTimeSurvived()
        {
            
        }
       
        public void Tick()
        {
            //move the player
            drawArea.DrawSquare(player.SnakeParts[player.SnakeParts.Count - 1].Position, "Background");

            string deathReason = player.Move();

            //if food has been eaten: add score, update score label and spawn new food
            bool hasEatenFood = player.ScoreToAdd > 0;
            if (hasEatenFood)
            {
                CurrentScore += player.ScoreToAdd;
                player.ScoreToAdd = 0;
                SpawnFood();
                scoreTSMI.Text = String.Format("Score: {0}", CurrentScore);
            }

            //check if dead
            if (deathReason != "")
            { //Actually dead
                End(deathReason);
            }
            else
            { //not dead
                //draw snake body
                foreach (SnakePart snakePart in player.SnakeParts)
                {
                    drawArea.DrawSquare(snakePart.Position, snakePart.Name);
                }

                
            }
        }
        
        public void SetPlayerDirection(int direction)
        {
            player.SetDirection(direction);
        }

        private void End(string deathReason)
        {
            timer.Stop();
            foodTimer.Stop();

            switch (deathReason)
            { 
                case "Intersection": MessageBox.Show(String.Format("Game Over your score is :\nScore: {0}", CurrentScore)); break;
                case "Wall": MessageBox.Show(String.Format("Game Over your score is :\nScore: {0}", CurrentScore)); break;
            }
        }

        public void SpawnFood()//place ment of the apples 
        {
            foodTimer.Stop();

            //remove food
            if (CurrentFood != null)
            {
                if (Board[CurrentFood.Position.X, CurrentFood.Position.Y] == FoodService.GetBoardValue(CurrentFood.Id))
                {
                    Board[CurrentFood.Position.X, CurrentFood.Position.Y] = 0;
                    drawArea.DrawSquare(CurrentFood.Position, "Background");
                }
                CurrentFood = null;
            }

            //pick position
            Point randomPosition;
            do
            {
                randomPosition = new Point(random.Next(1, BoardSizeX - 2), random.Next(1, BoardSizeY - 2));
            } while (Board[randomPosition.X, randomPosition.Y] != 0); //we need an empty tile

            //spawn food, place it on board, draw it
            CurrentFood = FoodService.NewFood(FoodService.RandomId(), randomPosition);

            Board[CurrentFood.Position.X, CurrentFood.Position.Y] = FoodService.GetBoardValue(CurrentFood.Id);

            drawArea.DrawFood(CurrentFood);

            
        }

        private void MakeWalls()
        { //make walls around the outer edges
            for (int i = 0; i < (BoardSizeX / 2 ); ++i)
            {
                MakeWall(new Point(i, 0));
                MakeWall(new Point(i, BoardSizeY - 1));
            }
            for (int i = (BoardSizeX / 2 ); i < BoardSizeX; ++i)
            {
                MakeWall(new Point(i, 0));
                MakeWall(new Point(i, BoardSizeY - 1));
            }

            for (int i = 1; i < BoardSizeY; ++i)
            {
                MakeWall(new Point(0, i));
                MakeWall(new Point(BoardSizeX - 1, i));
            }
        }

        private void MakeWall(Point position)
        {
            Wall wall = new Wall("Wall", position);
            Walls.Add(wall);
            Board[position.X, position.Y] = (int)BoardValue.Wall;
            drawArea.DrawSquare(position, "Wall");
            drawArea.DrawBorder(position, "Wall");
        }
       
    }

}