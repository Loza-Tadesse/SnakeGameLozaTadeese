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
    This code draws the elements in the GameScreen and has a functions that cleans it all up forthe second game.     
*/
namespace SnakeGameLozaTadesse
{
    class DrawArea
    {
        public DrawArea(ref Panel GameScreen)
        {
            gamePanel = GameScreen;
            graphics = gamePanel.CreateGraphics();

            //set up brushes
            Brushes = new Dictionary<string, SolidBrush>()
            {
                { "Background", new SolidBrush(Color.White) },
                { "SnakeHead",  new SolidBrush(Color.Black) },
                { "SnakePart",  new SolidBrush(Color.Gray)  },
                { "Wall",       new SolidBrush(Color.Black) },
                { "Apple",      new SolidBrush(Color.Red)   },
       
            };

            //set up pens
            BorderPens = new Dictionary<string, Pen>()
            {
                { "Wall",       new Pen(Color.DarkGray, 2)  },
            };
            foreach (KeyValuePair<string, Pen> keyval in BorderPens)
            {
                keyval.Value.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            }
         
        }

        Panel gamePanel;
        Graphics graphics;
        const int ObjectSize = 20;
        Dictionary<string, SolidBrush> Brushes;
        Dictionary<string, Pen> BorderPens;

        public void Clear()
        {
            graphics.FillRectangle(Brushes["Background"], 0, 0, gamePanel.Width, gamePanel.Height);
        }

        public void DrawSquare(Point position, string brushName)
        {
            graphics.FillRectangle(
                Brushes[brushName],
                position.X * ObjectSize,
                position.Y * ObjectSize,
                ObjectSize,
                ObjectSize);
        }

        public void DrawBorder(Point position, string penName)
        {
            graphics.DrawRectangle(
                BorderPens[penName],
                position.X * ObjectSize,
                position.Y * ObjectSize,
                ObjectSize,
                ObjectSize);
        }

        public void DrawFood(Food food)
        {
            graphics.FillEllipse(
                Brushes[food.Name],
                food.Position.X * ObjectSize,
                food.Position.Y * ObjectSize,
                ObjectSize,
                ObjectSize);
        }
    }
}
