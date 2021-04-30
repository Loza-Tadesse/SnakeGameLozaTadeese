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
    ID is the location of the apple 
    apple is the snack for the snake
    
*/
namespace SnakeGameLozaTadesse
{
    class Food : GameObject
    {
        public Food(int id, Point position, int snack, int x) : base(FoodService.GetName(id), position)
        {
           Location = id;
           Apples = snack;
        }

        private int Location;
        private int Apples;


        public int Id { get => Location; }
        public int Snack { get => Apples; }
      //  public int Life { get => Life_real; }
    }
}
