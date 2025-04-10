using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameStorage
{
    internal class Game
    {
        //Enums for Condition and Category
        public enum ConditionLevel
        {
            Like_New = 1,
            Good = 2,
            Decent = 3,
            Acceptable = 4
        }
        public enum GameCategory
        {
            Strategy,
            Family,
            Party,
            Cooperative,
            Puzzle,
            Card_Game,
            Social_Deduction
        }

        //Properties
        public string Name { get; set; }
        public ConditionLevel Condition { get; set; }
        public int Id { get; set; }
        public double Price { get; set; }
        public int MinPlayer { get; set; }
        public int MaxPlayer { get; set; }
        public GameCategory Category { get; set; }

        //Constructor
        public Game(string name, ConditionLevel condition, int id, double price, int minPlayer, int maxPlayer, GameCategory category)
        {
            Name = name;
            Condition = condition;
            Id = id;
            Price = price;
            MinPlayer = minPlayer;
            MaxPlayer = maxPlayer;
            Category = category;
        }
    }
}
