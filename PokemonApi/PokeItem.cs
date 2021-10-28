﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    public class PokeItem
    {
        public PokeItem(string name, string id, string height, string weight)
        {
            Name = name;
            ID = id;
            Height = height;
            Weight = weight;
        }
        public string Name { get; set; }
        public string ID { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
    }
}