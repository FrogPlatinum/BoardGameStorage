﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameStorage
{
    internal class Inquiry
    {
        public string CustomerFirstName {  get; set; }
        public string CustomerLastName { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public string GameWish { get; set; }
        public enum GameCondition
        {
            Like_New = 1,
            Good = 2,
            Decent = 3,
            Acceptable = 4,
        }
        public GameCondition ConditionWish { get; set; }

        public Inquiry(Customer customer, int id, string description, string gameWish, GameCondition conditionWish)
        {
            CustomerFirstName = customer.FirstName;
            CustomerLastName = customer.LastName;
            Id = id;
            Description = description;
            GameWish = gameWish;
            ConditionWish = conditionWish;
        }
    }
}
