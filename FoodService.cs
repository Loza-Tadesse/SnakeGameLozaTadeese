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
    generate randome values for the apple 
    give the randome values for the apple 
    place the apples at the randome locations 
 */
namespace SnakeGameLozaTadesse
{
    static class FoodService
    {

        static FoodService()
        {
            random = new Random();

            Foods = new Dictionary<Tuple<string, int, ushort>, Tuple<int, int, int>>()
            {
                { new Tuple<string, int, ushort>("Apple",  1, (int)BoardValue.Apple),   new Tuple<int, int, int>(2, 50, 20000)  },
             };

            ProbabilityPool = new List<int>(); //create a random pool 

            foreach (var kvp in Foods)
            {
                int id = kvp.Key.Item2;
                int rarity = kvp.Value.Item2;
                for (int i = 0; i < rarity; ++i)
                {
                    ProbabilityPool.Add(id);
                }
            }
        }

        static Dictionary<Tuple<string, int, ushort>, Tuple<int, int, int>> Foods;
        static List<int> ProbabilityPool;

        static Random random;

        public static int RandomId()
        {
            return ProbabilityPool[random.Next(0, ProbabilityPool.Count - 1)]; //get random item from the probability pool
        }

        public static Food NewFood(int id, Point position)
        {
            foreach (var kvp in Foods)
            {
                if (kvp.Key.Item2 == id)
                {
                    return new Food(id, position, kvp.Value.Item1, kvp.Value.Item3);
                }
            }
            throw new Exception("Invalid Food Id");
        }
  
        public static Food NewFood(ushort boardValue, Point position)
        {
            foreach (var kvp in Foods)
            {
                if (kvp.Key.Item3 == boardValue)
                {
                    return new Food(kvp.Key.Item2, position, kvp.Value.Item1, kvp.Value.Item3);
                }
            }
            throw new Exception("Invalid Food Name");
        }
       
        public static ushort GetBoardValue(int id)//location of apple
        {
            foreach (var kvp in Foods)
            {
                if (kvp.Key.Item2 == id)
                {
                    return kvp.Key.Item3;
                }
            }
            throw new Exception("Invalid Food Id");
        }
      
        public static string GetName(int id)
        {
            foreach (var kvp in Foods)
            {
                if (kvp.Key.Item2 == id)
                {
                    return kvp.Key.Item1;
                }
            }
            throw new Exception("Invalid Food Id");
        }
        
        public static bool IsBoardValueFruit(ushort boardValue)//add score 
        {
            foreach (var kvp in Foods)
            {
                if (kvp.Key.Item3 == boardValue)
                {
                    return true;
                }
            }
            return false;
        }
       

    }
}
