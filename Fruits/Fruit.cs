﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruits
{
    internal class Fruit
    {
        private string id;
        private string name;
        private int quantity;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public Fruit(string id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }

        public override string ToString() 
        {
            return $"{this.Name} ({this.Quantity})";
        }

        public string Totxt()
        {
            return $"{this.Id};{this.Name};{this.Quantity}";
        }
    }
}
