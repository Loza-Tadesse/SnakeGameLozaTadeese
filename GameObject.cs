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
 elements in the game
 */
namespace SnakeGameLozaTadesse
{
    abstract class GameObject
    {
        public GameObject(string name, Point position)
        {
            Position = position;
            Name = name;
            switch (Name)
            {
                case "SnakePart": BoardChar = (int)BoardValue.SnakePart; break;
                case "SnakeHead": BoardChar = (int)BoardValue.SnakeHead; break;
                case "Wall": BoardChar = (int)BoardValue.Wall; break;
                case "Apple": BoardChar = (int)BoardValue.Apple; break;
             
            }
        }

        public Point Position;
        public string Name;
        public int BoardChar;
    }
}
